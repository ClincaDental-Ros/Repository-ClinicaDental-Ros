using API.Clients;
using DTOs;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class PacienteDetalleForm : Form
    {
        private readonly PacienteApiClient _apiClient = new();
        private readonly PacienteDTO? _pacienteExistente;

        private TextBox txtNombre = null!;
        private TextBox txtApellido = null!;
        private ComboBox cbTipoDoc = null!;
        private TextBox txtDni = null!;
        private DateTimePicker dtpFechaNac = null!;
        private TextBox txtTelefono = null!;
        private TextBox txtMail = null!;
        private TextBox txtDomicilio = null!;
        private ComboBox cbObraSocial = null!;
        private TextBox txtOtraObraSocial = null!;
        private Label lblOtraOS = null!;
        private TextBox txtAfiliado = null!;
        private TextBox txtUsuario = null!;
        private TextBox txtPassword = null!;
        private CheckBox chkHabilitado = null!;
        private Button btnGuardar = null!;
        private Button btnCancelar = null!;
        private Label lblError = null!;

        public PacienteDetalleForm(PacienteDTO? paciente = null)
        {
            _pacienteExistente = paciente;
            InitializeComponent();
            BuildUI();
            if (_pacienteExistente != null)
            {
                CargarDatos();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(580, 750);
            this.Name = "PacienteDetalleForm";
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Text = _pacienteExistente == null ? "Alta de Paciente - Clínica Odontológica" : "Editar Paciente";
            this.Size = new Size(580, 750);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = UITheme.Background;
            this.Font = UITheme.RegularFont;

            var pnlCard = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = UITheme.CardBackground,
                Padding = new Padding(30, 20, 30, 20),
                AutoScroll = true
            };

            int y = 15;
            int labelWidth = 150;
            int inputWidth = 330;
            int x = 20;

            var pnlHeader = new Panel { Location = new Point(x, y), Size = new Size(490, 50) };
            var lblLogo = new Label { Text = "🦷", Font = new Font("Segoe UI", 18F), Location = new Point(0, 0), AutoSize = true };
            var lblHeader = new Label
            {
                Text = _pacienteExistente == null ? "Registrar Nuevo Paciente" : $"Editar Ficha Médica #{_pacienteExistente.Id}",
                Font = UITheme.LargeTitleFont,
                ForeColor = UITheme.Primary,
                Location = new Point(45, 5),
                AutoSize = true
            };
            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Controls.Add(lblHeader);
            pnlCard.Controls.Add(pnlHeader);
            y += 55;

            void AddRow(string labelText, Control ctrl)
            {
                var lbl = new Label { Text = labelText, Location = new Point(x, y + 3), Size = new Size(labelWidth, 22), Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
                ctrl.Location = new Point(x + labelWidth, y);
                ctrl.Size = new Size(inputWidth, 28);
                pnlCard.Controls.Add(lbl);
                pnlCard.Controls.Add(ctrl);
                y += 38;
            }

            txtNombre = new TextBox();
            AddRow("Nombre *:", txtNombre);

            txtApellido = new TextBox();
            AddRow("Apellido *:", txtApellido);

            var pnlDoc = new Panel { Location = new Point(x + labelWidth, y), Size = new Size(inputWidth, 30) };
            cbTipoDoc = new ComboBox { Location = new Point(0, 0), Size = new Size(95, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            cbTipoDoc.Items.AddRange(new object[] { "DNI", "CUIL", "Pasaporte", "Otros" });
            cbTipoDoc.SelectedIndex = 0;
            txtDni = new TextBox { Location = new Point(105, 0), Size = new Size(inputWidth - 105, 28) };
            pnlDoc.Controls.Add(cbTipoDoc);
            pnlDoc.Controls.Add(txtDni);

            var lblDoc = new Label { Text = "Documento *:", Location = new Point(x, y + 3), Size = new Size(labelWidth, 22), Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            pnlCard.Controls.Add(lblDoc);
            pnlCard.Controls.Add(pnlDoc);
            y += 38;

            dtpFechaNac = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = new DateTime(1995, 1, 1), MaxDate = DateTime.Today };
            AddRow("Fecha Nacimiento:", dtpFechaNac);

            txtTelefono = new TextBox();
            AddRow("Teléfono *:", txtTelefono);

            txtMail = new TextBox();
            AddRow("Correo Electrónico *:", txtMail);

            txtDomicilio = new TextBox();
            AddRow("Domicilio:", txtDomicilio);

            cbObraSocial = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cbObraSocial.Items.AddRange(new object[] {
                "Particular (Sin Obra Social)",
                "OSDE",
                "Swiss Medical",
                "IOMA",
                "IAPOS",
                "Sancor Salud",
                "Federada Salud",
                "Jerárquicos Salud",
                "Galeno",
                "Otra (Especificar)"
            });
            cbObraSocial.SelectedIndex = 0;
            cbObraSocial.SelectedIndexChanged += (s, e) => ToggleOtraObraSocial();
            AddRow("Obra Social *:", cbObraSocial);

            lblOtraOS = new Label { Text = "Especifique Cobertura:", Location = new Point(x, y + 3), Size = new Size(labelWidth, 22), Font = UITheme.RegularBold, ForeColor = UITheme.Primary, Visible = false };
            txtOtraObraSocial = new TextBox { Location = new Point(x + labelWidth, y), Size = new Size(inputWidth, 28), Visible = false, PlaceholderText = "Nombre de su seguro/prepaga..." };
            pnlCard.Controls.Add(lblOtraOS);
            pnlCard.Controls.Add(txtOtraObraSocial);
            y += 38;

            txtAfiliado = new TextBox();
            AddRow("N° de Afiliado / Cred:", txtAfiliado);

            // Sección de Credenciales de Acceso al Portal
            var lblCredHeader = new Label
            {
                Text = "🔑 Credenciales de Acceso (Portal del Paciente)",
                Font = UITheme.RegularBold,
                ForeColor = UITheme.Primary,
                Location = new Point(x, y + 5),
                AutoSize = true
            };
            pnlCard.Controls.Add(lblCredHeader);
            y += 28;

            txtUsuario = new TextBox
            {
                ReadOnly = true,
                BackColor = Color.FromArgb(240, 243, 246),
                Text = _pacienteExistente == null ? "(Se generará automáticamente al guardar)" : (_pacienteExistente.Username ?? "N/A")
            };
            AddRow("Usuario Portal:", txtUsuario);

            txtPassword = new TextBox
            {
                ReadOnly = true,
                BackColor = Color.FromArgb(240, 243, 246),
                Text = _pacienteExistente == null ? "paciente123" : (_pacienteExistente.PasswordDefault ?? "paciente123")
            };
            AddRow("Clave Inicial:", txtPassword);

            chkHabilitado = new CheckBox
            {
                Text = "Paciente Habilitado para Turnos (Sin Deudas)",
                Checked = true,
                Location = new Point(x + labelWidth, y),
                AutoSize = true,
                Font = UITheme.RegularBold,
                ForeColor = UITheme.Success
            };
            chkHabilitado.CheckedChanged += (s, e) =>
            {
                chkHabilitado.ForeColor = chkHabilitado.Checked ? UITheme.Success : UITheme.Danger;
                chkHabilitado.Text = chkHabilitado.Checked ? "Paciente Habilitado para Turnos" : "Paciente Inhabilitado (Bloqueo por Deuda/Falta)";
            };
            pnlCard.Controls.Add(chkHabilitado);
            y += 35;

            lblError = new Label { Text = "", ForeColor = UITheme.Danger, Font = UITheme.SmallFont, Location = new Point(x, y), Size = new Size(490, 30) };
            pnlCard.Controls.Add(lblError);
            y += 35;

            var pnlActions = new Panel { Location = new Point(x + labelWidth, y), Size = new Size(inputWidth, 45) };
            btnGuardar = new Button { Text = "💾 Guardar Paciente", Location = new Point(0, 0), Size = new Size(180, 40) };
            UITheme.StylePrimaryButton(btnGuardar);
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = new Button { Text = "Cancelar", Location = new Point(190, 0), Size = new Size(130, 40) };
            UITheme.StyleSecondaryButton(btnCancelar);
            btnCancelar.Click += (s, e) => this.Close();

            pnlActions.Controls.Add(btnGuardar);
            pnlActions.Controls.Add(btnCancelar);
            pnlCard.Controls.Add(pnlActions);

            this.Controls.Add(pnlCard);
        }

        private void ToggleOtraObraSocial()
        {
            bool isOtra = cbObraSocial.SelectedItem?.ToString() == "Otra (Especificar)";
            lblOtraOS.Visible = isOtra;
            txtOtraObraSocial.Visible = isOtra;
            if (!isOtra) txtOtraObraSocial.Text = "";
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
            txtPassword.Text = _pacienteExistente.PasswordDefault ?? "paciente123";

            if (_pacienteExistente.ObraSocialId.HasValue)
            {
                switch (_pacienteExistente.ObraSocialId.Value)
                {
                    case 1: cbObraSocial.SelectedIndex = 1; break;
                    case 2: cbObraSocial.SelectedIndex = 2; break;
                    case 3: cbObraSocial.SelectedIndex = 3; break;
                    default: cbObraSocial.SelectedIndex = 0; break;
                }
            }
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
                int? osId = cbObraSocial.SelectedIndex switch
                {
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 4
                };

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
