using API.Clients;
using DTOs;
using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Alta y modificación de una factura (maestro) con sus ítems de insumos (detalle).
    /// Los precios, honorarios y el descuento de obra social los calcula la API al guardar.
    /// </summary>
    public class FacturaEdicionForm : Form
    {
        private readonly FacturaApiClient _facturaClient = new();
        private readonly PacienteApiClient _pacienteClient = new();
        private readonly TurnoApiClient _turnoClient = new();
        private readonly InsumoApiClient _insumoClient = new();
        private readonly FacturaDTO? _facturaExistente;

        private readonly List<ItemFacturaDTO> _items = new();
        private List<InsumoDTO> _insumos = new();

        private ComboBox cbPaciente = null!;
        private ComboBox cbTurno = null!;
        private TextBox txtDescripcion = null!;
        private ComboBox cbInsumo = null!;
        private NumericUpDown nudCantidad = null!;
        private DataGridView gridItems = null!;
        private Label lblTotalItems = null!;
        private Label lblError = null!;
        private Button btnGuardar = null!;

        private sealed record OpcionTurno(int? Id, string Texto)
        {
            public override string ToString() => Texto;
        }

        public FacturaEdicionForm(FacturaDTO? factura = null)
        {
            _facturaExistente = factura;
            InitializeComponent();
            BuildUI();
            this.Load += async (s, e) => await CargarDatosAsync();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(720, 640);
            this.Name = "FacturaEdicionForm";
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            bool esNueva = _facturaExistente == null;
            this.Text = esNueva ? "Nueva Factura" : $"Modificar Factura N° {_facturaExistente!.Id}";
            this.Size = new Size(720, 640);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = UITheme.CardBackground;
            this.Font = UITheme.RegularFont;

            var lblHeader = new Label
            {
                Text = esNueva ? "🧾 Registrar Factura" : "🧾 Editar Factura Pendiente",
                Font = UITheme.LargeTitleFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, 18),
                AutoSize = true
            };

            // --- Maestro ---
            var lblPac = new Label { Text = "Paciente *:", Location = new Point(25, 70), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            cbPaciente = new ComboBox { Location = new Point(150, 66), Width = 520, DropDownStyle = ComboBoxStyle.DropDownList, Enabled = esNueva };
            cbPaciente.SelectedIndexChanged += async (s, e) => await CargarTurnosAsync();

            var lblTurno = new Label { Text = "Turno:", Location = new Point(25, 108), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            cbTurno = new ComboBox { Location = new Point(150, 104), Width = 520, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblDesc = new Label { Text = "Descripción:", Location = new Point(25, 146), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            txtDescripcion = new TextBox { Location = new Point(150, 142), Width = 520, PlaceholderText = "Opcional: si queda vacía se genera automáticamente" };

            // --- Detalle ---
            var lblDetalle = new Label { Text = "Ítems (insumos):", Location = new Point(25, 190), AutoSize = true, Font = UITheme.SubheaderFont, ForeColor = UITheme.Primary };

            cbInsumo = new ComboBox { Location = new Point(25, 222), Width = 380, DropDownStyle = ComboBoxStyle.DropDownList };
            nudCantidad = new NumericUpDown { Location = new Point(415, 222), Width = 80, Minimum = 1, Maximum = 1000, Value = 1 };

            var btnAgregar = new Button { Text = "➕ Agregar", Location = new Point(505, 219), Size = new Size(80, 30) };
            UITheme.StylePrimaryButton(btnAgregar);
            btnAgregar.Click += (s, e) => AgregarItem();

            var btnQuitar = new Button { Text = "Quitar", Location = new Point(590, 219), Size = new Size(80, 30) };
            UITheme.StyleDangerButton(btnQuitar);
            btnQuitar.Click += (s, e) => QuitarItem();

            gridItems = new DataGridView { Location = new Point(25, 260), Size = new Size(645, 200) };
            UITheme.StyleDataGridView(gridItems);
            gridItems.AutoGenerateColumns = false;
            gridItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Insumo", Width = 290, DataPropertyName = "InsumoNombre" });
            gridItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cant.", Width = 80, DataPropertyName = "CantidadInsumo" });
            gridItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "P. Unitario", Width = 120, DataPropertyName = "PrecioUnitario", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            gridItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Subtotal", Width = 120, DataPropertyName = "Subtotal", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });

            lblTotalItems = new Label { Location = new Point(25, 470), Size = new Size(645, 22), Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            var lblNota = new Label
            {
                Text = "Los honorarios del turno y el descuento de la obra social se calculan al guardar.",
                Location = new Point(25, 494),
                AutoSize = true,
                Font = UITheme.SmallFont,
                ForeColor = UITheme.TextSecondary
            };

            lblError = new Label { Location = new Point(25, 520), Size = new Size(645, 22), ForeColor = UITheme.Danger, Font = UITheme.SmallBold };

            btnGuardar = new Button { Text = "💾 Guardar", Location = new Point(400, 550), Size = new Size(130, 38) };
            UITheme.StyleSuccessButton(btnGuardar);
            btnGuardar.Click += async (s, e) => await GuardarAsync();

            var btnCancelar = new Button { Text = "Cancelar", Location = new Point(540, 550), Size = new Size(130, 38), DialogResult = DialogResult.Cancel };
            UITheme.StyleSecondaryButton(btnCancelar);

            this.CancelButton = btnCancelar;
            this.Controls.AddRange(new Control[]
            {
                lblHeader, lblPac, cbPaciente, lblTurno, cbTurno, lblDesc, txtDescripcion,
                lblDetalle, cbInsumo, nudCantidad, btnAgregar, btnQuitar, gridItems,
                lblTotalItems, lblNota, lblError, btnGuardar, btnCancelar
            });
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
