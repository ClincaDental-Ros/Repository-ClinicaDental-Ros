using API.Auth.WindowsForms;
using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class ConfiguracionControl : UserControl
    {
        private readonly WindowsFormsAuthService _authService = null!;
        private readonly PacienteApiClient _pacienteClient = new();
        private readonly AuthApiClient _authClient = new();

        private bool _fotoModificada = false;
        private bool _fotoEliminada = false;
        private PacienteDTO? _pacienteActual;
        private Action? _onPerfilActualizado;

        public ConfiguracionControl()
        {
            InitializeComponent();
            if (cbObraSocial.Items.Count > 1)
                cbObraSocial.SelectedIndex = 1;
        }

        public ConfiguracionControl(WindowsFormsAuthService authService, Action? onPerfilActualizado = null) : this()
        {
            _authService = authService;
            _onPerfilActualizado = onPerfilActualizado;
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnControlLoad;
            }
        }

        private void PnlCard_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Control card) return;
            using var pen = new Pen(UITheme.BorderColor, 1);
            e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
        }

        private void PicAvatar_Paint(object? sender, PaintEventArgs e)
        {
            using var path = new GraphicsPath();
            path.AddEllipse(0, 0, 80, 80);
            picAvatar.Region = new Region(path);
        }

        private void BtnQuitarFoto_Click(object? sender, EventArgs e)
        {
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;
            picAvatar.Visible = false;
            lblAvatarIniciales.Visible = true;
            _fotoModificada = true;
            _fotoEliminada = true;
        }

        private void BtnEyeActual_Click(object? sender, EventArgs e)
        {
            txtPassActual.UseSystemPasswordChar = !txtPassActual.UseSystemPasswordChar;
            btnEyeActual.Text = txtPassActual.UseSystemPasswordChar ? UITheme.IconoVer : UITheme.IconoOcultar;
        }

        private void BtnEyeNueva_Click(object? sender, EventArgs e)
        {
            txtPassNueva.UseSystemPasswordChar = !txtPassNueva.UseSystemPasswordChar;
            btnEyeNueva.Text = txtPassNueva.UseSystemPasswordChar ? UITheme.IconoVer : UITheme.IconoOcultar;
        }

        private void BtnEyeConfirmar_Click(object? sender, EventArgs e)
        {
            txtPassConfirmar.UseSystemPasswordChar = !txtPassConfirmar.UseSystemPasswordChar;
            btnEyeConfirmar.Text = txtPassConfirmar.UseSystemPasswordChar ? UITheme.IconoVer : UITheme.IconoOcultar;
        }

        private void TxtPass_TextChanged(object? sender, EventArgs e)
        {
            var n = txtPassNueva.Text;
            var c = txtPassConfirmar.Text;
            if (string.IsNullOrEmpty(n) && string.IsNullOrEmpty(c))
            {
                lblPassMatch.Text = "";
            }
            else if (!string.IsNullOrEmpty(n) && n.Length < 4)
            {
                lblPassMatch.ForeColor = Color.FromArgb(217, 119, 6);
                lblPassMatch.Text = "⚠ La nueva contraseña debe tener al menos 4 caracteres.";
            }
            else if (!string.IsNullOrEmpty(c))
            {
                if (n == c)
                {
                    lblPassMatch.ForeColor = Color.FromArgb(16, 185, 129);
                    lblPassMatch.Text = "✓ Las contraseñas coinciden correctamente.";
                }
                else
                {
                    lblPassMatch.ForeColor = UITheme.Danger;
                    lblPassMatch.Text = "✗ Las contraseñas no coinciden.";
                }
            }
            else
            {
                lblPassMatch.Text = "";
            }
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarDatosPerfil();
        }

        private async Task CargarDatosPerfil()
        {
            try
            {
                var username = _authService.GetUsername() ?? "paciente1";

                var avatarImg = UserAvatarService.LoadAvatar(username);
                if (avatarImg != null)
                {
                    picAvatar.Image?.Dispose();
                    picAvatar.Image = avatarImg;
                    picAvatar.Visible = true;
                    lblAvatarIniciales.Visible = false;
                }
                else
                {
                    picAvatar.Image?.Dispose();
                    picAvatar.Image = null;
                    picAvatar.Visible = false;
                    lblAvatarIniciales.Visible = true;
                }

                // Solo el rol Paciente tiene ficha propia; se busca por el EntidadId del token
                var entidadId = _authService.GetEntidadId();
                _pacienteActual = _authService.GetRol() == "Paciente" && entidadId.HasValue
                    ? await _pacienteClient.GetByIdAsync(entidadId.Value)
                    : null;

                if (_pacienteActual == null)
                {
                    MostrarPerfilPersonal();
                }
                else
                {
                    txtNombre.Text = _pacienteActual.Nombre;
                    txtApellido.Text = _pacienteActual.Apellido;
                    txtDni.Text = _pacienteActual.Dni.ToString();
                    txtMail.Text = _pacienteActual.Mail;
                    txtTelefono.Text = _pacienteActual.Telefono;
                    txtDomicilio.Text = _pacienteActual.Domicilio;
                    txtAfiliado.Text = _pacienteActual.NumeroAfiliado ?? "";

                    lblAvatarIniciales.Text = _pacienteActual.Nombre.Length > 0 ? _pacienteActual.Nombre[0].ToString().ToUpper() : "U";

                    if (_pacienteActual.ObraSocialId.HasValue)
                    {
                        switch (_pacienteActual.ObraSocialId.Value)
                        {
                            case 1: cbObraSocial.SelectedIndex = 1; break;
                            case 2: cbObraSocial.SelectedIndex = 2; break;
                            case 3: cbObraSocial.SelectedIndex = 3; break;
                            default: cbObraSocial.SelectedIndex = 0; break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblFeedback.ForeColor = UITheme.Danger;
                lblFeedback.Text = $"No se pudieron cargar los datos del perfil: {ex.Message}";
            }
        }

        /// <summary>El personal no tiene ficha de paciente: solo puede cambiar su foto y su contraseña.</summary>
        private void MostrarPerfilPersonal()
        {
            var nombre = (_authService.GetNombreCompleto() ?? _authService.GetUsername() ?? "").Trim();
            var partes = nombre.Split(' ', 2);
            txtNombre.Text = partes[0];
            txtApellido.Text = partes.Length > 1 ? partes[1] : "";
            foreach (var tb in new[] { txtDni, txtMail, txtTelefono, txtDomicilio, txtAfiliado })
                tb.Text = "";

            foreach (Control c in new Control[] { txtNombre, txtApellido, txtDni, txtMail, txtTelefono, txtDomicilio, txtAfiliado, cbObraSocial })
                c.Enabled = false;

            lblAvatarIniciales.Text = nombre.Length > 0 ? nombre[0].ToString().ToUpper() : "U";
        }

        private void BtnCambiarFoto_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Seleccionar Foto de Perfil",
                Filter = "Archivos de Imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = false
            };

            if (ofd.ShowDialog(FindForm()) == DialogResult.OK)
            {
                try
                {
                    using (var ms = new MemoryStream(File.ReadAllBytes(ofd.FileName)))
                    {
                        picAvatar.Image?.Dispose();
                        picAvatar.Image = new Bitmap(ms);
                    }
                    picAvatar.Visible = true;
                    lblAvatarIniciales.Visible = false;
                    _fotoModificada = true;
                    _fotoEliminada = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            lblFeedback.Text = "";
            btnGuardar.Enabled = false;

            try
            {
                var username = _authService.GetUsername() ?? "paciente1";

                if (_fotoModificada)
                {
                    if (_fotoEliminada || picAvatar.Image == null)
                    {
                        UserAvatarService.DeleteAvatar(username);
                    }
                    else if (picAvatar.Image != null)
                    {
                        UserAvatarService.SaveAvatar(username, picAvatar.Image);
                    }
                    _fotoModificada = false;
                    _fotoEliminada = false;
                }
                if (_pacienteActual != null)
                {
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtMail.Text))
                    {
                        lblFeedback.ForeColor = UITheme.Danger;
                        lblFeedback.Text = "Por favor, complete los campos obligatorios (*).";
                        return;
                    }

                    _pacienteActual.Nombre = txtNombre.Text.Trim();
                    _pacienteActual.Apellido = txtApellido.Text.Trim();
                    _pacienteActual.Mail = txtMail.Text.Trim();
                    _pacienteActual.Telefono = txtTelefono.Text.Trim();
                    _pacienteActual.Domicilio = txtDomicilio.Text.Trim();
                    _pacienteActual.NumeroAfiliado = string.IsNullOrWhiteSpace(txtAfiliado.Text) ? null : txtAfiliado.Text.Trim();

                    _pacienteActual.ObraSocialId = cbObraSocial.SelectedIndex switch
                    {
                        1 => 1,
                        2 => 2,
                        3 => 3,
                        _ => 4
                    };

                    await _pacienteClient.UpdateAsync(_pacienteActual);
                }

                // Cambio de contraseña si se completó el campo Nueva Contraseña
                bool passCambiado = false;
                if (!string.IsNullOrWhiteSpace(txtPassNueva.Text))
                {
                    if (string.IsNullOrWhiteSpace(txtPassActual.Text))
                    {
                        lblFeedback.ForeColor = UITheme.Danger;
                        lblFeedback.Text = "Por favor, ingrese su contraseña actual para confirmar el cambio.";
                        return;
                    }

                    if (txtPassNueva.Text.Trim() != txtPassConfirmar.Text.Trim())
                    {
                        lblFeedback.ForeColor = UITheme.Danger;
                        lblFeedback.Text = "La nueva contraseña y su confirmación no coinciden.";
                        return;
                    }

                    if (txtPassNueva.Text.Trim().Length < 4)
                    {
                        lblFeedback.ForeColor = UITheme.Danger;
                        lblFeedback.Text = "La nueva contraseña debe tener al menos 4 caracteres.";
                        return;
                    }

                    var userId = _authService.GetUserId();
                    if (userId.HasValue)
                    {
                        var (passOk, passMsg) = await _authClient.CambiarPasswordAsync(userId.Value, txtPassActual.Text.Trim(), txtPassNueva.Text.Trim());
                        if (!passOk)
                        {
                            lblFeedback.ForeColor = UITheme.Danger;
                            lblFeedback.Text = passMsg;
                            return;
                        }
                        passCambiado = true;
                    }

                    txtPassActual.Text = "";
                    txtPassNueva.Text = "";
                    txtPassConfirmar.Text = "";
                    lblPassMatch.Text = "";
                }

                lblFeedback.ForeColor = UITheme.Success;
                lblFeedback.Text = passCambiado
                    ? "✓ ¡Datos del perfil y contraseña actualizados con éxito!"
                    : "✓ ¡Datos del perfil actualizados con éxito!";

                _onPerfilActualizado?.Invoke();
            }
            catch (Exception ex)
            {
                lblFeedback.ForeColor = UITheme.Danger;
                lblFeedback.Text = $"Error al guardar: {ex.Message}";
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }
    }
}
