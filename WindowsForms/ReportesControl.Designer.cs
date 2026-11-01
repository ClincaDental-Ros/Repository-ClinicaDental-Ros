#nullable disable

namespace WindowsForms
{
    partial class ReportesControl
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
      DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
      pnlTop = new Panel();
      lblTitle = new Label();
      lblSub = new Label();
      tabReportes = new TabControl();
      tabTurnosDia = new TabPage();
      pnlGridTurnos = new Panel();
      gridTurnosDia = new DataGridView();
      colTurnosHora = new DataGridViewTextBoxColumn();
      colTurnosPaciente = new DataGridViewTextBoxColumn();
      colTurnosOdontologo = new DataGridViewTextBoxColumn();
      colTurnosEspecialidad = new DataGridViewTextBoxColumn();
      colTurnosEstado = new DataGridViewTextBoxColumn();
      graficoTurnos = new GraficoBarras();
      lblStatsTurnos = new Label();
      pnlBarTurnos = new Panel();
      lblFechaTurnos = new Label();
      dtpTurnosDia = new DateTimePicker();
      btnRefrescar = new Button();
      tabAusentismo = new TabPage();
      lblAusResumen = new Label();
      pnlBarAus = new Panel();
      lblAusDesde = new Label();
      dtpAusDesde = new DateTimePicker();
      lblAusHasta = new Label();
      dtpAusHasta = new DateTimePicker();
      btnCalcularAus = new Button();
      tabFacturacion = new TabPage();
      pnlGridFac = new Panel();
      gridFacturacion = new DataGridView();
      colFacId = new DataGridViewTextBoxColumn();
      colFacFecha = new DataGridViewTextBoxColumn();
      colFacPaciente = new DataGridViewTextBoxColumn();
      colFacOS = new DataGridViewTextBoxColumn();
      colFacTotal = new DataGridViewTextBoxColumn();
      colFacDescOS = new DataGridViewTextBoxColumn();
      colFacCobrado = new DataGridViewTextBoxColumn();
      graficoFacturacion = new GraficoBarras();
      lblFacResumen = new Label();
      pnlBarFac = new Panel();
      lblFacDesde = new Label();
      dtpFacDesde = new DateTimePicker();
      lblFacHasta = new Label();
      dtpFacHasta = new DateTimePicker();
      btnCalcularFac = new Button();
      tabHistoriaClinica = new TabPage();
      pnlGridHC = new Panel();
      gridConsultasHC = new DataGridView();
      colHCFecha = new DataGridViewTextBoxColumn();
      colHCDoctor = new DataGridViewTextBoxColumn();
      colHCDiagnostico = new DataGridViewTextBoxColumn();
      colHCTratamiento = new DataGridViewTextBoxColumn();
      colHCObservaciones = new DataGridViewTextBoxColumn();
      lblHCDetalle = new Label();
      pnlBarHC = new Panel();
      lblPacienteHC = new Label();
      cbPacienteHC = new ComboBox();
      btnBuscarHC = new Button();
      pnlTop.SuspendLayout();
      tabReportes.SuspendLayout();
      tabTurnosDia.SuspendLayout();
      pnlGridTurnos.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)gridTurnosDia).BeginInit();
      pnlBarTurnos.SuspendLayout();
      tabAusentismo.SuspendLayout();
      pnlBarAus.SuspendLayout();
      tabFacturacion.SuspendLayout();
      pnlGridFac.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)gridFacturacion).BeginInit();
      pnlBarFac.SuspendLayout();
      tabHistoriaClinica.SuspendLayout();
      pnlGridHC.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)gridConsultasHC).BeginInit();
      pnlBarHC.SuspendLayout();
      SuspendLayout();
      // 
      // pnlTop
      // 
      pnlTop.BackColor = Color.White;
      pnlTop.Controls.Add(lblTitle);
      pnlTop.Controls.Add(lblSub);
      pnlTop.Dock = DockStyle.Top;
      pnlTop.Location = new Point(0, 0);
      pnlTop.Name = "pnlTop";
      pnlTop.Padding = new Padding(25, 15, 25, 10);
      pnlTop.Size = new Size(1560, 70);
      pnlTop.TabIndex = 0;
      // 
      // lblTitle
      // 
      lblTitle.AutoSize = true;
      lblTitle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
      lblTitle.ForeColor = Color.FromArgb(0, 70, 148);
      lblTitle.Location = new Point(25, 12);
      lblTitle.Name = "lblTitle";
      lblTitle.Size = new Size(453, 30);
      lblTitle.TabIndex = 0;
      lblTitle.Text = "Módulo de Reportes, Auditoría y Estadísticas";
      // 
      // lblSub
      // 
      lblSub.AutoSize = true;
      lblSub.Font = new Font("Segoe UI", 8.5F);
      lblSub.ForeColor = Color.FromArgb(100, 116, 139);
      lblSub.Location = new Point(27, 40);
      lblSub.Name = "lblSub";
      lblSub.Size = new Size(607, 20);
      lblSub.TabIndex = 1;
      lblSub.Text = "Métricas de ausentismo, liquidación a obras sociales, balance financiero e historial médico";
      // 
      // tabReportes
      // 
      tabReportes.Controls.Add(tabTurnosDia);
      tabReportes.Controls.Add(tabAusentismo);
      tabReportes.Controls.Add(tabFacturacion);
      tabReportes.Controls.Add(tabHistoriaClinica);
      tabReportes.Dock = DockStyle.Fill;
      tabReportes.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      tabReportes.Location = new Point(0, 70);
      tabReportes.Name = "tabReportes";
      tabReportes.Padding = new Point(18, 10);
      tabReportes.SelectedIndex = 0;
      tabReportes.Size = new Size(1560, 672);
      tabReportes.TabIndex = 1;
      // 
      // tabTurnosDia
      // 
      tabTurnosDia.BackColor = Color.FromArgb(240, 244, 248);
      tabTurnosDia.Controls.Add(pnlGridTurnos);
      tabTurnosDia.Controls.Add(graficoTurnos);
      tabTurnosDia.Controls.Add(lblStatsTurnos);
      tabTurnosDia.Controls.Add(pnlBarTurnos);
      tabTurnosDia.Location = new Point(4, 44);
      tabTurnosDia.Name = "tabTurnosDia";
      tabTurnosDia.Size = new Size(1552, 624);
      tabTurnosDia.TabIndex = 0;
      tabTurnosDia.Text = "📅 Citas del Día";
      // 
      // pnlGridTurnos
      // 
      pnlGridTurnos.Controls.Add(gridTurnosDia);
      pnlGridTurnos.Dock = DockStyle.Fill;
      pnlGridTurnos.Location = new Point(0, 115);
      pnlGridTurnos.Name = "pnlGridTurnos";
      pnlGridTurnos.Padding = new Padding(25, 15, 25, 10);
      pnlGridTurnos.Size = new Size(1212, 509);
      pnlGridTurnos.TabIndex = 0;
      // 
      // gridTurnosDia
      // 
      gridTurnosDia.AllowUserToAddRows = false;
      gridTurnosDia.AllowUserToDeleteRows = false;
      gridTurnosDia.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
      gridTurnosDia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      gridTurnosDia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      gridTurnosDia.BackgroundColor = Color.White;
      gridTurnosDia.BorderStyle = BorderStyle.None;
      gridTurnosDia.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      gridTurnosDia.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 70, 148);
      dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      dataGridViewCellStyle2.ForeColor = Color.White;
      dataGridViewCellStyle2.Padding = new Padding(12, 10, 12, 10);
      dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      gridTurnosDia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      gridTurnosDia.ColumnHeadersHeight = 42;
      gridTurnosDia.Columns.AddRange(new DataGridViewColumn[] { colTurnosHora, colTurnosPaciente, colTurnosOdontologo, colTurnosEspecialidad, colTurnosEstado });
      dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = Color.White;
      dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F);
      dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 41, 59);
      dataGridViewCellStyle3.Padding = new Padding(10, 4, 10, 4);
      dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(224, 236, 248);
      dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(0, 51, 112);
      dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
      gridTurnosDia.DefaultCellStyle = dataGridViewCellStyle3;
      gridTurnosDia.Dock = DockStyle.Fill;
      gridTurnosDia.EnableHeadersVisualStyles = false;
      gridTurnosDia.GridColor = Color.FromArgb(235, 240, 245);
      gridTurnosDia.Location = new Point(25, 15);
      gridTurnosDia.MultiSelect = false;
      gridTurnosDia.Name = "gridTurnosDia";
      gridTurnosDia.ReadOnly = true;
      gridTurnosDia.RowHeadersVisible = false;
      gridTurnosDia.RowHeadersWidth = 51;
      gridTurnosDia.RowTemplate.Height = 40;
      gridTurnosDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      gridTurnosDia.Size = new Size(1162, 484);
      gridTurnosDia.TabIndex = 0;
      // 
      // colTurnosHora
      // 
      colTurnosHora.DataPropertyName = "HorarioTurno";
      colTurnosHora.HeaderText = "Horario";
      colTurnosHora.Name = "colTurnosHora";
      colTurnosHora.ReadOnly = true;
      colTurnosHora.Width = 90;
      // 
      // colTurnosPaciente
      // 
      colTurnosPaciente.DataPropertyName = "PacienteNombre";
      colTurnosPaciente.HeaderText = "Paciente Citado";
      colTurnosPaciente.Name = "colTurnosPaciente";
      colTurnosPaciente.ReadOnly = true;
      colTurnosPaciente.Width = 230;
      // 
      // colTurnosOdontologo
      // 
      colTurnosOdontologo.DataPropertyName = "OdontologoNombre";
      colTurnosOdontologo.HeaderText = "Profesional Asignado";
      colTurnosOdontologo.Name = "colTurnosOdontologo";
      colTurnosOdontologo.ReadOnly = true;
      colTurnosOdontologo.Width = 230;
      // 
      // colTurnosEspecialidad
      // 
      colTurnosEspecialidad.DataPropertyName = "EspecialidadNombre";
      colTurnosEspecialidad.HeaderText = "Especialidad";
      colTurnosEspecialidad.Name = "colTurnosEspecialidad";
      colTurnosEspecialidad.ReadOnly = true;
      colTurnosEspecialidad.Width = 200;
      // 
      // colTurnosEstado
      // 
      colTurnosEstado.DataPropertyName = "EstadoTurno";
      colTurnosEstado.HeaderText = "Estado";
      colTurnosEstado.Name = "colTurnosEstado";
      colTurnosEstado.ReadOnly = true;
      colTurnosEstado.Width = 150;
      // 
      // graficoTurnos
      // 
      graficoTurnos.BackColor = Color.White;
      graficoTurnos.Dock = DockStyle.Right;
      graficoTurnos.Location = new Point(1212, 115);
      graficoTurnos.Name = "graficoTurnos";
      graficoTurnos.Padding = new Padding(15);
      graficoTurnos.Size = new Size(340, 509);
      graficoTurnos.TabIndex = 1;
      graficoTurnos.Titulo = "Citas del día por estado";
      // 
      // lblStatsTurnos
      // 
      lblStatsTurnos.BackColor = Color.FromArgb(230, 240, 250);
      lblStatsTurnos.Dock = DockStyle.Top;
      lblStatsTurnos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblStatsTurnos.ForeColor = Color.FromArgb(0, 51, 112);
      lblStatsTurnos.Location = new Point(0, 65);
      lblStatsTurnos.Name = "lblStatsTurnos";
      lblStatsTurnos.Padding = new Padding(25, 14, 25, 5);
      lblStatsTurnos.Size = new Size(1552, 50);
      lblStatsTurnos.TabIndex = 2;
      lblStatsTurnos.Text = "Cargando estadísticas...";
      // 
      // pnlBarTurnos
      // 
      pnlBarTurnos.BackColor = Color.White;
      pnlBarTurnos.Controls.Add(lblFechaTurnos);
      pnlBarTurnos.Controls.Add(dtpTurnosDia);
      pnlBarTurnos.Controls.Add(btnRefrescar);
      pnlBarTurnos.Dock = DockStyle.Top;
      pnlBarTurnos.Location = new Point(0, 0);
      pnlBarTurnos.Name = "pnlBarTurnos";
      pnlBarTurnos.Padding = new Padding(25, 12, 25, 12);
      pnlBarTurnos.Size = new Size(1552, 65);
      pnlBarTurnos.TabIndex = 3;
      // 
      // lblFechaTurnos
      // 
      lblFechaTurnos.AutoSize = true;
      lblFechaTurnos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblFechaTurnos.ForeColor = Color.FromArgb(30, 41, 59);
      lblFechaTurnos.Location = new Point(25, 20);
      lblFechaTurnos.Name = "lblFechaTurnos";
      lblFechaTurnos.Size = new Size(58, 21);
      lblFechaTurnos.TabIndex = 0;
      lblFechaTurnos.Text = "Fecha:";
      // 
      // dtpTurnosDia
      // 
      dtpTurnosDia.Format = DateTimePickerFormat.Short;
      dtpTurnosDia.Location = new Point(85, 17);
      dtpTurnosDia.Name = "dtpTurnosDia";
      dtpTurnosDia.Size = new Size(130, 29);
      dtpTurnosDia.TabIndex = 1;
      dtpTurnosDia.ValueChanged += DtpTurnosDia_ValueChanged;
      // 
      // btnRefrescar
      // 
      btnRefrescar.BackColor = Color.FromArgb(0, 70, 148);
      btnRefrescar.Cursor = Cursors.Hand;
      btnRefrescar.FlatAppearance.BorderSize = 0;
      btnRefrescar.FlatStyle = FlatStyle.Flat;
      btnRefrescar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      btnRefrescar.ForeColor = Color.White;
      btnRefrescar.Location = new Point(230, 13);
      btnRefrescar.Name = "btnRefrescar";
      btnRefrescar.Padding = new Padding(12, 0, 12, 0);
      btnRefrescar.Size = new Size(130, 36);
      btnRefrescar.TabIndex = 2;
      btnRefrescar.Text = "🔄 Consultar";
      btnRefrescar.UseVisualStyleBackColor = false;
      btnRefrescar.Click += BtnRefrescar_Click;
      // 
      // tabAusentismo
      // 
      tabAusentismo.BackColor = Color.FromArgb(240, 244, 248);
      tabAusentismo.Controls.Add(lblAusResumen);
      tabAusentismo.Controls.Add(pnlBarAus);
      tabAusentismo.Location = new Point(4, 44);
      tabAusentismo.Name = "tabAusentismo";
      tabAusentismo.Size = new Size(992, 532);
      tabAusentismo.TabIndex = 1;
      tabAusentismo.Text = "⚠️ Tasa de Ausentismo y Multas";
      // 
      // lblAusResumen
      // 
      lblAusResumen.Dock = DockStyle.Fill;
      lblAusResumen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
      lblAusResumen.ForeColor = Color.FromArgb(30, 41, 59);
      lblAusResumen.Location = new Point(0, 65);
      lblAusResumen.Name = "lblAusResumen";
      lblAusResumen.Padding = new Padding(35);
      lblAusResumen.Size = new Size(992, 467);
      lblAusResumen.TabIndex = 0;
      lblAusResumen.Text = "Cargando métricas de ausentismo...";
      // 
      // pnlBarAus
      // 
      pnlBarAus.BackColor = Color.White;
      pnlBarAus.Controls.Add(lblAusDesde);
      pnlBarAus.Controls.Add(dtpAusDesde);
      pnlBarAus.Controls.Add(lblAusHasta);
      pnlBarAus.Controls.Add(dtpAusHasta);
      pnlBarAus.Controls.Add(btnCalcularAus);
      pnlBarAus.Dock = DockStyle.Top;
      pnlBarAus.Location = new Point(0, 0);
      pnlBarAus.Name = "pnlBarAus";
      pnlBarAus.Padding = new Padding(25, 12, 25, 12);
      pnlBarAus.Size = new Size(992, 65);
      pnlBarAus.TabIndex = 1;
      // 
      // lblAusDesde
      // 
      lblAusDesde.AutoSize = true;
      lblAusDesde.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblAusDesde.ForeColor = Color.FromArgb(30, 41, 59);
      lblAusDesde.Location = new Point(25, 20);
      lblAusDesde.Name = "lblAusDesde";
      lblAusDesde.Size = new Size(61, 21);
      lblAusDesde.TabIndex = 0;
      lblAusDesde.Text = "Desde:";
      // 
      // dtpAusDesde
      // 
      dtpAusDesde.Format = DateTimePickerFormat.Short;
      dtpAusDesde.Location = new Point(85, 17);
      dtpAusDesde.Name = "dtpAusDesde";
      dtpAusDesde.Size = new Size(120, 29);
      dtpAusDesde.TabIndex = 1;
      // 
      // lblAusHasta
      // 
      lblAusHasta.AutoSize = true;
      lblAusHasta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblAusHasta.ForeColor = Color.FromArgb(30, 41, 59);
      lblAusHasta.Location = new Point(220, 20);
      lblAusHasta.Name = "lblAusHasta";
      lblAusHasta.Size = new Size(57, 21);
      lblAusHasta.TabIndex = 2;
      lblAusHasta.Text = "Hasta:";
      // 
      // dtpAusHasta
      // 
      dtpAusHasta.Format = DateTimePickerFormat.Short;
      dtpAusHasta.Location = new Point(275, 17);
      dtpAusHasta.Name = "dtpAusHasta";
      dtpAusHasta.Size = new Size(120, 29);
      dtpAusHasta.TabIndex = 3;
      // 
      // btnCalcularAus
      // 
      btnCalcularAus.BackColor = Color.FromArgb(0, 70, 148);
      btnCalcularAus.Cursor = Cursors.Hand;
      btnCalcularAus.FlatAppearance.BorderSize = 0;
      btnCalcularAus.FlatStyle = FlatStyle.Flat;
      btnCalcularAus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      btnCalcularAus.ForeColor = Color.White;
      btnCalcularAus.Location = new Point(415, 13);
      btnCalcularAus.Name = "btnCalcularAus";
      btnCalcularAus.Padding = new Padding(12, 0, 12, 0);
      btnCalcularAus.Size = new Size(170, 36);
      btnCalcularAus.TabIndex = 4;
      btnCalcularAus.Text = "📊 Calcular Métricas";
      btnCalcularAus.UseVisualStyleBackColor = false;
      btnCalcularAus.Click += BtnCalcularAus_Click;
      // 
      // tabFacturacion
      // 
      tabFacturacion.BackColor = Color.FromArgb(240, 244, 248);
      tabFacturacion.Controls.Add(pnlGridFac);
      tabFacturacion.Controls.Add(graficoFacturacion);
      tabFacturacion.Controls.Add(lblFacResumen);
      tabFacturacion.Controls.Add(pnlBarFac);
      tabFacturacion.Location = new Point(4, 44);
      tabFacturacion.Name = "tabFacturacion";
      tabFacturacion.Size = new Size(992, 532);
      tabFacturacion.TabIndex = 2;
      tabFacturacion.Text = "💰 Facturación y Obras Sociales";
      // 
      // pnlGridFac
      // 
      pnlGridFac.Controls.Add(gridFacturacion);
      pnlGridFac.Dock = DockStyle.Fill;
      pnlGridFac.Location = new Point(0, 125);
      pnlGridFac.Name = "pnlGridFac";
      pnlGridFac.Padding = new Padding(25, 15, 25, 10);
      pnlGridFac.Size = new Size(632, 407);
      pnlGridFac.TabIndex = 0;
      // 
      // gridFacturacion
      // 
      gridFacturacion.AllowUserToAddRows = false;
      gridFacturacion.AllowUserToDeleteRows = false;
      gridFacturacion.AllowUserToResizeRows = false;
      dataGridViewCellStyle4.BackColor = Color.FromArgb(248, 250, 252);
      gridFacturacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
      gridFacturacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      gridFacturacion.BackgroundColor = Color.White;
      gridFacturacion.BorderStyle = BorderStyle.None;
      gridFacturacion.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      gridFacturacion.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      dataGridViewCellStyle5.BackColor = Color.FromArgb(0, 70, 148);
      dataGridViewCellStyle5.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      dataGridViewCellStyle5.ForeColor = Color.White;
      dataGridViewCellStyle5.Padding = new Padding(12, 10, 12, 10);
      dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
      gridFacturacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
      gridFacturacion.ColumnHeadersHeight = 42;
      gridFacturacion.Columns.AddRange(new DataGridViewColumn[] { colFacId, colFacFecha, colFacPaciente, colFacOS, colFacTotal, colFacDescOS, colFacCobrado });
      dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle6.BackColor = Color.White;
      dataGridViewCellStyle6.Font = new Font("Segoe UI", 9.5F);
      dataGridViewCellStyle6.ForeColor = Color.FromArgb(30, 41, 59);
      dataGridViewCellStyle6.Padding = new Padding(10, 4, 10, 4);
      dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(224, 236, 248);
      dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(0, 51, 112);
      dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
      gridFacturacion.DefaultCellStyle = dataGridViewCellStyle6;
      gridFacturacion.Dock = DockStyle.Fill;
      gridFacturacion.EnableHeadersVisualStyles = false;
      gridFacturacion.GridColor = Color.FromArgb(235, 240, 245);
      gridFacturacion.Location = new Point(25, 15);
      gridFacturacion.MultiSelect = false;
      gridFacturacion.Name = "gridFacturacion";
      gridFacturacion.ReadOnly = true;
      gridFacturacion.RowHeadersVisible = false;
      gridFacturacion.RowHeadersWidth = 51;
      gridFacturacion.RowTemplate.Height = 40;
      gridFacturacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      gridFacturacion.Size = new Size(582, 382);
      gridFacturacion.TabIndex = 0;
      // 
      // colFacId
      // 
      colFacId.DataPropertyName = "Id";
      colFacId.HeaderText = "N° Factura";
      colFacId.Name = "colFacId";
      colFacId.ReadOnly = true;
      colFacId.Width = 90;
      // 
      // colFacFecha
      // 
      colFacFecha.DataPropertyName = "FechaEmision";
      colFacFecha.DefaultCellStyle.Format = "dd/MM/yyyy";
      colFacFecha.HeaderText = "Fecha";
      colFacFecha.Name = "colFacFecha";
      colFacFecha.ReadOnly = true;
      colFacFecha.Width = 120;
      // 
      // colFacPaciente
      // 
      colFacPaciente.DataPropertyName = "PacienteNombre";
      colFacPaciente.HeaderText = "Paciente";
      colFacPaciente.Name = "colFacPaciente";
      colFacPaciente.ReadOnly = true;
      colFacPaciente.Width = 220;
      // 
      // colFacOS
      // 
      colFacOS.DataPropertyName = "ObraSocialNombre";
      colFacOS.HeaderText = "Obra Social";
      colFacOS.Name = "colFacOS";
      colFacOS.ReadOnly = true;
      colFacOS.Width = 160;
      // 
      // colFacTotal
      // 
      colFacTotal.DataPropertyName = "Total";
      colFacTotal.HeaderText = "Total Prestación";
      colFacTotal.Name = "colFacTotal";
      colFacTotal.ReadOnly = true;
      colFacTotal.Width = 140;
      // 
      // colFacDescOS
      // 
      colFacDescOS.DataPropertyName = "DescuentoObraSocial";
      colFacDescOS.HeaderText = "Liq. Obra Social";
      colFacDescOS.Name = "colFacDescOS";
      colFacDescOS.ReadOnly = true;
      colFacDescOS.Width = 140;
      // 
      // colFacCobrado
      // 
      colFacCobrado.DataPropertyName = "MontoAPagarPaciente";
      colFacCobrado.HeaderText = "Cobrado Paciente";
      colFacCobrado.Name = "colFacCobrado";
      colFacCobrado.ReadOnly = true;
      colFacCobrado.Width = 140;
      // 
      // graficoFacturacion
      // 
      graficoFacturacion.BackColor = Color.White;
      graficoFacturacion.Dock = DockStyle.Right;
      graficoFacturacion.Location = new Point(632, 125);
      graficoFacturacion.Name = "graficoFacturacion";
      graficoFacturacion.Padding = new Padding(15);
      graficoFacturacion.Size = new Size(360, 407);
      graficoFacturacion.TabIndex = 1;
      graficoFacturacion.Titulo = "Facturación del período";
      // 
      // lblFacResumen
      // 
      lblFacResumen.BackColor = Color.FromArgb(230, 240, 250);
      lblFacResumen.Dock = DockStyle.Top;
      lblFacResumen.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblFacResumen.ForeColor = Color.FromArgb(0, 51, 112);
      lblFacResumen.Location = new Point(0, 65);
      lblFacResumen.Name = "lblFacResumen";
      lblFacResumen.Padding = new Padding(25, 18, 25, 5);
      lblFacResumen.Size = new Size(992, 60);
      lblFacResumen.TabIndex = 2;
      lblFacResumen.Text = "Cargando facturación...";
      // 
      // pnlBarFac
      // 
      pnlBarFac.BackColor = Color.White;
      pnlBarFac.Controls.Add(lblFacDesde);
      pnlBarFac.Controls.Add(dtpFacDesde);
      pnlBarFac.Controls.Add(lblFacHasta);
      pnlBarFac.Controls.Add(dtpFacHasta);
      pnlBarFac.Controls.Add(btnCalcularFac);
      pnlBarFac.Dock = DockStyle.Top;
      pnlBarFac.Location = new Point(0, 0);
      pnlBarFac.Name = "pnlBarFac";
      pnlBarFac.Padding = new Padding(25, 12, 25, 12);
      pnlBarFac.Size = new Size(992, 65);
      pnlBarFac.TabIndex = 3;
      // 
      // lblFacDesde
      // 
      lblFacDesde.AutoSize = true;
      lblFacDesde.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblFacDesde.ForeColor = Color.FromArgb(30, 41, 59);
      lblFacDesde.Location = new Point(25, 20);
      lblFacDesde.Name = "lblFacDesde";
      lblFacDesde.Size = new Size(61, 21);
      lblFacDesde.TabIndex = 0;
      lblFacDesde.Text = "Desde:";
      // 
      // dtpFacDesde
      // 
      dtpFacDesde.Format = DateTimePickerFormat.Short;
      dtpFacDesde.Location = new Point(85, 17);
      dtpFacDesde.Name = "dtpFacDesde";
      dtpFacDesde.Size = new Size(120, 29);
      dtpFacDesde.TabIndex = 1;
      // 
      // lblFacHasta
      // 
      lblFacHasta.AutoSize = true;
      lblFacHasta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblFacHasta.ForeColor = Color.FromArgb(30, 41, 59);
      lblFacHasta.Location = new Point(220, 20);
      lblFacHasta.Name = "lblFacHasta";
      lblFacHasta.Size = new Size(57, 21);
      lblFacHasta.TabIndex = 2;
      lblFacHasta.Text = "Hasta:";
      // 
      // dtpFacHasta
      // 
      dtpFacHasta.Format = DateTimePickerFormat.Short;
      dtpFacHasta.Location = new Point(275, 17);
      dtpFacHasta.Name = "dtpFacHasta";
      dtpFacHasta.Size = new Size(120, 29);
      dtpFacHasta.TabIndex = 3;
      // 
      // btnCalcularFac
      // 
      btnCalcularFac.BackColor = Color.FromArgb(0, 70, 148);
      btnCalcularFac.Cursor = Cursors.Hand;
      btnCalcularFac.FlatAppearance.BorderSize = 0;
      btnCalcularFac.FlatStyle = FlatStyle.Flat;
      btnCalcularFac.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      btnCalcularFac.ForeColor = Color.White;
      btnCalcularFac.Location = new Point(415, 13);
      btnCalcularFac.Name = "btnCalcularFac";
      btnCalcularFac.Padding = new Padding(12, 0, 12, 0);
      btnCalcularFac.Size = new Size(170, 36);
      btnCalcularFac.TabIndex = 4;
      btnCalcularFac.Text = "📈 Liquidar Período";
      btnCalcularFac.UseVisualStyleBackColor = false;
      btnCalcularFac.Click += BtnCalcularFac_Click;
      // 
      // tabHistoriaClinica
      // 
      tabHistoriaClinica.BackColor = Color.FromArgb(240, 244, 248);
      tabHistoriaClinica.Controls.Add(pnlGridHC);
      tabHistoriaClinica.Controls.Add(lblHCDetalle);
      tabHistoriaClinica.Controls.Add(pnlBarHC);
      tabHistoriaClinica.Location = new Point(4, 44);
      tabHistoriaClinica.Name = "tabHistoriaClinica";
      tabHistoriaClinica.Size = new Size(992, 532);
      tabHistoriaClinica.TabIndex = 3;
      tabHistoriaClinica.Text = "📋 Historia Clínica";
      // 
      // pnlGridHC
      // 
      pnlGridHC.Controls.Add(gridConsultasHC);
      pnlGridHC.Dock = DockStyle.Fill;
      pnlGridHC.Location = new Point(0, 150);
      pnlGridHC.Name = "pnlGridHC";
      pnlGridHC.Padding = new Padding(25, 15, 25, 10);
      pnlGridHC.Size = new Size(992, 382);
      pnlGridHC.TabIndex = 0;
      // 
      // gridConsultasHC
      // 
      gridConsultasHC.AllowUserToAddRows = false;
      gridConsultasHC.AllowUserToDeleteRows = false;
      gridConsultasHC.AllowUserToResizeRows = false;
      dataGridViewCellStyle7.BackColor = Color.FromArgb(248, 250, 252);
      gridConsultasHC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
      gridConsultasHC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      gridConsultasHC.BackgroundColor = Color.White;
      gridConsultasHC.BorderStyle = BorderStyle.None;
      gridConsultasHC.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      gridConsultasHC.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      dataGridViewCellStyle8.BackColor = Color.FromArgb(0, 70, 148);
      dataGridViewCellStyle8.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      dataGridViewCellStyle8.ForeColor = Color.White;
      dataGridViewCellStyle8.Padding = new Padding(12, 10, 12, 10);
      dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
      gridConsultasHC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
      gridConsultasHC.ColumnHeadersHeight = 42;
      gridConsultasHC.Columns.AddRange(new DataGridViewColumn[] { colHCFecha, colHCDoctor, colHCDiagnostico, colHCTratamiento, colHCObservaciones });
      dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle9.BackColor = Color.White;
      dataGridViewCellStyle9.Font = new Font("Segoe UI", 9.5F);
      dataGridViewCellStyle9.ForeColor = Color.FromArgb(30, 41, 59);
      dataGridViewCellStyle9.Padding = new Padding(10, 4, 10, 4);
      dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(224, 236, 248);
      dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(0, 51, 112);
      dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
      gridConsultasHC.DefaultCellStyle = dataGridViewCellStyle9;
      gridConsultasHC.Dock = DockStyle.Fill;
      gridConsultasHC.EnableHeadersVisualStyles = false;
      gridConsultasHC.GridColor = Color.FromArgb(235, 240, 245);
      gridConsultasHC.Location = new Point(25, 15);
      gridConsultasHC.MultiSelect = false;
      gridConsultasHC.Name = "gridConsultasHC";
      gridConsultasHC.ReadOnly = true;
      gridConsultasHC.RowHeadersVisible = false;
      gridConsultasHC.RowHeadersWidth = 51;
      gridConsultasHC.RowTemplate.Height = 40;
      gridConsultasHC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      gridConsultasHC.Size = new Size(942, 357);
      gridConsultasHC.TabIndex = 0;
      // 
      // colHCFecha
      // 
      colHCFecha.DataPropertyName = "Fecha";
      colHCFecha.DefaultCellStyle.Format = "dd/MM/yyyy";
      colHCFecha.HeaderText = "Fecha Atención";
      colHCFecha.Name = "colHCFecha";
      colHCFecha.ReadOnly = true;
      colHCFecha.Width = 120;
      // 
      // colHCDoctor
      // 
      colHCDoctor.DataPropertyName = "OdontologoNombre";
      colHCDoctor.HeaderText = "Profesional Interviniente";
      colHCDoctor.Name = "colHCDoctor";
      colHCDoctor.ReadOnly = true;
      colHCDoctor.Width = 200;
      // 
      // colHCDiagnostico
      // 
      colHCDiagnostico.DataPropertyName = "Diagnostico";
      colHCDiagnostico.HeaderText = "Diagnóstico (CIE-10)";
      colHCDiagnostico.Name = "colHCDiagnostico";
      colHCDiagnostico.ReadOnly = true;
      colHCDiagnostico.Width = 240;
      // 
      // colHCTratamiento
      // 
      colHCTratamiento.DataPropertyName = "Tratamiento";
      colHCTratamiento.HeaderText = "Tratamiento Realizado";
      colHCTratamiento.Name = "colHCTratamiento";
      colHCTratamiento.ReadOnly = true;
      colHCTratamiento.Width = 240;
      // 
      // colHCObservaciones
      // 
      colHCObservaciones.DataPropertyName = "Observaciones";
      colHCObservaciones.HeaderText = "Evolución y Notas Clínicas";
      colHCObservaciones.Name = "colHCObservaciones";
      colHCObservaciones.ReadOnly = true;
      // 
      // lblHCDetalle
      // 
      lblHCDetalle.BackColor = Color.White;
      lblHCDetalle.Dock = DockStyle.Top;
      lblHCDetalle.Font = new Font("Segoe UI", 9.5F);
      lblHCDetalle.ForeColor = Color.FromArgb(30, 41, 59);
      lblHCDetalle.Location = new Point(0, 65);
      lblHCDetalle.Name = "lblHCDetalle";
      lblHCDetalle.Padding = new Padding(25, 14, 25, 5);
      lblHCDetalle.Size = new Size(992, 85);
      lblHCDetalle.TabIndex = 1;
      lblHCDetalle.Text = "Seleccione un paciente para ver antecedentes médicos, odontograma y consultas previas.";
      // 
      // pnlBarHC
      // 
      pnlBarHC.BackColor = Color.White;
      pnlBarHC.Controls.Add(lblPacienteHC);
      pnlBarHC.Controls.Add(cbPacienteHC);
      pnlBarHC.Controls.Add(btnBuscarHC);
      pnlBarHC.Dock = DockStyle.Top;
      pnlBarHC.Location = new Point(0, 0);
      pnlBarHC.Name = "pnlBarHC";
      pnlBarHC.Padding = new Padding(25, 12, 25, 12);
      pnlBarHC.Size = new Size(992, 65);
      pnlBarHC.TabIndex = 2;
      // 
      // lblPacienteHC
      // 
      lblPacienteHC.AutoSize = true;
      lblPacienteHC.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblPacienteHC.ForeColor = Color.FromArgb(30, 41, 59);
      lblPacienteHC.Location = new Point(25, 20);
      lblPacienteHC.Name = "lblPacienteHC";
      lblPacienteHC.Size = new Size(80, 21);
      lblPacienteHC.TabIndex = 0;
      lblPacienteHC.Text = "Paciente:";
      // 
      // cbPacienteHC
      // 
      cbPacienteHC.DropDownStyle = ComboBoxStyle.DropDownList;
      cbPacienteHC.Location = new Point(95, 17);
      cbPacienteHC.Name = "cbPacienteHC";
      cbPacienteHC.Size = new Size(370, 29);
      cbPacienteHC.TabIndex = 1;
      cbPacienteHC.SelectedIndexChanged += CbPacienteHC_SelectedIndexChanged;
      // 
      // btnBuscarHC
      // 
      btnBuscarHC.BackColor = Color.FromArgb(0, 70, 148);
      btnBuscarHC.Cursor = Cursors.Hand;
      btnBuscarHC.FlatAppearance.BorderSize = 0;
      btnBuscarHC.FlatStyle = FlatStyle.Flat;
      btnBuscarHC.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      btnBuscarHC.ForeColor = Color.White;
      btnBuscarHC.Location = new Point(480, 13);
      btnBuscarHC.Name = "btnBuscarHC";
      btnBuscarHC.Padding = new Padding(12, 0, 12, 0);
      btnBuscarHC.Size = new Size(130, 36);
      btnBuscarHC.TabIndex = 2;
      btnBuscarHC.Text = "🔍 Ver Ficha";
      btnBuscarHC.UseVisualStyleBackColor = false;
      btnBuscarHC.Click += BtnBuscarHC_Click;
      // 
      // ReportesControl
      // 
      BackColor = Color.FromArgb(240, 244, 248);
      Controls.Add(tabReportes);
      Controls.Add(pnlTop);
      Font = new Font("Segoe UI", 9.5F);
      Name = "ReportesControl";
      Size = new Size(1560, 742);
      pnlTop.ResumeLayout(false);
      pnlTop.PerformLayout();
      tabReportes.ResumeLayout(false);
      tabTurnosDia.ResumeLayout(false);
      pnlGridTurnos.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)gridTurnosDia).EndInit();
      pnlBarTurnos.ResumeLayout(false);
      pnlBarTurnos.PerformLayout();
      tabAusentismo.ResumeLayout(false);
      pnlBarAus.ResumeLayout(false);
      pnlBarAus.PerformLayout();
      tabFacturacion.ResumeLayout(false);
      pnlGridFac.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)gridFacturacion).EndInit();
      pnlBarFac.ResumeLayout(false);
      pnlBarFac.PerformLayout();
      tabHistoriaClinica.ResumeLayout(false);
      pnlGridHC.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)gridConsultasHC).EndInit();
      pnlBarHC.ResumeLayout(false);
      pnlBarHC.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.TabControl tabReportes;
        private System.Windows.Forms.TabPage tabTurnosDia;
        private System.Windows.Forms.Panel pnlGridTurnos;
        private System.Windows.Forms.DataGridView gridTurnosDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnosHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnosPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnosOdontologo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnosEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnosEstado;
        private WindowsForms.GraficoBarras graficoTurnos;
        private System.Windows.Forms.Label lblStatsTurnos;
        private System.Windows.Forms.Panel pnlBarTurnos;
        private System.Windows.Forms.Label lblFechaTurnos;
        private System.Windows.Forms.DateTimePicker dtpTurnosDia;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.TabPage tabAusentismo;
        private System.Windows.Forms.Label lblAusResumen;
        private System.Windows.Forms.Panel pnlBarAus;
        private System.Windows.Forms.Label lblAusDesde;
        private System.Windows.Forms.DateTimePicker dtpAusDesde;
        private System.Windows.Forms.Label lblAusHasta;
        private System.Windows.Forms.DateTimePicker dtpAusHasta;
        private System.Windows.Forms.Button btnCalcularAus;
        private System.Windows.Forms.TabPage tabFacturacion;
        private System.Windows.Forms.Panel pnlGridFac;
        private System.Windows.Forms.DataGridView gridFacturacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacDescOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacCobrado;
        private WindowsForms.GraficoBarras graficoFacturacion;
        private System.Windows.Forms.Label lblFacResumen;
        private System.Windows.Forms.Panel pnlBarFac;
        private System.Windows.Forms.Label lblFacDesde;
        private System.Windows.Forms.DateTimePicker dtpFacDesde;
        private System.Windows.Forms.Label lblFacHasta;
        private System.Windows.Forms.DateTimePicker dtpFacHasta;
        private System.Windows.Forms.Button btnCalcularFac;
        private System.Windows.Forms.TabPage tabHistoriaClinica;
        private System.Windows.Forms.Panel pnlGridHC;
        private System.Windows.Forms.DataGridView gridConsultasHC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCDiagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCTratamiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCObservaciones;
        private System.Windows.Forms.Label lblHCDetalle;
        private System.Windows.Forms.Panel pnlBarHC;
        private System.Windows.Forms.Label lblPacienteHC;
        private System.Windows.Forms.ComboBox cbPacienteHC;
        private System.Windows.Forms.Button btnBuscarHC;
    }
}
