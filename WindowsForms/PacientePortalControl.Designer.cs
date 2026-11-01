#nullable disable

namespace WindowsForms
{
    partial class PacientePortalControl
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.tabPortal = new System.Windows.Forms.TabControl();
            this.tabInicio = new System.Windows.Forms.TabPage();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.pnlProximoTurnoCard = new System.Windows.Forms.Panel();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.lblProxDoctor = new System.Windows.Forms.Label();
            this.lblProxFecha = new System.Windows.Forms.Label();
            this.lblProxEspecialidad = new System.Windows.Forms.Label();
            this.lblProxEstado = new System.Windows.Forms.Label();
            this.btnVerTicket = new System.Windows.Forms.Button();
            this.btnReservarTurno = new System.Windows.Forms.Button();
            this.lblEsp = new System.Windows.Forms.Label();
            this.pnlEspBoxes = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlEspBox1 = new System.Windows.Forms.Panel();
            this.lblEspIcon1 = new System.Windows.Forms.Label();
            this.lblEspName1 = new System.Windows.Forms.Label();
            this.pnlEspBox2 = new System.Windows.Forms.Panel();
            this.lblEspIcon2 = new System.Windows.Forms.Label();
            this.lblEspName2 = new System.Windows.Forms.Label();
            this.pnlEspBox3 = new System.Windows.Forms.Panel();
            this.lblEspIcon3 = new System.Windows.Forms.Label();
            this.lblEspName3 = new System.Windows.Forms.Label();
            this.pnlEspBox4 = new System.Windows.Forms.Panel();
            this.lblEspIcon4 = new System.Windows.Forms.Label();
            this.lblEspName4 = new System.Windows.Forms.Label();
            this.tabMisTurnos = new System.Windows.Forms.TabPage();
            this.pnlGridMisTurnos = new System.Windows.Forms.Panel();
            this.gridMisTurnos = new System.Windows.Forms.DataGridView();
            this.colMisTurnosFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMisTurnosHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMisTurnosDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMisTurnosEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMisTurnosEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBarTurnos = new System.Windows.Forms.Panel();
            this.btnNuevoTurno = new System.Windows.Forms.Button();
            this.btnCancelarTurno = new System.Windows.Forms.Button();
            this.btnRefrescarTurnos = new System.Windows.Forms.Button();
            this.tabHistorialClinico = new System.Windows.Forms.TabPage();
            this.pnlGridHC = new System.Windows.Forms.Panel();
            this.gridHCPaciente = new System.Windows.Forms.DataGridView();
            this.colHCFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCDiagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCTratamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHCPaciente = new System.Windows.Forms.Label();
            this.tabPagos = new System.Windows.Forms.TabPage();
            this.pnlBalance = new System.Windows.Forms.Panel();
            this.lblBalTitle = new System.Windows.Forms.Label();
            this.lblSaldoDeuda = new System.Windows.Forms.Label();
            this.lblEstadoHabilitacion = new System.Windows.Forms.Label();
            this.btnPagarDeuda = new System.Windows.Forms.Button();
            this.lblMultasTitle = new System.Windows.Forms.Label();
            this.gridMultas = new System.Windows.Forms.DataGridView();
            this.colMultaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMultaMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMultaMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMultaPagada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTarjetasTitle = new System.Windows.Forms.Label();
            this.pnlTarjetas = new System.Windows.Forms.Panel();
            this.lstTarjetas = new System.Windows.Forms.ListBox();
            this.btnAgregarTarjeta = new System.Windows.Forms.Button();
            this.btnEliminarTarjeta = new System.Windows.Forms.Button();
            this.tabSeguro = new System.Windows.Forms.TabPage();
            this.pnlSeguroCard = new System.Windows.Forms.Panel();
            this.lblSeguroHeader = new System.Windows.Forms.Label();
            this.lblOSNombre = new System.Windows.Forms.Label();
            this.lblOSAfiliado = new System.Windows.Forms.Label();
            this.lblOSEstado = new System.Windows.Forms.Label();
            this.lblSeguroAviso = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.tabPortal.SuspendLayout();
            this.tabInicio.SuspendLayout();
            this.pnlProximoTurnoCard.SuspendLayout();
            this.pnlEspBoxes.SuspendLayout();
            this.pnlEspBox1.SuspendLayout();
            this.pnlEspBox2.SuspendLayout();
            this.pnlEspBox3.SuspendLayout();
            this.pnlEspBox4.SuspendLayout();
            this.tabMisTurnos.SuspendLayout();
            this.pnlGridMisTurnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMisTurnos)).BeginInit();
            this.pnlBarTurnos.SuspendLayout();
            this.tabHistorialClinico.SuspendLayout();
            this.pnlGridHC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHCPaciente)).BeginInit();
            this.tabPagos.SuspendLayout();
            this.pnlBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMultas)).BeginInit();
            this.pnlTarjetas.SuspendLayout();
            this.tabSeguro.SuspendLayout();
            this.pnlSeguroCard.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblSubtitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);
            this.pnlTop.Size = new System.Drawing.Size(1000, 70);
            this.pnlTop.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblTitle.Location = new System.Drawing.Point(25, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(422, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Portal del Paciente - Clínica Odontológica Rosario";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(27, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(450, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Autogestión de citas, descarga de comprobantes, historial clínico y estado de cuenta";
            //
            // tabPortal
            //
            this.tabPortal.Controls.Add(this.tabInicio);
            this.tabPortal.Controls.Add(this.tabMisTurnos);
            this.tabPortal.Controls.Add(this.tabHistorialClinico);
            this.tabPortal.Controls.Add(this.tabPagos);
            this.tabPortal.Controls.Add(this.tabSeguro);
            this.tabPortal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPortal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabPortal.Location = new System.Drawing.Point(0, 70);
            this.tabPortal.Name = "tabPortal";
            this.tabPortal.Padding = new System.Drawing.Point(16, 8);
            this.tabPortal.SelectedIndex = 0;
            this.tabPortal.Size = new System.Drawing.Size(1000, 610);
            this.tabPortal.TabIndex = 1;
            //
            // tabInicio
            //
            this.tabInicio.AutoScroll = true;
            this.tabInicio.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.tabInicio.Controls.Add(this.lblBienvenida);
            this.tabInicio.Controls.Add(this.pnlProximoTurnoCard);
            this.tabInicio.Controls.Add(this.btnReservarTurno);
            this.tabInicio.Controls.Add(this.lblEsp);
            this.tabInicio.Controls.Add(this.pnlEspBoxes);
            this.tabInicio.Location = new System.Drawing.Point(4, 34);
            this.tabInicio.Name = "tabInicio";
            this.tabInicio.Padding = new System.Windows.Forms.Padding(25);
            this.tabInicio.Size = new System.Drawing.Size(992, 572);
            this.tabInicio.TabIndex = 0;
            this.tabInicio.Text = "🏠 Inicio / Próximo Turno";
            //
            // lblBienvenida
            //
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblBienvenida.Location = new System.Drawing.Point(25, 20);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(555, 28);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "¡Hola, Paciente! Bienvenido a tu portal de salud dental.";
            //
            // pnlProximoTurnoCard
            //
            this.pnlProximoTurnoCard.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.pnlProximoTurnoCard.Controls.Add(this.lblCardTitle);
            this.pnlProximoTurnoCard.Controls.Add(this.lblProxDoctor);
            this.pnlProximoTurnoCard.Controls.Add(this.lblProxFecha);
            this.pnlProximoTurnoCard.Controls.Add(this.lblProxEspecialidad);
            this.pnlProximoTurnoCard.Controls.Add(this.lblProxEstado);
            this.pnlProximoTurnoCard.Controls.Add(this.btnVerTicket);
            this.pnlProximoTurnoCard.Location = new System.Drawing.Point(25, 60);
            this.pnlProximoTurnoCard.Name = "pnlProximoTurnoCard";
            this.pnlProximoTurnoCard.Padding = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.pnlProximoTurnoCard.Size = new System.Drawing.Size(720, 165);
            this.pnlProximoTurnoCard.TabIndex = 1;
            //
            // lblCardTitle
            //
            this.lblCardTitle.AutoSize = true;
            this.lblCardTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardTitle.ForeColor = System.Drawing.Color.FromArgb(200, 225, 255);
            this.lblCardTitle.Location = new System.Drawing.Point(25, 15);
            this.lblCardTitle.Name = "lblCardTitle";
            this.lblCardTitle.Size = new System.Drawing.Size(195, 15);
            this.lblCardTitle.TabIndex = 0;
            this.lblCardTitle.Text = "PRÓXIMO TURNO ODONTOLÓGICO";
            //
            // lblProxDoctor
            //
            this.lblProxDoctor.AutoSize = true;
            this.lblProxDoctor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProxDoctor.ForeColor = System.Drawing.Color.White;
            this.lblProxDoctor.Location = new System.Drawing.Point(25, 38);
            this.lblProxDoctor.Name = "lblProxDoctor";
            this.lblProxDoctor.Size = new System.Drawing.Size(317, 25);
            this.lblProxDoctor.TabIndex = 1;
            this.lblProxDoctor.Text = "Profesional: Dra. Karina González";
            //
            // lblProxFecha
            //
            this.lblProxFecha.AutoSize = true;
            this.lblProxFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProxFecha.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.lblProxFecha.Location = new System.Drawing.Point(25, 72);
            this.lblProxFecha.Name = "lblProxFecha";
            this.lblProxFecha.Size = new System.Drawing.Size(262, 17);
            this.lblProxFecha.TabIndex = 2;
            this.lblProxFecha.Text = "Fecha y Hora: 20/08/2026 a las 09:30 hs";
            //
            // lblProxEspecialidad
            //
            this.lblProxEspecialidad.AutoSize = true;
            this.lblProxEspecialidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProxEspecialidad.ForeColor = System.Drawing.Color.FromArgb(200, 225, 255);
            this.lblProxEspecialidad.Location = new System.Drawing.Point(25, 96);
            this.lblProxEspecialidad.Name = "lblProxEspecialidad";
            this.lblProxEspecialidad.Size = new System.Drawing.Size(0, 15);
            this.lblProxEspecialidad.TabIndex = 3;
            //
            // lblProxEstado
            //
            this.lblProxEstado.AutoSize = true;
            this.lblProxEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProxEstado.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153);
            this.lblProxEstado.Location = new System.Drawing.Point(25, 120);
            this.lblProxEstado.Name = "lblProxEstado";
            this.lblProxEstado.Size = new System.Drawing.Size(134, 15);
            this.lblProxEstado.TabIndex = 4;
            this.lblProxEstado.Text = "ESTADO: CONFIRMADO";
            //
            // btnVerTicket
            //
            this.btnVerTicket.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnVerTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerTicket.FlatAppearance.BorderSize = 0;
            this.btnVerTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTicket.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVerTicket.ForeColor = System.Drawing.Color.White;
            this.btnVerTicket.Location = new System.Drawing.Point(530, 60);
            this.btnVerTicket.Name = "btnVerTicket";
            this.btnVerTicket.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnVerTicket.Size = new System.Drawing.Size(160, 42);
            this.btnVerTicket.TabIndex = 5;
            this.btnVerTicket.Text = "🧾 Ver Ticket Digital";
            this.btnVerTicket.UseVisualStyleBackColor = false;
            this.btnVerTicket.Click += new System.EventHandler(this.BtnVerTicket_Click);
            //
            // btnReservarTurno
            //
            this.btnReservarTurno.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnReservarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservarTurno.FlatAppearance.BorderSize = 0;
            this.btnReservarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservarTurno.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReservarTurno.ForeColor = System.Drawing.Color.White;
            this.btnReservarTurno.Location = new System.Drawing.Point(25, 245);
            this.btnReservarTurno.Name = "btnReservarTurno";
            this.btnReservarTurno.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnReservarTurno.Size = new System.Drawing.Size(320, 46);
            this.btnReservarTurno.TabIndex = 2;
            this.btnReservarTurno.Text = "📅 + Solicitar y Agendar Nuevo Turno";
            this.btnReservarTurno.UseVisualStyleBackColor = false;
            this.btnReservarTurno.Click += new System.EventHandler(this.BtnReservarTurno_Click);
            //
            // lblEsp
            //
            this.lblEsp.AutoSize = true;
            this.lblEsp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEsp.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblEsp.Location = new System.Drawing.Point(25, 310);
            this.lblEsp.Name = "lblEsp";
            this.lblEsp.Size = new System.Drawing.Size(268, 19);
            this.lblEsp.TabIndex = 3;
            this.lblEsp.Text = "Nuestras Especialidades de Atención:";
            //
            // pnlEspBoxes
            //
            this.pnlEspBoxes.AutoScroll = true;
            this.pnlEspBoxes.Controls.Add(this.pnlEspBox1);
            this.pnlEspBoxes.Controls.Add(this.pnlEspBox2);
            this.pnlEspBoxes.Controls.Add(this.pnlEspBox3);
            this.pnlEspBoxes.Controls.Add(this.pnlEspBox4);
            this.pnlEspBoxes.Location = new System.Drawing.Point(25, 340);
            this.pnlEspBoxes.Name = "pnlEspBoxes";
            this.pnlEspBoxes.Size = new System.Drawing.Size(720, 100);
            this.pnlEspBoxes.TabIndex = 4;
            //
            // pnlEspBox1
            //
            this.pnlEspBox1.BackColor = System.Drawing.Color.White;
            this.pnlEspBox1.Controls.Add(this.lblEspIcon1);
            this.pnlEspBox1.Controls.Add(this.lblEspName1);
            this.pnlEspBox1.Location = new System.Drawing.Point(0, 0);
            this.pnlEspBox1.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlEspBox1.Name = "pnlEspBox1";
            this.pnlEspBox1.Padding = new System.Windows.Forms.Padding(10);
            this.pnlEspBox1.Size = new System.Drawing.Size(165, 80);
            this.pnlEspBox1.TabIndex = 0;
            this.pnlEspBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBorder_Paint);
            //
            // lblEspIcon1
            //
            this.lblEspIcon1.AutoSize = true;
            this.lblEspIcon1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEspIcon1.Location = new System.Drawing.Point(10, 8);
            this.lblEspIcon1.Name = "lblEspIcon1";
            this.lblEspIcon1.Size = new System.Drawing.Size(35, 25);
            this.lblEspIcon1.TabIndex = 0;
            this.lblEspIcon1.Text = "🦷";
            //
            // lblEspName1
            //
            this.lblEspName1.AutoSize = true;
            this.lblEspName1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEspName1.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblEspName1.Location = new System.Drawing.Point(10, 42);
            this.lblEspName1.Name = "lblEspName1";
            this.lblEspName1.Size = new System.Drawing.Size(123, 17);
            this.lblEspName1.TabIndex = 1;
            this.lblEspName1.Text = "Odontología Gral.";
            //
            // pnlEspBox2
            //
            this.pnlEspBox2.BackColor = System.Drawing.Color.White;
            this.pnlEspBox2.Controls.Add(this.lblEspIcon2);
            this.pnlEspBox2.Controls.Add(this.lblEspName2);
            this.pnlEspBox2.Location = new System.Drawing.Point(177, 0);
            this.pnlEspBox2.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlEspBox2.Name = "pnlEspBox2";
            this.pnlEspBox2.Padding = new System.Windows.Forms.Padding(10);
            this.pnlEspBox2.Size = new System.Drawing.Size(165, 80);
            this.pnlEspBox2.TabIndex = 1;
            this.pnlEspBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBorder_Paint);
            //
            // lblEspIcon2
            //
            this.lblEspIcon2.AutoSize = true;
            this.lblEspIcon2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEspIcon2.Location = new System.Drawing.Point(10, 8);
            this.lblEspIcon2.Name = "lblEspIcon2";
            this.lblEspIcon2.Size = new System.Drawing.Size(35, 25);
            this.lblEspIcon2.TabIndex = 0;
            this.lblEspIcon2.Text = "😁";
            //
            // lblEspName2
            //
            this.lblEspName2.AutoSize = true;
            this.lblEspName2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEspName2.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblEspName2.Location = new System.Drawing.Point(10, 42);
            this.lblEspName2.Name = "lblEspName2";
            this.lblEspName2.Size = new System.Drawing.Size(78, 17);
            this.lblEspName2.TabIndex = 1;
            this.lblEspName2.Text = "Ortodoncia";
            //
            // pnlEspBox3
            //
            this.pnlEspBox3.BackColor = System.Drawing.Color.White;
            this.pnlEspBox3.Controls.Add(this.lblEspIcon3);
            this.pnlEspBox3.Controls.Add(this.lblEspName3);
            this.pnlEspBox3.Location = new System.Drawing.Point(354, 0);
            this.pnlEspBox3.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlEspBox3.Name = "pnlEspBox3";
            this.pnlEspBox3.Padding = new System.Windows.Forms.Padding(10);
            this.pnlEspBox3.Size = new System.Drawing.Size(165, 80);
            this.pnlEspBox3.TabIndex = 2;
            this.pnlEspBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBorder_Paint);
            //
            // lblEspIcon3
            //
            this.lblEspIcon3.AutoSize = true;
            this.lblEspIcon3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEspIcon3.Location = new System.Drawing.Point(10, 8);
            this.lblEspIcon3.Name = "lblEspIcon3";
            this.lblEspIcon3.Size = new System.Drawing.Size(35, 25);
            this.lblEspIcon3.TabIndex = 0;
            this.lblEspIcon3.Text = "🔬";
            //
            // lblEspName3
            //
            this.lblEspName3.AutoSize = true;
            this.lblEspName3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEspName3.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblEspName3.Location = new System.Drawing.Point(10, 42);
            this.lblEspName3.Name = "lblEspName3";
            this.lblEspName3.Size = new System.Drawing.Size(79, 17);
            this.lblEspName3.TabIndex = 1;
            this.lblEspName3.Text = "Endodoncia";
            //
            // pnlEspBox4
            //
            this.pnlEspBox4.BackColor = System.Drawing.Color.White;
            this.pnlEspBox4.Controls.Add(this.lblEspIcon4);
            this.pnlEspBox4.Controls.Add(this.lblEspName4);
            this.pnlEspBox4.Location = new System.Drawing.Point(531, 0);
            this.pnlEspBox4.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlEspBox4.Name = "pnlEspBox4";
            this.pnlEspBox4.Padding = new System.Windows.Forms.Padding(10);
            this.pnlEspBox4.Size = new System.Drawing.Size(165, 80);
            this.pnlEspBox4.TabIndex = 3;
            this.pnlEspBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBorder_Paint);
            //
            // lblEspIcon4
            //
            this.lblEspIcon4.AutoSize = true;
            this.lblEspIcon4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEspIcon4.Location = new System.Drawing.Point(10, 8);
            this.lblEspIcon4.Name = "lblEspIcon4";
            this.lblEspIcon4.Size = new System.Drawing.Size(35, 25);
            this.lblEspIcon4.TabIndex = 0;
            this.lblEspIcon4.Text = "🛠️";
            //
            // lblEspName4
            //
            this.lblEspName4.AutoSize = true;
            this.lblEspName4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEspName4.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblEspName4.Location = new System.Drawing.Point(10, 42);
            this.lblEspName4.Name = "lblEspName4";
            this.lblEspName4.Size = new System.Drawing.Size(96, 17);
            this.lblEspName4.TabIndex = 1;
            this.lblEspName4.Text = "Implantología";
            //
            // tabMisTurnos
            //
            this.tabMisTurnos.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.tabMisTurnos.Controls.Add(this.pnlGridMisTurnos);
            this.tabMisTurnos.Controls.Add(this.pnlBarTurnos);
            this.tabMisTurnos.Location = new System.Drawing.Point(4, 34);
            this.tabMisTurnos.Name = "tabMisTurnos";
            this.tabMisTurnos.Size = new System.Drawing.Size(992, 572);
            this.tabMisTurnos.TabIndex = 1;
            this.tabMisTurnos.Text = "📅 Mis Turnos";
            //
            // pnlGridMisTurnos
            //
            this.pnlGridMisTurnos.Controls.Add(this.gridMisTurnos);
            this.pnlGridMisTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridMisTurnos.Location = new System.Drawing.Point(0, 65);
            this.pnlGridMisTurnos.Name = "pnlGridMisTurnos";
            this.pnlGridMisTurnos.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.pnlGridMisTurnos.Size = new System.Drawing.Size(992, 507);
            this.pnlGridMisTurnos.TabIndex = 0;
            //
            // gridMisTurnos
            //
            this.gridMisTurnos.AllowUserToAddRows = false;
            this.gridMisTurnos.AllowUserToDeleteRows = false;
            this.gridMisTurnos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.gridMisTurnos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMisTurnos.AutoGenerateColumns = false;
            this.gridMisTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMisTurnos.BackgroundColor = System.Drawing.Color.White;
            this.gridMisTurnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridMisTurnos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridMisTurnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMisTurnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridMisTurnos.ColumnHeadersHeight = 42;
            this.gridMisTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMisTurnosFecha,
            this.colMisTurnosHora,
            this.colMisTurnosDoctor,
            this.colMisTurnosEspecialidad,
            this.colMisTurnosEstado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(224, 236, 248);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(0, 51, 112);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMisTurnos.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridMisTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMisTurnos.EnableHeadersVisualStyles = false;
            this.gridMisTurnos.GridColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.gridMisTurnos.Location = new System.Drawing.Point(25, 15);
            this.gridMisTurnos.MultiSelect = false;
            this.gridMisTurnos.Name = "gridMisTurnos";
            this.gridMisTurnos.ReadOnly = true;
            this.gridMisTurnos.RowHeadersVisible = false;
            this.gridMisTurnos.RowTemplate.Height = 40;
            this.gridMisTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMisTurnos.Size = new System.Drawing.Size(942, 477);
            this.gridMisTurnos.TabIndex = 0;
            this.gridMisTurnos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridMisTurnos_CellFormatting);
            //
            // colMisTurnosFecha
            //
            this.colMisTurnosFecha.HeaderText = "Fecha";
            this.colMisTurnosFecha.Name = "Fecha";
            this.colMisTurnosFecha.ReadOnly = true;
            this.colMisTurnosFecha.Width = 120;
            //
            // colMisTurnosHora
            //
            this.colMisTurnosHora.DataPropertyName = "HorarioTurno";
            this.colMisTurnosHora.HeaderText = "Horario";
            this.colMisTurnosHora.Name = "Hora";
            this.colMisTurnosHora.ReadOnly = true;
            this.colMisTurnosHora.Width = 90;
            //
            // colMisTurnosDoctor
            //
            this.colMisTurnosDoctor.DataPropertyName = "OdontologoNombre";
            this.colMisTurnosDoctor.HeaderText = "Profesional Odontólogo";
            this.colMisTurnosDoctor.Name = "Doctor";
            this.colMisTurnosDoctor.ReadOnly = true;
            this.colMisTurnosDoctor.Width = 230;
            //
            // colMisTurnosEspecialidad
            //
            this.colMisTurnosEspecialidad.DataPropertyName = "EspecialidadNombre";
            this.colMisTurnosEspecialidad.HeaderText = "Especialidad";
            this.colMisTurnosEspecialidad.Name = "Especialidad";
            this.colMisTurnosEspecialidad.ReadOnly = true;
            this.colMisTurnosEspecialidad.Width = 200;
            //
            // colMisTurnosEstado
            //
            this.colMisTurnosEstado.DataPropertyName = "EstadoTurno";
            this.colMisTurnosEstado.HeaderText = "Estado";
            this.colMisTurnosEstado.Name = "Estado";
            this.colMisTurnosEstado.ReadOnly = true;
            this.colMisTurnosEstado.Width = 150;
            //
            // pnlBarTurnos
            //
            this.pnlBarTurnos.BackColor = System.Drawing.Color.White;
            this.pnlBarTurnos.Controls.Add(this.btnNuevoTurno);
            this.pnlBarTurnos.Controls.Add(this.btnCancelarTurno);
            this.pnlBarTurnos.Controls.Add(this.btnRefrescarTurnos);
            this.pnlBarTurnos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarTurnos.Location = new System.Drawing.Point(0, 0);
            this.pnlBarTurnos.Name = "pnlBarTurnos";
            this.pnlBarTurnos.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.pnlBarTurnos.Size = new System.Drawing.Size(992, 65);
            this.pnlBarTurnos.TabIndex = 1;
            //
            // btnNuevoTurno
            //
            this.btnNuevoTurno.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNuevoTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoTurno.FlatAppearance.BorderSize = 0;
            this.btnNuevoTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoTurno.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNuevoTurno.ForeColor = System.Drawing.Color.White;
            this.btnNuevoTurno.Location = new System.Drawing.Point(25, 13);
            this.btnNuevoTurno.Name = "btnNuevoTurno";
            this.btnNuevoTurno.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnNuevoTurno.Size = new System.Drawing.Size(170, 36);
            this.btnNuevoTurno.TabIndex = 0;
            this.btnNuevoTurno.Text = "📅 Agendar Turno";
            this.btnNuevoTurno.UseVisualStyleBackColor = false;
            this.btnNuevoTurno.Click += new System.EventHandler(this.BtnReservarTurno_Click);
            //
            // btnCancelarTurno
            //
            this.btnCancelarTurno.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnCancelarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarTurno.FlatAppearance.BorderSize = 0;
            this.btnCancelarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarTurno.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelarTurno.ForeColor = System.Drawing.Color.White;
            this.btnCancelarTurno.Location = new System.Drawing.Point(205, 13);
            this.btnCancelarTurno.Name = "btnCancelarTurno";
            this.btnCancelarTurno.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnCancelarTurno.Size = new System.Drawing.Size(160, 36);
            this.btnCancelarTurno.TabIndex = 1;
            this.btnCancelarTurno.Text = "❌ Cancelar Turno";
            this.btnCancelarTurno.UseVisualStyleBackColor = false;
            this.btnCancelarTurno.Click += new System.EventHandler(this.BtnCancelarTurno_Click);
            //
            // btnRefrescarTurnos
            //
            this.btnRefrescarTurnos.BackColor = System.Drawing.Color.White;
            this.btnRefrescarTurnos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescarTurnos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnRefrescarTurnos.FlatAppearance.BorderSize = 1;
            this.btnRefrescarTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescarTurnos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefrescarTurnos.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnRefrescarTurnos.Location = new System.Drawing.Point(375, 13);
            this.btnRefrescarTurnos.Name = "btnRefrescarTurnos";
            this.btnRefrescarTurnos.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnRefrescarTurnos.Size = new System.Drawing.Size(120, 36);
            this.btnRefrescarTurnos.TabIndex = 2;
            this.btnRefrescarTurnos.Text = "🔄 Actualizar";
            this.btnRefrescarTurnos.UseVisualStyleBackColor = false;
            this.btnRefrescarTurnos.Click += new System.EventHandler(this.BtnRefrescarTurnos_Click);
            //
            // tabHistorialClinico
            //
            this.tabHistorialClinico.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.tabHistorialClinico.Controls.Add(this.pnlGridHC);
            this.tabHistorialClinico.Controls.Add(this.lblHCPaciente);
            this.tabHistorialClinico.Location = new System.Drawing.Point(4, 34);
            this.tabHistorialClinico.Name = "tabHistorialClinico";
            this.tabHistorialClinico.Size = new System.Drawing.Size(992, 572);
            this.tabHistorialClinico.TabIndex = 2;
            this.tabHistorialClinico.Text = "📋 Mi Historial Clínico";
            //
            // pnlGridHC
            //
            this.pnlGridHC.Controls.Add(this.gridHCPaciente);
            this.pnlGridHC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridHC.Location = new System.Drawing.Point(0, 75);
            this.pnlGridHC.Name = "pnlGridHC";
            this.pnlGridHC.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.pnlGridHC.Size = new System.Drawing.Size(992, 497);
            this.pnlGridHC.TabIndex = 0;
            //
            // gridHCPaciente
            //
            this.gridHCPaciente.AllowUserToAddRows = false;
            this.gridHCPaciente.AllowUserToDeleteRows = false;
            this.gridHCPaciente.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.gridHCPaciente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridHCPaciente.AutoGenerateColumns = false;
            this.gridHCPaciente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridHCPaciente.BackgroundColor = System.Drawing.Color.White;
            this.gridHCPaciente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridHCPaciente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridHCPaciente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHCPaciente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridHCPaciente.ColumnHeadersHeight = 42;
            this.gridHCPaciente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHCFecha,
            this.colHCDoctor,
            this.colHCDiagnostico,
            this.colHCTratamiento,
            this.colHCObservaciones});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(224, 236, 248);
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(0, 51, 112);
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridHCPaciente.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridHCPaciente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHCPaciente.EnableHeadersVisualStyles = false;
            this.gridHCPaciente.GridColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.gridHCPaciente.Location = new System.Drawing.Point(25, 15);
            this.gridHCPaciente.MultiSelect = false;
            this.gridHCPaciente.Name = "gridHCPaciente";
            this.gridHCPaciente.ReadOnly = true;
            this.gridHCPaciente.RowHeadersVisible = false;
            this.gridHCPaciente.RowTemplate.Height = 40;
            this.gridHCPaciente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHCPaciente.Size = new System.Drawing.Size(942, 467);
            this.gridHCPaciente.TabIndex = 0;
            //
            // colHCFecha
            //
            this.colHCFecha.HeaderText = "Fecha de Atención";
            this.colHCFecha.Name = "Fecha";
            this.colHCFecha.ReadOnly = true;
            this.colHCFecha.Width = 130;
            //
            // colHCDoctor
            //
            this.colHCDoctor.DataPropertyName = "OdontologoNombre";
            this.colHCDoctor.HeaderText = "Odontólogo";
            this.colHCDoctor.Name = "Doctor";
            this.colHCDoctor.ReadOnly = true;
            this.colHCDoctor.Width = 220;
            //
            // colHCDiagnostico
            //
            this.colHCDiagnostico.DataPropertyName = "Diagnostico";
            this.colHCDiagnostico.HeaderText = "Diagnóstico (CIE-10)";
            this.colHCDiagnostico.Name = "Diagnostico";
            this.colHCDiagnostico.ReadOnly = true;
            this.colHCDiagnostico.Width = 240;
            //
            // colHCTratamiento
            //
            this.colHCTratamiento.DataPropertyName = "Tratamiento";
            this.colHCTratamiento.HeaderText = "Tratamiento Realizado";
            this.colHCTratamiento.Name = "Tratamiento";
            this.colHCTratamiento.ReadOnly = true;
            this.colHCTratamiento.Width = 240;
            //
            // colHCObservaciones
            //
            this.colHCObservaciones.DataPropertyName = "Observaciones";
            this.colHCObservaciones.HeaderText = "Observaciones Médicas";
            this.colHCObservaciones.Name = "Observaciones";
            this.colHCObservaciones.ReadOnly = true;
            //
            // lblHCPaciente
            //
            this.lblHCPaciente.BackColor = System.Drawing.Color.White;
            this.lblHCPaciente.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHCPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHCPaciente.Location = new System.Drawing.Point(0, 0);
            this.lblHCPaciente.Name = "lblHCPaciente";
            this.lblHCPaciente.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);
            this.lblHCPaciente.Size = new System.Drawing.Size(992, 75);
            this.lblHCPaciente.TabIndex = 1;
            this.lblHCPaciente.Text = "Cargando antecedentes médicos...";
            //
            // tabPagos
            //
            this.tabPagos.AutoScroll = true;
            this.tabPagos.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.tabPagos.Controls.Add(this.pnlBalance);
            this.tabPagos.Controls.Add(this.lblMultasTitle);
            this.tabPagos.Controls.Add(this.gridMultas);
            this.tabPagos.Controls.Add(this.lblTarjetasTitle);
            this.tabPagos.Controls.Add(this.pnlTarjetas);
            this.tabPagos.Location = new System.Drawing.Point(4, 34);
            this.tabPagos.Name = "tabPagos";
            this.tabPagos.Padding = new System.Windows.Forms.Padding(25);
            this.tabPagos.Size = new System.Drawing.Size(992, 572);
            this.tabPagos.TabIndex = 3;
            this.tabPagos.Text = "💳 Métodos de Pago y Saldo";
            //
            // pnlBalance
            //
            this.pnlBalance.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.pnlBalance.Controls.Add(this.lblBalTitle);
            this.pnlBalance.Controls.Add(this.lblSaldoDeuda);
            this.pnlBalance.Controls.Add(this.lblEstadoHabilitacion);
            this.pnlBalance.Controls.Add(this.btnPagarDeuda);
            this.pnlBalance.Location = new System.Drawing.Point(25, 20);
            this.pnlBalance.Name = "pnlBalance";
            this.pnlBalance.Padding = new System.Windows.Forms.Padding(25);
            this.pnlBalance.Size = new System.Drawing.Size(720, 140);
            this.pnlBalance.TabIndex = 0;
            //
            // lblBalTitle
            //
            this.lblBalTitle.AutoSize = true;
            this.lblBalTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBalTitle.ForeColor = System.Drawing.Color.FromArgb(200, 225, 255);
            this.lblBalTitle.Location = new System.Drawing.Point(25, 15);
            this.lblBalTitle.Name = "lblBalTitle";
            this.lblBalTitle.Size = new System.Drawing.Size(173, 15);
            this.lblBalTitle.TabIndex = 0;
            this.lblBalTitle.Text = "ESTADO DE CUENTA Y SALDO";
            //
            // lblSaldoDeuda
            //
            this.lblSaldoDeuda.AutoSize = true;
            this.lblSaldoDeuda.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSaldoDeuda.ForeColor = System.Drawing.Color.White;
            this.lblSaldoDeuda.Location = new System.Drawing.Point(25, 42);
            this.lblSaldoDeuda.Name = "lblSaldoDeuda";
            this.lblSaldoDeuda.Size = new System.Drawing.Size(327, 30);
            this.lblSaldoDeuda.TabIndex = 1;
            this.lblSaldoDeuda.Text = "Saldo Deudor Pendiente: $0.00";
            //
            // lblEstadoHabilitacion
            //
            this.lblEstadoHabilitacion.AutoSize = true;
            this.lblEstadoHabilitacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEstadoHabilitacion.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153);
            this.lblEstadoHabilitacion.Location = new System.Drawing.Point(25, 85);
            this.lblEstadoHabilitacion.Name = "lblEstadoHabilitacion";
            this.lblEstadoHabilitacion.Size = new System.Drawing.Size(262, 17);
            this.lblEstadoHabilitacion.TabIndex = 2;
            this.lblEstadoHabilitacion.Text = "ESTADO: HABILITADO PARA RESERVAS";
            //
            // btnPagarDeuda
            //
            this.btnPagarDeuda.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnPagarDeuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagarDeuda.FlatAppearance.BorderSize = 0;
            this.btnPagarDeuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagarDeuda.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPagarDeuda.ForeColor = System.Drawing.Color.White;
            this.btnPagarDeuda.Location = new System.Drawing.Point(510, 45);
            this.btnPagarDeuda.Name = "btnPagarDeuda";
            this.btnPagarDeuda.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnPagarDeuda.Size = new System.Drawing.Size(180, 42);
            this.btnPagarDeuda.TabIndex = 3;
            this.btnPagarDeuda.Text = "💳 Pagar Deuda / Multa";
            this.btnPagarDeuda.UseVisualStyleBackColor = false;
            this.btnPagarDeuda.Visible = false;
            this.btnPagarDeuda.Click += new System.EventHandler(this.BtnPagarDeuda_Click);
            //
            // lblMultasTitle
            //
            this.lblMultasTitle.AutoSize = true;
            this.lblMultasTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMultasTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblMultasTitle.Location = new System.Drawing.Point(25, 180);
            this.lblMultasTitle.Name = "lblMultasTitle";
            this.lblMultasTitle.Size = new System.Drawing.Size(377, 19);
            this.lblMultasTitle.TabIndex = 1;
            this.lblMultasTitle.Text = "Detalle de Multas por Inasistencia o Cargos Pendientes:";
            //
            // gridMultas
            //
            this.gridMultas.AllowUserToAddRows = false;
            this.gridMultas.AllowUserToDeleteRows = false;
            this.gridMultas.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.gridMultas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gridMultas.AutoGenerateColumns = false;
            this.gridMultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMultas.BackgroundColor = System.Drawing.Color.White;
            this.gridMultas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridMultas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridMultas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMultas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gridMultas.ColumnHeadersHeight = 42;
            this.gridMultas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMultaId,
            this.colMultaMonto,
            this.colMultaMotivo,
            this.colMultaPagada});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(224, 236, 248);
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(0, 51, 112);
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMultas.DefaultCellStyle = dataGridViewCellStyle9;
            this.gridMultas.EnableHeadersVisualStyles = false;
            this.gridMultas.GridColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.gridMultas.Location = new System.Drawing.Point(25, 210);
            this.gridMultas.MultiSelect = false;
            this.gridMultas.Name = "gridMultas";
            this.gridMultas.ReadOnly = true;
            this.gridMultas.RowHeadersVisible = false;
            this.gridMultas.RowTemplate.Height = 40;
            this.gridMultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMultas.Size = new System.Drawing.Size(720, 180);
            this.gridMultas.TabIndex = 2;
            this.gridMultas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridMultas_CellFormatting);
            //
            // colMultaId
            //
            this.colMultaId.DataPropertyName = "Id";
            this.colMultaId.HeaderText = "ID Multa";
            this.colMultaId.Name = "Id";
            this.colMultaId.ReadOnly = true;
            this.colMultaId.Width = 80;
            //
            // colMultaMonto
            //
            this.colMultaMonto.DataPropertyName = "Monto";
            this.colMultaMonto.HeaderText = "Monto ($)";
            this.colMultaMonto.Name = "Monto";
            this.colMultaMonto.ReadOnly = true;
            this.colMultaMonto.Width = 120;
            //
            // colMultaMotivo
            //
            this.colMultaMotivo.DataPropertyName = "Motivo";
            this.colMultaMotivo.HeaderText = "Concepto / Motivo";
            this.colMultaMotivo.Name = "Motivo";
            this.colMultaMotivo.ReadOnly = true;
            this.colMultaMotivo.Width = 340;
            //
            // colMultaPagada
            //
            this.colMultaPagada.HeaderText = "Estado";
            this.colMultaPagada.Name = "Pagada";
            this.colMultaPagada.ReadOnly = true;
            this.colMultaPagada.Width = 140;
            //
            // lblTarjetasTitle
            //
            this.lblTarjetasTitle.AutoSize = true;
            this.lblTarjetasTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTarjetasTitle.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblTarjetasTitle.Location = new System.Drawing.Point(25, 415);
            this.lblTarjetasTitle.Name = "lblTarjetasTitle";
            this.lblTarjetasTitle.Size = new System.Drawing.Size(305, 19);
            this.lblTarjetasTitle.TabIndex = 3;
            this.lblTarjetasTitle.Text = "Mis Tarjetas y Medios de Pago Registrados:";
            //
            // pnlTarjetas
            //
            this.pnlTarjetas.BackColor = System.Drawing.Color.White;
            this.pnlTarjetas.Controls.Add(this.lstTarjetas);
            this.pnlTarjetas.Controls.Add(this.btnAgregarTarjeta);
            this.pnlTarjetas.Controls.Add(this.btnEliminarTarjeta);
            this.pnlTarjetas.Location = new System.Drawing.Point(25, 443);
            this.pnlTarjetas.Name = "pnlTarjetas";
            this.pnlTarjetas.Padding = new System.Windows.Forms.Padding(15);
            this.pnlTarjetas.Size = new System.Drawing.Size(720, 160);
            this.pnlTarjetas.TabIndex = 4;
            this.pnlTarjetas.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBorder_Paint);
            //
            // lstTarjetas
            //
            this.lstTarjetas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstTarjetas.FormattingEnabled = true;
            this.lstTarjetas.ItemHeight = 17;
            this.lstTarjetas.Items.AddRange(new object[] {
            "💳 Visa Débito **** 4321 • Banco Santander (Predeterminada)",
            "💳 Mastercard Crédito **** 8890 • Banco Galicia",
            "📱 Billetera Virtual MercadoPago • juan.perez@email.com"});
            this.lstTarjetas.Location = new System.Drawing.Point(15, 15);
            this.lstTarjetas.Name = "lstTarjetas";
            this.lstTarjetas.Size = new System.Drawing.Size(500, 123);
            this.lstTarjetas.TabIndex = 0;
            //
            // btnAgregarTarjeta
            //
            this.btnAgregarTarjeta.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnAgregarTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarTarjeta.FlatAppearance.BorderSize = 0;
            this.btnAgregarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTarjeta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarTarjeta.ForeColor = System.Drawing.Color.White;
            this.btnAgregarTarjeta.Location = new System.Drawing.Point(530, 15);
            this.btnAgregarTarjeta.Name = "btnAgregarTarjeta";
            this.btnAgregarTarjeta.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnAgregarTarjeta.Size = new System.Drawing.Size(170, 38);
            this.btnAgregarTarjeta.TabIndex = 1;
            this.btnAgregarTarjeta.Text = "+ Agregar Tarjeta";
            this.btnAgregarTarjeta.UseVisualStyleBackColor = false;
            this.btnAgregarTarjeta.Click += new System.EventHandler(this.BtnAgregarTarjeta_Click);
            //
            // btnEliminarTarjeta
            //
            this.btnEliminarTarjeta.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnEliminarTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarTarjeta.FlatAppearance.BorderSize = 0;
            this.btnEliminarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarTarjeta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminarTarjeta.ForeColor = System.Drawing.Color.White;
            this.btnEliminarTarjeta.Location = new System.Drawing.Point(530, 60);
            this.btnEliminarTarjeta.Name = "btnEliminarTarjeta";
            this.btnEliminarTarjeta.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnEliminarTarjeta.Size = new System.Drawing.Size(170, 38);
            this.btnEliminarTarjeta.TabIndex = 2;
            this.btnEliminarTarjeta.Text = "🗑️ Eliminar";
            this.btnEliminarTarjeta.UseVisualStyleBackColor = false;
            this.btnEliminarTarjeta.Click += new System.EventHandler(this.BtnEliminarTarjeta_Click);
            //
            // tabSeguro
            //
            this.tabSeguro.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.tabSeguro.Controls.Add(this.pnlSeguroCard);
            this.tabSeguro.Location = new System.Drawing.Point(4, 34);
            this.tabSeguro.Name = "tabSeguro";
            this.tabSeguro.Padding = new System.Windows.Forms.Padding(25);
            this.tabSeguro.Size = new System.Drawing.Size(992, 572);
            this.tabSeguro.TabIndex = 4;
            this.tabSeguro.Text = "🛡️ Mi Obra Social";
            //
            // pnlSeguroCard
            //
            this.pnlSeguroCard.BackColor = System.Drawing.Color.White;
            this.pnlSeguroCard.Controls.Add(this.lblSeguroHeader);
            this.pnlSeguroCard.Controls.Add(this.lblOSNombre);
            this.pnlSeguroCard.Controls.Add(this.lblOSAfiliado);
            this.pnlSeguroCard.Controls.Add(this.lblOSEstado);
            this.pnlSeguroCard.Controls.Add(this.lblSeguroAviso);
            this.pnlSeguroCard.Location = new System.Drawing.Point(25, 25);
            this.pnlSeguroCard.Name = "pnlSeguroCard";
            this.pnlSeguroCard.Padding = new System.Windows.Forms.Padding(25);
            this.pnlSeguroCard.Size = new System.Drawing.Size(600, 240);
            this.pnlSeguroCard.TabIndex = 0;
            this.pnlSeguroCard.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBorder_Paint);
            //
            // lblSeguroHeader
            //
            this.lblSeguroHeader.AutoSize = true;
            this.lblSeguroHeader.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSeguroHeader.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblSeguroHeader.Location = new System.Drawing.Point(25, 20);
            this.lblSeguroHeader.Name = "lblSeguroHeader";
            this.lblSeguroHeader.Size = new System.Drawing.Size(449, 28);
            this.lblSeguroHeader.TabIndex = 0;
            this.lblSeguroHeader.Text = "🛡️ Cobertura Médica y Prepaga Registrada";
            //
            // lblOSNombre
            //
            this.lblOSNombre.AutoSize = true;
            this.lblOSNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOSNombre.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblOSNombre.Location = new System.Drawing.Point(25, 75);
            this.lblOSNombre.Name = "lblOSNombre";
            this.lblOSNombre.Size = new System.Drawing.Size(193, 17);
            this.lblOSNombre.TabIndex = 1;
            this.lblOSNombre.Text = "Obra Social: OSDE (Plan 210)";
            //
            // lblOSAfiliado
            //
            this.lblOSAfiliado.AutoSize = true;
            this.lblOSAfiliado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOSAfiliado.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblOSAfiliado.Location = new System.Drawing.Point(25, 110);
            this.lblOSAfiliado.Name = "lblOSAfiliado";
            this.lblOSAfiliado.Size = new System.Drawing.Size(232, 17);
            this.lblOSAfiliado.TabIndex = 2;
            this.lblOSAfiliado.Text = "N° de Afiliado / Credencial: 987456321";
            //
            // lblOSEstado
            //
            this.lblOSEstado.AutoSize = true;
            this.lblOSEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOSEstado.ForeColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.lblOSEstado.Location = new System.Drawing.Point(25, 145);
            this.lblOSEstado.Name = "lblOSEstado";
            this.lblOSEstado.Size = new System.Drawing.Size(477, 17);
            this.lblOSEstado.TabIndex = 3;
            this.lblOSEstado.Text = "Estado de Cobertura: ACTIVA (100% Cobertura en consultas preventivas)";
            //
            // lblSeguroAviso
            //
            this.lblSeguroAviso.AutoSize = true;
            this.lblSeguroAviso.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeguroAviso.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSeguroAviso.Location = new System.Drawing.Point(25, 190);
            this.lblSeguroAviso.Name = "lblSeguroAviso";
            this.lblSeguroAviso.Size = new System.Drawing.Size(498, 15);
            this.lblSeguroAviso.TabIndex = 4;
            this.lblSeguroAviso.Text = "ℹ️ Para actualizar tu obra social o presentar una nueva credencial, presentate en Recepción.";
            //
            // PacientePortalControl
            //
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.Controls.Add(this.tabPortal);
            this.Controls.Add(this.pnlTop);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "PacientePortalControl";
            this.Size = new System.Drawing.Size(1000, 680);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tabPortal.ResumeLayout(false);
            this.tabInicio.ResumeLayout(false);
            this.tabInicio.PerformLayout();
            this.pnlProximoTurnoCard.ResumeLayout(false);
            this.pnlProximoTurnoCard.PerformLayout();
            this.pnlEspBoxes.ResumeLayout(false);
            this.pnlEspBox1.ResumeLayout(false);
            this.pnlEspBox1.PerformLayout();
            this.pnlEspBox2.ResumeLayout(false);
            this.pnlEspBox2.PerformLayout();
            this.pnlEspBox3.ResumeLayout(false);
            this.pnlEspBox3.PerformLayout();
            this.pnlEspBox4.ResumeLayout(false);
            this.pnlEspBox4.PerformLayout();
            this.tabMisTurnos.ResumeLayout(false);
            this.pnlGridMisTurnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMisTurnos)).EndInit();
            this.pnlBarTurnos.ResumeLayout(false);
            this.tabHistorialClinico.ResumeLayout(false);
            this.pnlGridHC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHCPaciente)).EndInit();
            this.tabPagos.ResumeLayout(false);
            this.tabPagos.PerformLayout();
            this.pnlBalance.ResumeLayout(false);
            this.pnlBalance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMultas)).EndInit();
            this.pnlTarjetas.ResumeLayout(false);
            this.tabSeguro.ResumeLayout(false);
            this.pnlSeguroCard.ResumeLayout(false);
            this.pnlSeguroCard.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TabControl tabPortal;
        private System.Windows.Forms.TabPage tabInicio;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Panel pnlProximoTurnoCard;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.Label lblProxDoctor;
        private System.Windows.Forms.Label lblProxFecha;
        private System.Windows.Forms.Label lblProxEspecialidad;
        private System.Windows.Forms.Label lblProxEstado;
        private System.Windows.Forms.Button btnVerTicket;
        private System.Windows.Forms.Button btnReservarTurno;
        private System.Windows.Forms.Label lblEsp;
        private System.Windows.Forms.FlowLayoutPanel pnlEspBoxes;
        private System.Windows.Forms.Panel pnlEspBox1;
        private System.Windows.Forms.Label lblEspIcon1;
        private System.Windows.Forms.Label lblEspName1;
        private System.Windows.Forms.Panel pnlEspBox2;
        private System.Windows.Forms.Label lblEspIcon2;
        private System.Windows.Forms.Label lblEspName2;
        private System.Windows.Forms.Panel pnlEspBox3;
        private System.Windows.Forms.Label lblEspIcon3;
        private System.Windows.Forms.Label lblEspName3;
        private System.Windows.Forms.Panel pnlEspBox4;
        private System.Windows.Forms.Label lblEspIcon4;
        private System.Windows.Forms.Label lblEspName4;
        private System.Windows.Forms.TabPage tabMisTurnos;
        private System.Windows.Forms.Panel pnlGridMisTurnos;
        private System.Windows.Forms.DataGridView gridMisTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMisTurnosFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMisTurnosHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMisTurnosDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMisTurnosEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMisTurnosEstado;
        private System.Windows.Forms.Panel pnlBarTurnos;
        private System.Windows.Forms.Button btnNuevoTurno;
        private System.Windows.Forms.Button btnCancelarTurno;
        private System.Windows.Forms.Button btnRefrescarTurnos;
        private System.Windows.Forms.TabPage tabHistorialClinico;
        private System.Windows.Forms.Panel pnlGridHC;
        private System.Windows.Forms.DataGridView gridHCPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCDiagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCTratamiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCObservaciones;
        private System.Windows.Forms.Label lblHCPaciente;
        private System.Windows.Forms.TabPage tabPagos;
        private System.Windows.Forms.Panel pnlBalance;
        private System.Windows.Forms.Label lblBalTitle;
        private System.Windows.Forms.Label lblSaldoDeuda;
        private System.Windows.Forms.Label lblEstadoHabilitacion;
        private System.Windows.Forms.Button btnPagarDeuda;
        private System.Windows.Forms.Label lblMultasTitle;
        private System.Windows.Forms.DataGridView gridMultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMultaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMultaMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMultaMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMultaPagada;
        private System.Windows.Forms.Label lblTarjetasTitle;
        private System.Windows.Forms.Panel pnlTarjetas;
        private System.Windows.Forms.ListBox lstTarjetas;
        private System.Windows.Forms.Button btnAgregarTarjeta;
        private System.Windows.Forms.Button btnEliminarTarjeta;
        private System.Windows.Forms.TabPage tabSeguro;
        private System.Windows.Forms.Panel pnlSeguroCard;
        private System.Windows.Forms.Label lblSeguroHeader;
        private System.Windows.Forms.Label lblOSNombre;
        private System.Windows.Forms.Label lblOSAfiliado;
        private System.Windows.Forms.Label lblOSEstado;
        private System.Windows.Forms.Label lblSeguroAviso;
    }
}
