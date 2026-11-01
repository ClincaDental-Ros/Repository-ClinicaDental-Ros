using API.Clients;
using DTOs;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Alta y modificación de una factura (maestro) con sus ítems de insumos (detalle).
    /// Los precios, honorarios y el descuento de obra social los calcula la API al guardar.
    /// </summary>
    public partial class FacturaEdicionForm : Form
    {
        private readonly FacturaApiClient _facturaClient = new();
        private readonly PacienteApiClient _pacienteClient = new();
        private readonly TurnoApiClient _turnoClient = new();
        private readonly InsumoApiClient _insumoClient = new();
        private readonly FacturaDTO? _facturaExistente;

        private readonly List<ItemFacturaDTO> _items = new();
        private List<InsumoDTO> _insumos = new();

        private sealed record OpcionTurno(int? Id, string Texto)
        {
            public override string ToString() => Texto;
        }

        public FacturaEdicionForm(FacturaDTO? factura = null)
        {
            _facturaExistente = factura;
            InitializeComponent();

            if (_facturaExistente != null)
            {
                this.Text = $"Modificar Factura N° {_facturaExistente.Id}";
                lblHeader.Text = "🧾 Editar Factura Pendiente";
                cbPaciente.Enabled = false;
            }

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += async (s, e) => await CargarDatosAsync();
            }
        }

        private async void CbPaciente_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await CargarTurnosAsync();
        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            AgregarItem();
        }

        private void BtnQuitar_Click(object? sender, EventArgs e)
        {
            QuitarItem();
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            await GuardarAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                var pacientes = await _pacienteClient.GetAllAsync();
                _insumos = await _insumoClient.GetAllAsync();

                cbInsumo.DisplayMember = "Nombre";
                cbInsumo.ValueMember = "Id";
                cbInsumo.DataSource = _insumos;

                if (_facturaExistente != null)
                {
                    txtDescripcion.Text = _facturaExistente.Descripcion;
                    _items.AddRange(_facturaExistente.Items.Select(i => new ItemFacturaDTO
                    {
                        InsumoId = i.InsumoId,
                        InsumoNombre = i.InsumoNombre,
                        CantidadInsumo = i.CantidadInsumo,
                        PrecioUnitario = i.PrecioUnitario
                    }));
                }

                cbPaciente.DisplayMember = "NombreCompleto";
                cbPaciente.ValueMember = "Id";
                cbPaciente.DataSource = pacientes;
                if (_facturaExistente != null)
                    cbPaciente.SelectedValue = _facturaExistente.PacienteId;

                await CargarTurnosAsync();
                RefrescarItems();
            }
            catch (Exception ex)
            {
                lblError.Text = $"No se pudieron cargar los datos: {ex.Message}";
                btnGuardar.Enabled = false;
            }
        }

        private async Task CargarTurnosAsync()
        {
            if (cbPaciente.SelectedItem is not PacienteDTO paciente) return;

            try
            {
                var turnos = await _turnoClient.GetByCriteriaAsync(new TurnoCriteriaDTO { PacienteId = paciente.Id });
                var opciones = new List<OpcionTurno> { new(null, "(Sin turno: solo insumos)") };
                opciones.AddRange(turnos
                    .Where(t => t.EstadoTurno != "Cancelado")
                    .OrderByDescending(t => t.Fecha)
                    .Select(t => new OpcionTurno(t.Id, $"N° {t.Id} - {t.Fecha:dd/MM/yyyy} {t.HorarioTurno:HH:mm} - {t.EspecialidadNombre} ({t.EstadoTurno})")));

                cbTurno.DataSource = opciones;
                var turnoActual = _facturaExistente?.PacienteId == paciente.Id ? _facturaExistente.TurnoId : null;
                cbTurno.SelectedItem = opciones.FirstOrDefault(o => o.Id == turnoActual) ?? opciones[0];
            }
            catch (Exception ex)
            {
                lblError.Text = $"No se pudieron cargar los turnos del paciente: {ex.Message}";
            }
        }

        private void AgregarItem()
        {
            if (cbInsumo.SelectedItem is not InsumoDTO insumo) return;

            var cantidad = (int)nudCantidad.Value;
            var existente = _items.FirstOrDefault(i => i.InsumoId == insumo.Id);
            if (existente != null)
            {
                existente.CantidadInsumo += cantidad;
            }
            else
            {
                _items.Add(new ItemFacturaDTO
                {
                    InsumoId = insumo.Id,
                    InsumoNombre = insumo.Nombre,
                    CantidadInsumo = cantidad,
                    PrecioUnitario = insumo.Precio
                });
            }

            nudCantidad.Value = 1;
            RefrescarItems();
        }

        private void QuitarItem()
        {
            if (gridItems.CurrentRow?.DataBoundItem is ItemFacturaDTO item)
            {
                _items.Remove(item);
                RefrescarItems();
            }
        }

        private void RefrescarItems()
        {
            gridItems.DataSource = null;
            gridItems.DataSource = _items.ToList();
            lblTotalItems.Text = $"Total insumos: {_items.Sum(i => i.Subtotal):C2}  ({_items.Count} ítem/s)";
        }

        private async Task GuardarAsync()
        {
            lblError.Text = "";

            if (cbPaciente.SelectedItem is not PacienteDTO paciente)
            {
                lblError.Text = "Seleccione un paciente.";
                return;
            }

            var turnoId = (cbTurno.SelectedItem as OpcionTurno)?.Id;
            if (turnoId == null && _items.Count == 0)
            {
                lblError.Text = "La factura debe estar asociada a un turno o tener al menos un ítem.";
                return;
            }

            var dto = new FacturaDTO
            {
                Id = _facturaExistente?.Id ?? 0,
                PacienteId = paciente.Id,
                TurnoId = turnoId,
                Descripcion = txtDescripcion.Text.Trim(),
                Items = _items.Select(i => new ItemFacturaDTO { InsumoId = i.InsumoId, CantidadInsumo = i.CantidadInsumo }).ToList()
            };

            btnGuardar.Enabled = false;
            try
            {
                var guardada = _facturaExistente == null
                    ? await _facturaClient.CrearAsync(dto)
                    : await _facturaClient.ActualizarAsync(dto);

                if (guardada != null)
                {
                    MessageBox.Show(this,
                        $"Factura N° {guardada.Id} guardada.\nTotal: {guardada.Total:C2}\nDescuento obra social: -{guardada.DescuentoObraSocial:C2}\nA pagar por el paciente: {guardada.MontoAPagarPaciente:C2}",
                        "Clínica Odontológica - Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                btnGuardar.Enabled = true;
            }
        }
    }
}
