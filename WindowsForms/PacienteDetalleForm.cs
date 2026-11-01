using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PacienteDetalleForm : Form
    {
        private readonly PacienteApiClient _apiClient = new();
        private readonly ObraSocialApiClient _obraSocialClient = new();
        private readonly PacienteDTO? _pacienteExistente;

        public PacienteDetalleForm(PacienteDTO? paciente = null)
        {
            _pacienteExistente = paciente;
            InitializeComponent();
            cbTipoDoc.SelectedIndex = 0;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                dtpFechaNac.MaxDate = DateTime.Today;
                if (_pacienteExistente != null)
                {
                    this.Text = "Editar Paciente";
                    lblHeader.Text = $"Editar Ficha Médica #{_pacienteExistente.Id}";
                    txtPassword.Text = "(oculta: se informó al crear el paciente)";
                    CargarDatos();
                }
                this.Load += async (s, e) => await CargarObrasSocialesAsync();
            }
        }

        private async Task CargarObrasSocialesAsync()
        {
            try
            {
                var lista = await _obraSocialClient.GetAllAsync();
                cbObraSocial.DisplayMember = nameof(ObraSocialDTO.Nombre);
                cbObraSocial.ValueMember = nameof(ObraSocialDTO.Id);
                cbObraSocial.Format += (s, e) =>
                {
                    if (e.ListItem is ObraSocialDTO os) e.Value = $"{os.Nombre} ({os.Plan})";
                };
                cbObraSocial.DataSource = lista;

                var particular = lista.FirstOrDefault(o => o.PorcentajeCobertura == 0m) ?? lista.FirstOrDefault();
                var seleccion = _pacienteExistente?.ObraSocialId ?? particular?.Id;
                if (seleccion.HasValue) cbObraSocial.SelectedValue = seleccion.Value;
            }
            catch (HttpRequestException ex)
            {
                lblError.Text = $"No se pudieron cargar las obras sociales: {ex.Message}";
                btnGuardar.Enabled = false;
            }
        }

        private void ChkHabilitado_CheckedChanged(object? sender, EventArgs e)
        {
            chkHabilitado.ForeColor = chkHabilitado.Checked ? UITheme.Success : UITheme.Danger;
            chkHabilitado.Text = chkHabilitado.Checked ? "Paciente Habilitado para Turnos" : "Paciente Inhabilitado (Bloqueo por Deuda/Falta)";
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarDatos()
        {
            if (_pacienteExistente == null) return;

            txtNombre.Text = _pacienteExistente.Nombre;
            txtApellido.Text = _pacienteExistente.Apellido;
            txtDni.Text = _pacienteExistente.Dni.ToString();
            txtTelefono.Text = _pacienteExistente.Telefono;
            txtMail.Text = _pacienteExistente.Mail;
            txtDomicilio.Text = _pacienteExistente.Domicilio;
            chkHabilitado.Checked = _pacienteExistente.EstadoHabilitado;
            txtAfiliado.Text = _pacienteExistente.NumeroAfiliado ?? "";
            txtUsuario.Text = _pacienteExistente.Username ?? "N/A";
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtDni.Text))
            {
                lblError.Text = "Por favor, complete los campos obligatorios (*).";
                return;
            }

            if (!int.TryParse(txtDni.Text.Trim(), out var dni) || dni <= 0)
            {
                lblError.Text = "El DNI ingresado debe ser un número válido.";
                return;
            }

            btnGuardar.Enabled = false;

            try
            {
                if (cbObraSocial.SelectedValue is not int osId)
                {
                    lblError.Text = "Elegí una obra social de la lista.";
                    return;
                }

                var dto = new PacienteDTO
                {
                    Id = _pacienteExistente?.Id ?? 0,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = dni,
                    Telefono = txtTelefono.Text.Trim(),
                    Mail = txtMail.Text.Trim(),
                    Domicilio = txtDomicilio.Text.Trim(),
                    EstadoHabilitado = chkHabilitado.Checked,
                    ObraSocialId = osId,
                    NumeroAfiliado = string.IsNullOrWhiteSpace(txtAfiliado.Text) ? null : txtAfiliado.Text.Trim()
                };

                if (_pacienteExistente == null)
                {
                    var creado = await _apiClient.CreateAsync(dto);
                    string usr = creado?.Username ?? (string.IsNullOrWhiteSpace(dto.Mail) ? $"{dto.Nombre.ToLower()}{dni}" : dto.Mail.Split('@')[0]);
                    string pwd = creado?.PasswordDefault ?? "paciente123";

                    MessageBox.Show(
                        $"¡Paciente registrado!\n\n" +
                        $"🔑 Credenciales para el Portal del Paciente:\n" +
                        $"• Usuario: {usr}\n" +
                        $"• Contraseña: {pwd}",
                        "Alta de Paciente Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await _apiClient.UpdateAsync(dto);
                    MessageBox.Show("Ficha médica del paciente actualizada con éxito.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }
    }
}
