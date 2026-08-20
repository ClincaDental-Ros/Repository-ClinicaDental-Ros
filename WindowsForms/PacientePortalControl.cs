using API.Auth.WindowsForms;
using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class PacientePortalControl : UserControl
    {
        private readonly WindowsFormsAuthService _authService;
        private readonly TurnoApiClient _turnoClient = new();
        private readonly PacienteApiClient _pacienteClient = new();
        private readonly ReportesApiClient _reportesClient = new();
        private readonly MultaApiClient _multaClient = new();

        private TabControl tabPortal = null!;

        // Tab Inicio
        private Panel pnlProximoTurnoCard = null!;
        private Label lblProxDoctor = null!;
        private Label lblProxFecha = null!;
        private Label lblProxUbicacion = null!;
        private Label lblProxEstado = null!;
        private Button btnVerTicket = null!;
        private Button btnReservarTurno = null!;
        private TurnoOdontologicoDTO? _proximoTurno;

        // Tab Mis Turnos
        private DataGridView gridMisTurnos = null!;
        private Button btnCancelarTurno = null!;

        // Tab Historial Clínico
        private Label lblHCPaciente = null!;
        private DataGridView gridHCPaciente = null!;

        // Tab Pagos y Deudas
        private Label lblSaldoDeuda = null!;
        private Label lblEstadoHabilitacion = null!;
        private Button btnPagarDeuda = null!;
        private DataGridView gridMultas = null!;

        // Tab Obra Social
        private Label lblOSNombre = null!;
        private Label lblOSAfiliado = null!;
        private Label lblOSEstado = null!;

        private int _pacienteId = 1; // Default
        private PacienteDTO? _pacienteInfo;
        private List<TurnoOdontologicoDTO> _misTurnos = new();
        private List<MultaDTO> _misMultas = new();

        public PacientePortalControl(WindowsFormsAuthService authService)
        {
            _authService = authService;
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
            this.Name = "PacientePortalControl";
            this.Size = new Size(1000, 680);
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
                Text = "Portal del Paciente - Clínica Odontológica Rosario",
                Font = UITheme.HeaderFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, 12),
                AutoSize = true
            };

            var lblSubtitle = new Label
            {
                Text = "Autogestión de citas, descarga de comprobantes, historial clínico y estado de cuenta",
                Font = UITheme.SmallFont,
                ForeColor = UITheme.TextSecondary,
                Location = new Point(27, 40),
                AutoSize = true
            };

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblSubtitle);

            tabPortal = new TabControl
            {
                Dock = DockStyle.Fill,
                Padding = new Point(16, 8),
                Font = UITheme.RegularBold
            };

            tabPortal.TabPages.Add(CrearTabInicio());
            tabPortal.TabPages.Add(CrearTabMisTurnos());
            tabPortal.TabPages.Add(CrearTabHistorialClinico());
            tabPortal.TabPages.Add(CrearTabPagos());
            tabPortal.TabPages.Add(CrearTabSeguro());

            this.Controls.Add(tabPortal);
            this.Controls.Add(pnlTop);
        }

        public void SeleccionarPestaña(int index)
        {
            if (index >= 0 && index < tabPortal.TabPages.Count)
            {
                tabPortal.SelectedIndex = index;
            }
        }

        private TabPage CrearTabInicio()
        {
            var tab = new TabPage("🏠 Inicio / Próximo Turno") { BackColor = UITheme.Background, AutoScroll = true, Padding = new Padding(25) };

            int y = 20;

            var lblBienvenida = new Label
            {
                Text = $"¡Hola, {_authService.GetNombreCompleto() ?? "Paciente"}! Bienvenido a tu portal de salud dental.",
                Font = UITheme.LargeTitleFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, y),
                AutoSize = true
            };
            tab.Controls.Add(lblBienvenida);
            y += 40;

            // Hero Card Próximo Turno (Inspirada en el MVC next-turno-card)
            pnlProximoTurnoCard = new Panel
            {
                Location = new Point(25, y),
                Size = new Size(720, 165),
                BackColor = UITheme.Primary,
                Padding = new Padding(25, 20, 25, 20)
            };

            var lblCardTitle = new Label { Text = "PRÓXIMO TURNO ODONTOLÓGICO", ForeColor = Color.FromArgb(200, 225, 255), Font = UITheme.SmallBold, Location = new Point(25, 15), AutoSize = true };
            lblProxDoctor = new Label { Text = "Profesional: Dra. Karina González", ForeColor = Color.White, Font = new Font("Segoe UI", 14F, FontStyle.Bold), Location = new Point(25, 38), AutoSize = true };
            lblProxFecha = new Label { Text = "Fecha y Hora: 20/08/2026 a las 09:30 hs", ForeColor = Color.FromArgb(230, 240, 255), Font = UITheme.RegularBold, Location = new Point(25, 72), AutoSize = true };
            lblProxUbicacion = new Label { Text = "Ubicación: Consultorio 3 • Piso 1, Sede Rosario", ForeColor = Color.FromArgb(200, 225, 255), Font = UITheme.SmallFont, Location = new Point(25, 96), AutoSize = true };
            lblProxEstado = new Label { Text = "ESTADO: CONFIRMADO", ForeColor = Color.FromArgb(52, 211, 153), Font = UITheme.SmallBold, Location = new Point(25, 120), AutoSize = true };

            btnVerTicket = new Button { Text = "🧾 Ver Ticket Digital", Location = new Point(530, 60), Size = new Size(160, 42) };
            UITheme.StyleSuccessButton(btnVerTicket);
            btnVerTicket.Click += BtnVerTicket_Click;

            pnlProximoTurnoCard.Controls.Add(lblCardTitle);
            pnlProximoTurnoCard.Controls.Add(lblProxDoctor);
            pnlProximoTurnoCard.Controls.Add(lblProxFecha);
            pnlProximoTurnoCard.Controls.Add(lblProxUbicacion);
            pnlProximoTurnoCard.Controls.Add(lblProxEstado);
            pnlProximoTurnoCard.Controls.Add(btnVerTicket);

            tab.Controls.Add(pnlProximoTurnoCard);
            y += 185;

            // Botón Agendar Nuevo Turno
            btnReservarTurno = new Button
            {
                Text = "📅 + Solicitar y Agendar Nuevo Turno",
                Location = new Point(25, y),
                Size = new Size(320, 46)
            };
            UITheme.StylePrimaryButton(btnReservarTurno);
            btnReservarTurno.Click += (s, e) => AbrirReservaTurno();
            tab.Controls.Add(btnReservarTurno);
            y += 65;

            // Tarjetas de Especialidades disponibles
            var lblEsp = new Label { Text = "Nuestras Especialidades de Atención:", Font = UITheme.SubheaderFont, ForeColor = UITheme.TextPrimary, Location = new Point(25, y), AutoSize = true };
            tab.Controls.Add(lblEsp);
            y += 30;

            var pnlEspBoxes = new FlowLayoutPanel { Location = new Point(25, y), Size = new Size(720, 100), AutoScroll = true };
            void AddEspBox(string name, string icon)
            {
                var box = new Panel { Size = new Size(165, 80), BackColor = Color.White, Margin = new Padding(0, 0, 12, 0), Padding = new Padding(10) };
                box.Paint += (s, e) =>
                {
                    using var pen = new Pen(UITheme.BorderColor, 1);
                    e.Graphics.DrawRectangle(pen, 0, 0, box.Width - 1, box.Height - 1);
                };
                var ic = new Label { Text = icon, Font = new Font("Segoe UI", 14F), Location = new Point(10, 8), AutoSize = true };
                var nm = new Label { Text = name, Font = UITheme.RegularBold, ForeColor = UITheme.Primary, Location = new Point(10, 42), AutoSize = true };
                box.Controls.Add(ic);
                box.Controls.Add(nm);
                pnlEspBoxes.Controls.Add(box);
            }

            AddEspBox("Odontología Gral.", "🦷");
            AddEspBox("Ortodoncia", "😁");
            AddEspBox("Endodoncia", "🔬");
            AddEspBox("Implantología", "🛠️");

            tab.Controls.Add(pnlEspBoxes);

            return tab;
        }

        private TabPage CrearTabMisTurnos()
        {
            var tab = new TabPage("📅 Mis Turnos") { BackColor = UITheme.Background };

            var pnlBar = new Panel { Dock = DockStyle.Top, Height = 65, Padding = new Padding(25, 12, 25, 12), BackColor = UITheme.CardBackground };
            var btnNuevo = new Button { Text = "📅 Agendar Turno", Location = new Point(25, 13), Size = new Size(170, 36) };
            UITheme.StyleSuccessButton(btnNuevo);
            btnNuevo.Click += (s, e) => AbrirReservaTurno();

            btnCancelarTurno = new Button { Text = "❌ Cancelar Turno", Location = new Point(205, 13), Size = new Size(160, 36) };
            UITheme.StyleDangerButton(btnCancelarTurno);
            btnCancelarTurno.Click += BtnCancelarTurno_Click;

            var btnRefrescar = new Button { Text = "🔄 Actualizar", Location = new Point(375, 13), Size = new Size(120, 36) };
            UITheme.StyleSecondaryButton(btnRefrescar);
            btnRefrescar.Click += async (s, e) => await CargarDatos();

            pnlBar.Controls.Add(btnNuevo);
            pnlBar.Controls.Add(btnCancelarTurno);
            pnlBar.Controls.Add(btnRefrescar);

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 15, 25, 15) };
            gridMisTurnos = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridMisTurnos);
            gridMisTurnos.AutoGenerateColumns = false;

            gridMisTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha", Width = 120 });
            gridMisTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Hora", HeaderText = "Horario", Width = 90, DataPropertyName = "HorarioTurno" });
            gridMisTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Doctor", HeaderText = "Profesional Odontólogo", Width = 230, DataPropertyName = "OdontologoNombre" });
            gridMisTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Especialidad", HeaderText = "Especialidad", Width = 200, DataPropertyName = "EspecialidadNombre" });
            gridMisTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", Width = 150, DataPropertyName = "EstadoTurno" });

            gridMisTurnos.CellFormatting += (s, e) =>
            {
                if (gridMisTurnos.Columns[e.ColumnIndex].Name == "Fecha" && e.RowIndex >= 0 && e.RowIndex < _misTurnos.Count)
                {
                    e.Value = _misTurnos[e.RowIndex].Fecha.ToString("dd/MM/yyyy");
                }
            };

            pnlGrid.Controls.Add(gridMisTurnos);

            tab.Controls.Add(pnlGrid);
            tab.Controls.Add(pnlBar);
            return tab;
        }

        private TabPage CrearTabHistorialClinico()
        {
            var tab = new TabPage("📋 Mi Historial Clínico") { BackColor = UITheme.Background };

            lblHCPaciente = new Label
            {
                Dock = DockStyle.Top,
                Height = 75,
                Padding = new Padding(25, 15, 25, 10),
                BackColor = UITheme.CardBackground,
                Font = UITheme.RegularFont,
                Text = "Cargando antecedentes médicos..."
            };

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 15, 25, 15) };
            gridHCPaciente = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridHCPaciente);
            gridHCPaciente.AutoGenerateColumns = false;

            gridHCPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha de Atención", Width = 130 });
            gridHCPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "Doctor", HeaderText = "Odontólogo", Width = 220, DataPropertyName = "OdontologoNombre" });
            gridHCPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "Diagnostico", HeaderText = "Diagnóstico (CIE-10)", Width = 240, DataPropertyName = "Diagnostico" });
            gridHCPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tratamiento", HeaderText = "Tratamiento Realizado", Width = 240, DataPropertyName = "Tratamiento" });
            gridHCPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "Observaciones", HeaderText = "Observaciones Médicas", DataPropertyName = "Observaciones" });

            pnlGrid.Controls.Add(gridHCPaciente);

            tab.Controls.Add(pnlGrid);
            tab.Controls.Add(lblHCPaciente);
            return tab;
        }

        private TabPage CrearTabPagos()
        {
            var tab = new TabPage("💳 Métodos de Pago y Saldo") { BackColor = UITheme.Background, AutoScroll = true, Padding = new Padding(25) };

            int y = 20;

            // Balance Card (Inspirado en MetodosDePago.cshtml)
            var pnlBalance = new Panel
            {
                Location = new Point(25, y),
                Size = new Size(720, 140),
                BackColor = UITheme.Primary,
                Padding = new Padding(25)
            };

            var lblBalTitle = new Label { Text = "ESTADO DE CUENTA Y SALDO", ForeColor = Color.FromArgb(200, 225, 255), Font = UITheme.SmallBold, Location = new Point(25, 15), AutoSize = true };
            lblSaldoDeuda = new Label { Text = "Saldo Deudor Pendiente: $0.00", ForeColor = Color.White, Font = new Font("Segoe UI", 16F, FontStyle.Bold), Location = new Point(25, 42), AutoSize = true };
            lblEstadoHabilitacion = new Label { Text = "ESTADO: HABILITADO PARA RESERVAS", ForeColor = Color.FromArgb(52, 211, 153), Font = UITheme.RegularBold, Location = new Point(25, 85), AutoSize = true };

            btnPagarDeuda = new Button { Text = "💳 Pagar Deuda / Multa", Location = new Point(510, 45), Size = new Size(180, 42), Visible = false };
            UITheme.StyleSuccessButton(btnPagarDeuda);
            btnPagarDeuda.Click += BtnPagarDeuda_Click;

            pnlBalance.Controls.Add(lblBalTitle);
            pnlBalance.Controls.Add(lblSaldoDeuda);
            pnlBalance.Controls.Add(lblEstadoHabilitacion);
            pnlBalance.Controls.Add(btnPagarDeuda);

            tab.Controls.Add(pnlBalance);
            y += 160;

            var lblMultasTitle = new Label { Text = "Detalle de Multas por Inasistencia o Cargos Pendientes:", Font = UITheme.SubheaderFont, ForeColor = UITheme.TextPrimary, Location = new Point(25, y), AutoSize = true };
            tab.Controls.Add(lblMultasTitle);
            y += 30;

            gridMultas = new DataGridView { Location = new Point(25, y), Size = new Size(720, 180) };
            UITheme.StyleDataGridView(gridMultas);
            gridMultas.AutoGenerateColumns = false;
            gridMultas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID Multa", Width = 80, DataPropertyName = "Id" });
            gridMultas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Monto", HeaderText = "Monto ($)", Width = 120, DataPropertyName = "Monto" });
            gridMultas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Motivo", HeaderText = "Concepto / Motivo", Width = 340, DataPropertyName = "Motivo" });
            gridMultas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Pagada", HeaderText = "Estado", Width = 140 });

            gridMultas.CellFormatting += (s, e) =>
            {
                if (gridMultas.Columns[e.ColumnIndex].Name == "Pagada" && e.RowIndex >= 0 && e.RowIndex < _misMultas.Count)
                {
                    e.Value = _misMultas[e.RowIndex].EstadoPago ? "✅ Pagada" : "❌ Impaga";
                    if (e.CellStyle != null)
                    {
                        e.CellStyle.ForeColor = _misMultas[e.RowIndex].EstadoPago ? UITheme.Success : UITheme.Danger;
                        e.CellStyle.Font = UITheme.RegularBold;
                    }
                }
            };

            tab.Controls.Add(gridMultas);
            y += 205;

            // ==========================================
            // SECCIÓN: TARJETAS Y MEDIOS DE PAGO GUARDADOS
            // ==========================================
            var lblTarjetasTitle = new Label { Text = "Mis Tarjetas y Medios de Pago Registrados:", Font = UITheme.SubheaderFont, ForeColor = UITheme.Primary, Location = new Point(25, y), AutoSize = true };
            tab.Controls.Add(lblTarjetasTitle);
            y += 28;

            var pnlTarjetas = new Panel { Location = new Point(25, y), Size = new Size(720, 160), BackColor = Color.White, Padding = new Padding(15) };
            pnlTarjetas.Paint += (s, e) =>
            {
                using var pen = new Pen(UITheme.BorderColor, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlTarjetas.Width - 1, pnlTarjetas.Height - 1);
            };

            var lstTarjetas = new ListBox { Location = new Point(15, 15), Size = new Size(500, 125), Font = UITheme.RegularFont };
            lstTarjetas.Items.Add("💳 Visa Débito **** 4321 • Banco Santander (Predeterminada)");
            lstTarjetas.Items.Add("💳 Mastercard Crédito **** 8890 • Banco Galicia");
            lstTarjetas.Items.Add("📱 Billetera Virtual MercadoPago • juan.perez@email.com");
            lstTarjetas.SelectedIndex = 0;

            var btnAgregarTarjeta = new Button { Text = "+ Agregar Tarjeta", Location = new Point(530, 15), Size = new Size(170, 38) };
            UITheme.StylePrimaryButton(btnAgregarTarjeta);
            btnAgregarTarjeta.Click += (s, e) => AbrirModalNuevaTarjeta(lstTarjetas);

            var btnEliminarTarjeta = new Button { Text = "🗑️ Eliminar", Location = new Point(530, 60), Size = new Size(170, 38) };
            UITheme.StyleDangerButton(btnEliminarTarjeta);
            btnEliminarTarjeta.Click += (s, e) =>
            {
                if (lstTarjetas.SelectedIndex >= 0)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar este medio de pago?", "Clínica Odontológica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        lstTarjetas.Items.RemoveAt(lstTarjetas.SelectedIndex);
                    }
                }
            };

            pnlTarjetas.Controls.Add(lstTarjetas);
            pnlTarjetas.Controls.Add(btnAgregarTarjeta);
            pnlTarjetas.Controls.Add(btnEliminarTarjeta);

            tab.Controls.Add(pnlTarjetas);

            return tab;
        }

        private void AbrirModalNuevaTarjeta(ListBox lstTarjetas)
        {
            var formModal = new Form
            {
                Text = "Alta de Nuevo Medio de Pago - Clínica Odontológica",
                Size = new Size(460, 480),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.White,
                Font = UITheme.RegularFont
            };

            var pnlH = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = UITheme.Primary, Padding = new Padding(20, 15, 20, 10) };
            var lblT = new Label { Text = "💳 Registrar Tarjeta / Medio de Pago", ForeColor = Color.White, Font = UITheme.HeaderFont, AutoSize = true };
            pnlH.Controls.Add(lblT);

            int my = 20;
            int lx = 25;
            var pnlB = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 20, 25, 20) };

            void AddFormRow(string label, Control ctrl)
            {
                var l = new Label { Text = label, Location = new Point(lx, my), AutoSize = true, Font = UITheme.SmallBold, ForeColor = UITheme.TextPrimary };
                ctrl.Location = new Point(lx, my + 20);
                ctrl.Size = new Size(390, 28);
                pnlB.Controls.Add(l);
                pnlB.Controls.Add(ctrl);
                my += 55;
            }

            var cbTipo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cbTipo.Items.AddRange(new object[] { "Tarjeta de Débito", "Tarjeta de Crédito", "Billetera Virtual" });
            cbTipo.SelectedIndex = 0;
            AddFormRow("Tipo de Medio de Pago *:", cbTipo);

            var txtTitular = new TextBox { PlaceholderText = "Nombre como figura en el plástico" };
            AddFormRow("Titular de la Tarjeta *:", txtTitular);

            var txtNumero = new TextBox { PlaceholderText = "XXXX XXXX XXXX XXXX", MaxLength = 19 };
            AddFormRow("Número de Tarjeta (16 dígitos) *:", txtNumero);

            var pnlExpCvv = new Panel { Location = new Point(lx, my), Size = new Size(390, 50) };
            var lblExp = new Label { Text = "Vencimiento (MM/AA):", Location = new Point(0, 0), AutoSize = true, Font = UITheme.SmallBold };
            var txtExp = new TextBox { Location = new Point(0, 20), Width = 180, PlaceholderText = "12/28", MaxLength = 5 };
            var lblCvv = new Label { Text = "CVV (3 dígitos):", Location = new Point(200, 0), AutoSize = true, Font = UITheme.SmallBold };
            var txtCvv = new TextBox { Location = new Point(200, 20), Width = 180, PlaceholderText = "123", MaxLength = 4, UseSystemPasswordChar = true };

            pnlExpCvv.Controls.Add(lblExp);
            pnlExpCvv.Controls.Add(txtExp);
            pnlExpCvv.Controls.Add(lblCvv);
            pnlExpCvv.Controls.Add(txtCvv);
            pnlB.Controls.Add(pnlExpCvv);
            my += 55;

            var btnGuardar = new Button { Text = "💾 Guardar Medio de Pago", Location = new Point(lx, my + 10), Size = new Size(230, 40) };
            UITheme.StyleSuccessButton(btnGuardar);
            btnGuardar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTitular.Text) || string.IsNullOrWhiteSpace(txtNumero.Text) || txtNumero.Text.Trim().Length < 4)
                {
                    MessageBox.Show("Por favor complete los datos obligatorios de la tarjeta.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ultimos4 = txtNumero.Text.Trim().Length >= 4 ? txtNumero.Text.Trim().Substring(txtNumero.Text.Trim().Length - 4) : "0000";
                var nuevoItem = $"💳 {cbTipo.SelectedItem} **** {ultimos4} • {txtTitular.Text.Trim()}";
                lstTarjetas.Items.Add(nuevoItem);

                MessageBox.Show("¡Medio de pago agregado correctamente a tu cuenta!", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                formModal.Close();
            };

            var btnCerrar = new Button { Text = "Cancelar", Location = new Point(lx + 245, my + 10), Size = new Size(145, 40) };
            UITheme.StyleSecondaryButton(btnCerrar);
            btnCerrar.Click += (s, e) => formModal.Close();

            pnlB.Controls.Add(btnGuardar);
            pnlB.Controls.Add(btnCerrar);

            formModal.Controls.Add(pnlB);
            formModal.Controls.Add(pnlH);
            formModal.ShowDialog();
        }

        private TabPage CrearTabSeguro()
        {
            var tab = new TabPage("🛡️ Mi Obra Social") { BackColor = UITheme.Background, Padding = new Padding(25) };

            var pnlCard = new Panel { Location = new Point(25, 25), Size = new Size(600, 240), BackColor = Color.White, Padding = new Padding(25) };
            pnlCard.Paint += (s, e) =>
            {
                using var pen = new Pen(UITheme.BorderColor, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
            };

            var lblH = new Label { Text = "🛡️ Cobertura Médica y Prepaga Registrada", Font = UITheme.LargeTitleFont, ForeColor = UITheme.Primary, Location = new Point(25, 20), AutoSize = true };
            lblOSNombre = new Label { Text = "Obra Social: OSDE (Plan 210)", Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary, Location = new Point(25, 75), AutoSize = true };
            lblOSAfiliado = new Label { Text = "N° de Afiliado / Credencial: 987456321", Font = UITheme.RegularFont, ForeColor = UITheme.TextPrimary, Location = new Point(25, 110), AutoSize = true };
            lblOSEstado = new Label { Text = "Estado de Cobertura: ACTIVA (100% Cobertura en consultas preventivas)", Font = UITheme.RegularBold, ForeColor = UITheme.Success, Location = new Point(25, 145), AutoSize = true };

            var lblAviso = new Label { Text = "ℹ️ Para actualizar tu obra social o presentar una nueva credencial, presentate en Recepción.", Font = UITheme.SmallFont, ForeColor = UITheme.TextSecondary, Location = new Point(25, 190), AutoSize = true };

            pnlCard.Controls.Add(lblH);
            pnlCard.Controls.Add(lblOSNombre);
            pnlCard.Controls.Add(lblOSAfiliado);
            pnlCard.Controls.Add(lblOSEstado);
            pnlCard.Controls.Add(lblAviso);

            tab.Controls.Add(pnlCard);
            return tab;
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarDatos();
        }

        public async Task CargarDatos()
        {
            try
            {
                var username = _authService.GetUsername() ?? "paciente1";
                var pacientes = await _pacienteClient.GetAllAsync();
                _pacienteInfo = pacientes.FirstOrDefault(p => p.Mail.Contains(username, StringComparison.OrdinalIgnoreCase) || p.Nombre.Contains("Juan", StringComparison.OrdinalIgnoreCase)) ?? pacientes.FirstOrDefault();

                if (_pacienteInfo != null)
                {
                    _pacienteId = _pacienteInfo.Id;

                    lblOSNombre.Text = $"Obra Social: {_pacienteInfo.ObraSocialNombre}";
                    lblOSAfiliado.Text = $"N° de Afiliado / Credencial: {_pacienteInfo.NumeroAfiliado ?? "S/D"}";
                }

                // Cargar Turnos
                var allTurnos = await _turnoClient.GetByCriteriaAsync(new TurnoCriteriaDTO { PacienteId = _pacienteId });
                _misTurnos = allTurnos;
                gridMisTurnos.DataSource = null;
                gridMisTurnos.DataSource = _misTurnos;

                _proximoTurno = _misTurnos.Where(t => t.Fecha >= DateTime.Today && t.EstadoTurno != "Cancelado").OrderBy(t => t.Fecha).FirstOrDefault();

                if (_proximoTurno != null)
                {
                    lblProxDoctor.Text = $"Profesional: {_proximoTurno.OdontologoNombre}";
                    lblProxFecha.Text = $"Fecha y Hora: {_proximoTurno.Fecha:dd/MM/yyyy} a las {_proximoTurno.HorarioTurno} hs";
                    lblProxEstado.Text = $"ESTADO: {_proximoTurno.EstadoTurno.ToUpper()}";
                    btnVerTicket.Visible = true;
                }
                else
                {
                    lblProxDoctor.Text = "No tienes turnos próximos agendados.";
                    lblProxFecha.Text = "Presiona el botón de abajo para solicitar una cita.";
                    lblProxEstado.Text = "";
                    btnVerTicket.Visible = false;
                }

                // Cargar Historia Clínica
                var hc = await _reportesClient.GetHistoriaClinicaAsync(_pacienteId);
                if (hc != null)
                {
                    lblHCPaciente.Text = $"📋 Historia Clínica N° {hc.NumeroHistoriaClinica:D5} - {hc.PacienteNombre}\n" +
                                         $"• Antecedentes: {hc.AntecedentesMedicos} | Alergias: {hc.Alergias}";
                    gridHCPaciente.DataSource = hc.ConsultasPrevias;
                }

                // Cargar Multas / Deudas
                _misMultas = await _multaClient.GetAllAsync(_pacienteId);
                gridMultas.DataSource = null;
                gridMultas.DataSource = _misMultas;

                var impagas = _misMultas.Where(m => !m.EstadoPago).ToList();
                decimal deudaTotal = impagas.Sum(m => m.Monto);

                if (deudaTotal > 0)
                {
                    lblSaldoDeuda.Text = $"Saldo Deudor Pendiente: {deudaTotal:C2}";
                    lblEstadoHabilitacion.Text = "ESTADO: INHABILITADO PARA NUEVOS TURNOS (Registra multas impagas)";
                    lblEstadoHabilitacion.ForeColor = Color.FromArgb(248, 113, 113);
                    btnPagarDeuda.Visible = true;
                }
                else
                {
                    lblSaldoDeuda.Text = "Saldo Deudor Pendiente: $ 0,00 (Al día)";
                    lblEstadoHabilitacion.Text = "ESTADO: HABILITADO PARA RESERVAS";
                    lblEstadoHabilitacion.ForeColor = Color.FromArgb(52, 211, 153);
                    btnPagarDeuda.Visible = false;
                }
            }
            catch { }
        }

        private void AbrirReservaTurno()
        {
            var form = new TurnoReservaForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = CargarDatos();
            }
        }

        private void BtnVerTicket_Click(object? sender, EventArgs e)
        {
            if (_proximoTurno == null) return;

            var formTicket = new Form
            {
                Text = "Comprobante de Turno - Clínica Odontológica",
                Size = new Size(480, 520),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.White
            };

            var pnlH = new Panel { Dock = DockStyle.Top, Height = 100, BackColor = UITheme.Primary, Padding = new Padding(20) };
            var lblT1 = new Label { Text = "🦷 Clínica Odontológica Rosario", ForeColor = Color.White, Font = UITheme.LargeTitleFont, Location = new Point(20, 15), AutoSize = true };
            var lblT2 = new Label { Text = "COMPROBANTE DE ATENCIÓN / TICKET DIGITAL", ForeColor = UITheme.PrimaryLight, Font = UITheme.SmallBold, Location = new Point(22, 55), AutoSize = true };
            pnlH.Controls.Add(lblT1);
            pnlH.Controls.Add(lblT2);

            var pnlBody = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25) };
            var lblCodigo = new Label { Text = $"CÓDIGO DE RESERVA: TM-{_proximoTurno.Id:D5}", Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = UITheme.Primary, Location = new Point(25, 15), AutoSize = true };

            int y = 50;
            void AddDetail(string label, string? val)
            {
                var l1 = new Label { Text = label, Location = new Point(25, y), Size = new Size(140, 20), Font = UITheme.SmallBold, ForeColor = UITheme.TextSecondary };
                var l2 = new Label { Text = val ?? "N/A", Location = new Point(170, y), Size = new Size(260, 20), Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
                pnlBody.Controls.Add(l1);
                pnlBody.Controls.Add(l2);
                y += 28;
            }

            AddDetail("PACIENTE:", _proximoTurno.PacienteNombre);
            AddDetail("PROFESIONAL:", _proximoTurno.OdontologoNombre);
            AddDetail("ESPECIALIDAD:", _proximoTurno.EspecialidadNombre);
            AddDetail("FECHA Y HORA:", $"{_proximoTurno.Fecha:dd/MM/yyyy} a las {_proximoTurno.HorarioTurno}");
            AddDetail("UBICACIÓN:", "Consultorio 3 - Piso 1, Sede Rosario");
            AddDetail("ESTADO:", "RESERVA CONFIRMADA (Citado)");

            var btnCerrar = new Button { Text = "Imprimir / Aceptar", Location = new Point(130, y + 20), Size = new Size(180, 38) };
            UITheme.StyleSuccessButton(btnCerrar);
            btnCerrar.Click += (s, e) => formTicket.Close();

            pnlBody.Controls.Add(lblCodigo);
            pnlBody.Controls.Add(btnCerrar);

            formTicket.Controls.Add(pnlBody);
            formTicket.Controls.Add(pnlH);
            formTicket.ShowDialog();
        }

        private async void BtnCancelarTurno_Click(object? sender, EventArgs e)
        {
            if (gridMisTurnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un turno para cancelar.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var turno = (TurnoOdontologicoDTO)gridMisTurnos.SelectedRows[0].DataBoundItem;
            if (turno.EstadoTurno == "Cancelado" || turno.EstadoTurno == "Atendido")
            {
                MessageBox.Show($"No se puede cancelar un turno en estado {turno.EstadoTurno}.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Desea cancelar el turno para el {turno.Fecha:dd/MM/yyyy} a las {turno.HorarioTurno}?", "Cancelar Turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _turnoClient.CancelarAsync(turno.Id, "Cancelado por el paciente desde el portal");
                MessageBox.Show("Turno cancelado con éxito.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarDatos();
            }
        }

        private async void BtnPagarDeuda_Click(object? sender, EventArgs e)
        {
            var impaga = _misMultas.FirstOrDefault(m => !m.EstadoPago);
            if (impaga == null) return;

            if (MessageBox.Show($"¿Desea abonar la multa de {impaga.Monto:C2} con su tarjeta guardada para rehabilitar su cuenta?", "Pagar Deuda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _multaClient.PagarAsync(impaga.Id);
                MessageBox.Show("¡Pago procesado con éxito! Tu cuenta ha sido rehabilitada para agendar turnos.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarDatos();
            }
        }
    }
}
