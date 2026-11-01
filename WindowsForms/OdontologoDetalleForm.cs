using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class OdontologoDetalleForm : Form
    {
        private readonly OdontologoApiClient _apiClient = new();
        private readonly EspecialidadApiClient _espClient = new();
        private readonly OdontologoDTO? _odontologoExistente;
        private List<EspecialidadDTO> _especialidades = new();

        public OdontologoDetalleForm(OdontologoDTO? odontologo = null)
        {
            _odontologoExistente = odontologo;
            InitializeComponent();

            if (_odontologoExistente != null)
            {
                this.Text = "Modificar Profesional";
                lblHeader.Text = $"Editar Odontólogo #{_odontologoExistente.Id}";
            }

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnFormLoad;
            }
        }

        private async void OnFormLoad(object? sender, EventArgs e)
        {
            await CargarEspecialidades();
            if (_odontologoExistente != null)
            {
                CargarDatos();
            }
        }

        private async Task CargarEspecialidades()
        {
            try
            {
                _especialidades = await _espClient.GetAllAsync();
                cbEspecialidad.DataSource = _especialidades;
                cbEspecialidad.DisplayMember = "Nombre";
                cbEspecialidad.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                lblError.Text = $"Error cargando especialidades: {ex.Message}";
            }
        }

        private void CargarDatos()
        {
            if (_odontologoExistente == null) return;

            txtMatricula.Text = _odontologoExistente.NumMatricula.ToString();
            txtNombre.Text = _odontologoExistente.Nombre;
            txtApellido.Text = _odontologoExistente.Apellido;
            txtDni.Text = _odontologoExistente.Dni.ToString();
            txtTelefono.Text = _odontologoExistente.Telefono;
            txtMail.Text = _odontologoExistente.Mail;
            txtDomicilio.Text = _odontologoExistente.Domicilio;

            if (_odontologoExistente.EspecialidadId > 0)
            {
                cbEspecialidad.SelectedValue = _odontologoExistente.EspecialidadId;
            }
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtMatricula.Text))
            {
                lblError.Text = "Por favor, complete los campos obligatorios (*).";
                return;
            }

            if (!int.TryParse(txtMatricula.Text.Trim(), out var matricula) || matricula <= 0)
            {
                lblError.Text = "La matrícula debe ser un número entero positivo.";
                return;
            }

            int.TryParse(txtDni.Text.Trim(), out var dni);
            int especialidadId = cbEspecialidad.SelectedValue is int id ? id : 1;

            btnGuardar.Enabled = false;

            try
            {
                var dto = new OdontologoDTO
                {
                    Id = _odontologoExistente?.Id ?? 0,
                    NumMatricula = matricula,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = dni,
                    Telefono = txtTelefono.Text.Trim(),
                    Mail = txtMail.Text.Trim(),
                    Domicilio = txtDomicilio.Text.Trim(),
                    EspecialidadId = especialidadId
                };

                if (_odontologoExistente == null)
                {
                    await _apiClient.CreateAsync(dto);
                    MessageBox.Show("Odontólogo registrado con éxito.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _apiClient.UpdateAsync(dto);
                    MessageBox.Show("Odontólogo modificado con éxito.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
