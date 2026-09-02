using API.Auth.WindowsForms;
using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace WindowsForms
{
    public class ConfiguracionControl : UserControl
    {
        private readonly WindowsFormsAuthService _authService;
        private readonly PacienteApiClient _pacienteClient = new();
        private readonly AuthApiClient _authClient = new();

        private PictureBox picAvatar = null!;
        private Label lblAvatarIniciales = null!;
        private Button btnCambiarFoto = null!;
        private Button btnQuitarFoto = null!;

        private TextBox txtNombre = null!;
        private TextBox txtApellido = null!;
        private TextBox txtDni = null!;
        private TextBox txtMail = null!;
        private TextBox txtTelefono = null!;
        private TextBox txtDomicilio = null!;

        private ComboBox cbObraSocial = null!;
        private TextBox txtAfiliado = null!;

        private TextBox txtPassActual = null!;
        private TextBox txtPassNueva = null!;
        private TextBox txtPassConfirmar = null!;
        private Label lblPassMatch = null!;

        private CheckBox chkNotifEmail = null!;
        private CheckBox chkNotifWhatsapp = null!;

        private Button btnGuardar = null!;
        private Label lblFeedback = null!;

        private bool _fotoModificada = false;
        private bool _fotoEliminada = false;
        private PacienteDTO? _pacienteActual;
        private Action? _onPerfilActualizado;

        public ConfiguracionControl(WindowsFormsAuthService authService, Action? onPerfilActualizado = null)
        {
            _authService = authService;
            _onPerfilActualizado = onPerfilActualizado;
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                BuildUI();
                this.Load += OnControlLoad;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "ConfiguracionControl";
            this.Size = new Size(1000, 720);
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = UITheme.Background;
            this.Font = UITheme.RegularFont;

            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                Padding = new Padding(25, 15, 25, 10),
                BackColor = UITheme.CardBackground
            };

            var lblTitle = new Label
            {
                Text = "Configuración de Cuenta y Perfil de Usuario",
                Font = UITheme.HeaderFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, 12),
                AutoSize = true
            };

            var lblSub = new Label
            {
                Text = "Administrá tu foto de perfil, datos personales, cobertura de obra social, seguridad y preferencias",
                Font = UITheme.SmallFont,
                ForeColor = UITheme.TextSecondary,
                Location = new Point(27, 40),
                AutoSize = true
            };

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblSub);

            var pnlBody = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(25, 15, 25, 25)
            };

            int y = 15;

            // ==========================================
            // SECCIÓN 1: FOTO DE PERFIL / AVATAR
            // ==========================================
            var pnlFotoCard = new Panel { Location = new Point(25, y), Size = new Size(740, 115), BackColor = Color.White, Padding = new Padding(20) };
            pnlFotoCard.Paint += (s, e) =>
            {
                using var pen = new Pen(UITheme.BorderColor, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlFotoCard.Width - 1, pnlFotoCard.Height - 1);
            };

            picAvatar = new PictureBox { Location = new Point(20, 15), Size = new Size(80, 80), SizeMode = PictureBoxSizeMode.Zoom, Visible = false };
            picAvatar.Paint += (s, e) =>
            {
                using var path = new GraphicsPath();
                path.AddEllipse(0, 0, 80, 80);
                picAvatar.Region = new Region(path);
            };

            lblAvatarIniciales = new Label
            {
                Text = "U",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = UITheme.Primary,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 15),
                Size = new Size(80, 80)
            };

            btnCambiarFoto = new Button { Text = "📷 Cargar Foto de Perfil", Location = new Point(120, 25), Size = new Size(190, 36) };
            UITheme.StylePrimaryButton(btnCambiarFoto);
            btnCambiarFoto.Click += BtnCambiarFoto_Click;

            btnQuitarFoto = new Button { Text = "Quitar Foto", Location = new Point(320, 25), Size = new Size(120, 36) };
            UITheme.StyleSecondaryButton(btnQuitarFoto);
            btnQuitarFoto.Click += (s, e) =>
            {
                picAvatar.Image?.Dispose();
                picAvatar.Image = null;
                picAvatar.Visible = false;
                lblAvatarIniciales.Visible = true;
                _fotoModificada = true;
                _fotoEliminada = true;
            };

            var lblFotoInfo = new Label { Text = "Formatos soportados: JPG, PNG. Tamaño máximo recomendado 2MB.", Font = UITheme.SmallFont, ForeColor = UITheme.TextSecondary, Location = new Point(122, 68), AutoSize = true };

            pnlFotoCard.Controls.Add(picAvatar);
            pnlFotoCard.Controls.Add(lblAvatarIniciales);
            pnlFotoCard.Controls.Add(btnCambiarFoto);
            pnlFotoCard.Controls.Add(btnQuitarFoto);
            pnlFotoCard.Controls.Add(lblFotoInfo);

            pnlBody.Controls.Add(pnlFotoCard);
            y += 130;

            // ==========================================
            // SECCIÓN 2: DATOS PERSONALES
            // ==========================================
            var pnlDatosCard = new Panel { Location = new Point(25, y), Size = new Size(740, 210), BackColor = Color.White, Padding = new Padding(25, 20, 25, 20) };
            pnlDatosCard.Paint += (s, e) =>
            {
                using var pen = new Pen(UITheme.BorderColor, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlDatosCard.Width - 1, pnlDatosCard.Height - 1);
            };

            var lblDatosTitle = new Label { Text = "👤 Datos Personales del Titular", Font = UITheme.SubheaderFont, ForeColor = UITheme.Primary, Location = new Point(20, 15), AutoSize = true };
            pnlDatosCard.Controls.Add(lblDatosTitle);

            int dy = 45;
            void AddField(Panel parent, string label, ref TextBox tb, int x, int width, string val, bool enabled = true)
            {
                var l = new Label { Text = label, Location = new Point(x, dy), AutoSize = true, Font = UITheme.SmallBold, ForeColor = UITheme.TextPrimary };
                tb = new TextBox { Location = new Point(x, dy + 20), Width = width, Font = UITheme.RegularFont, Text = val, Enabled = enabled };
                parent.Controls.Add(l);
                parent.Controls.Add(tb);
            }

            AddField(pnlDatosCard, "Nombre *:", ref txtNombre, 20, 215, "Juan");
            AddField(pnlDatosCard, "Apellido *:", ref txtApellido, 250, 215, "Pérez");
            AddField(pnlDatosCard, "DNI / Documento:", ref txtDni, 480, 215, "34567890", enabled: false);

            dy += 65;
            AddField(pnlDatosCard, "Correo Electrónico *:", ref txtMail, 20, 215, "juan.perez@email.com");
            AddField(pnlDatosCard, "Teléfono Móvil *:", ref txtTelefono, 250, 215, "+54 341 555-1234");
            AddField(pnlDatosCard, "Domicilio:", ref txtDomicilio, 480, 215, "Av. Pellegrini 1234");

            pnlBody.Controls.Add(pnlDatosCard);
            y += 225;

            // ==========================================
            // SECCIÓN 3: OBRA SOCIAL Y COBERTURA
            // ==========================================
            var pnlOSCard = new Panel { Location = new Point(25, y), Size = new Size(740, 125), BackColor = Color.White, Padding = new Padding(25, 20, 25, 20) };
            pnlOSCard.Paint += (s, e) =>
            {
                using var pen = new Pen(UITheme.BorderColor, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlOSCard.Width - 1, pnlOSCard.Height - 1);
            };

            var lblOSTitle = new Label { Text = "🛡️ Obra Social y Cobertura Médica", Font = UITheme.SubheaderFont, ForeColor = UITheme.Primary, Location = new Point(20, 15), AutoSize = true };
            pnlOSCard.Controls.Add(lblOSTitle);

            var lblOS = new Label { Text = "Obra Social / Prepaga:", Location = new Point(20, 48), AutoSize = true, Font = UITheme.SmallBold, ForeColor = UITheme.TextPrimary };
            cbObraSocial = new ComboBox { Location = new Point(20, 70), Width = 320, DropDownStyle = ComboBoxStyle.DropDownList, Font = UITheme.RegularFont };
            cbObraSocial.Items.AddRange(new object[] {
                "Particular (Sin Obra Social)",
                "OSDE (Plan 210 / 310 / 410)",
                "Swiss Medical",
                "IOMA",
                "IAPOS",
                "Sancor Salud",
                "Federada Salud",
                "Jerárquicos Salud",
                "Galeno"
            });
            cbObraSocial.SelectedIndex = 1;

            var lblAf = new Label { Text = "N° de Afiliado / Credencial:", Location = new Point(360, 48), AutoSize = true, Font = UITheme.SmallBold, ForeColor = UITheme.TextPrimary };
            txtAfiliado = new TextBox { Location = new Point(360, 70), Width = 340, Font = UITheme.RegularFont, Text = "987456321" };

            pnlOSCard.Controls.Add(lblOS);
            pnlOSCard.Controls.Add(cbObraSocial);
            pnlOSCard.Controls.Add(lblAf);
            pnlOSCard.Controls.Add(txtAfiliado);

            pnlBody.Controls.Add(pnlOSCard);
            y += 140;

                        // ==========================================
            // SECCIÓN 4: SEGURIDAD Y NOTIFICACIONES
            // ==========================================
            var pnlSegCard = new Panel { Location = new Point(25, y), Size = new Size(740, 215), BackColor = Color.White, Padding = new Padding(25, 20, 25, 20) };
            pnlSegCard.Paint += (s, e) =>
            {
                using var pen = new Pen(UITheme.BorderColor, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlSegCard.Width - 1, pnlSegCard.Height - 1);
            };

            var lblSegTitle = new Label { Text = "🔒 Seguridad y Notificaciones", Font = UITheme.SubheaderFont, ForeColor = UITheme.Primary, Location = new Point(20, 15), AutoSize = true };
            pnlSegCard.Controls.Add(lblSegTitle);

            dy = 45;
            void AddPasswordField(Panel parent, string label, ref TextBox tb, int x, int width)
            {
                var l = new Label { Text = label, Location = new Point(x, dy), AutoSize = true, Font = UITheme.SmallBold, ForeColor = UITheme.TextPrimary };
                int tbWidth = width - 36;
                tb = new TextBox { Location = new Point(x, dy + 20), Width = tbWidth, Font = UITheme.RegularFont, UseSystemPasswordChar = true };

                var capturedTb = tb;
                var btnEye = new Button
                {
                    Text = "👁",
                    Location = new Point(x + tbWidth + 4, dy + 19),
                    Size = new Size(32, 27),
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    BackColor = Color.FromArgb(241, 245, 249),
                    ForeColor = UITheme.Primary
                };
                btnEye.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                btnEye.Click += (s, e) =>
                {
                    capturedTb.UseSystemPasswordChar = !capturedTb.UseSystemPasswordChar;
                    btnEye.Text = capturedTb.UseSystemPasswordChar ? "👁" : "🙈";
                };

                parent.Controls.Add(l);
                parent.Controls.Add(tb);
                parent.Controls.Add(btnEye);
            }

            AddPasswordField(pnlSegCard, "Contraseña Actual:", ref txtPassActual, 20, 215);
            AddPasswordField(pnlSegCard, "Nueva Contraseña:", ref txtPassNueva, 250, 215);
            AddPasswordField(pnlSegCard, "Confirmar Nueva:", ref txtPassConfirmar, 480, 215);

            lblPassMatch = new Label
            {
                Location = new Point(250, 97),
                Size = new Size(450, 20),
                Font = UITheme.SmallBold,
                Text = "",
                ForeColor = UITheme.Danger
            };
            pnlSegCard.Controls.Add(lblPassMatch);

            void VerificarCoincidencia()
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

            txtPassNueva.TextChanged += (s, e) => VerificarCoincidencia();
            txtPassConfirmar.TextChanged += (s, e) => VerificarCoincidencia();

            chkNotifEmail = new CheckBox { Text = "Recibir recordatorios y comprobantes de turnos por Email", Location = new Point(20, 130), AutoSize = true, Checked = true, Font = UITheme.SmallBold, ForeColor = UITheme.TextPrimary };
            chkNotifWhatsapp = new CheckBox { Text = "Recibir avisos de estado de sala y alertas por SMS / WhatsApp", Location = new Point(20, 155), AutoSize = true, Checked = true, Font = UITheme.SmallBold, ForeColor = UITheme.TextPrimary };

            pnlSegCard.Controls.Add(chkNotifEmail);
            pnlSegCard.Controls.Add(chkNotifWhatsapp);

            pnlBody.Controls.Add(pnlSegCard);
            y += 230;

            // ==========================================
            // BOTÓN GUARDAR Y FEEDBACK
            // ==========================================
            btnGuardar = new Button { Text = "💾 Guardar Todos los Cambios", Location = new Point(25, y), Size = new Size(260, 44) };
            UITheme.StylePrimaryButton(btnGuardar);
            btnGuardar.Click += BtnGuardar_Click;

            lblFeedback = new Label { Location = new Point(300, y + 10), Size = new Size(465, 30), Font = UITheme.RegularBold, ForeColor = UITheme.Success };

            pnlBody.Controls.Add(btnGuardar);
            pnlBody.Controls.Add(lblFeedback);

            this.Controls.Add(pnlBody);
            this.Controls.Add(pnlTop);
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

                var pacientes = await _pacienteClient.GetAllAsync();
                _pacienteActual = pacientes.FirstOrDefault(p => p.Mail.Contains(username, StringComparison.OrdinalIgnoreCase) || p.Nombre.Contains("Juan", StringComparison.OrdinalIgnoreCase)) ?? pacientes.FirstOrDefault();

                if (_pacienteActual != null)
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
            catch { }
        }

        private void BtnCambiarFoto_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Seleccionar Foto de Perfil",
                Filter = "Archivos de Imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = false
            };

            if (ofd.ShowDialog() == DialogResult.OK)
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
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtMail.Text))
                {
                    lblFeedback.ForeColor = UITheme.Danger;
                    lblFeedback.Text = "Por favor, complete los campos obligatorios (*).";
                    return;
                }

                if (_pacienteActual != null)
                {
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
