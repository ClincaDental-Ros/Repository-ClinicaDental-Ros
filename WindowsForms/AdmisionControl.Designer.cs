#nullable disable

namespace WindowsForms
{
    partial class AdmisionControl
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
      pnlTop = new Panel();
      lblTitle = new Label();
      lblSubtitle = new Label();
      pnlStats = new FlowLayoutPanel();
      pnlBar = new Panel();
      lblFec = new Label();
      dtpFecha = new DateTimePicker();
      btnBuscar = new Button();
      btnConfirmarPresencia = new Button();
      btnRegistrarAusencia = new Button();
      btnVerMultas = new Button();
      pnlGrid = new Panel();
      gridAdmision = new DataGridView();
      colHora = new DataGridViewTextBoxColumn();
      colPaciente = new DataGridViewTextBoxColumn();
      colOdontologo = new DataGridViewTextBoxColumn();
      colEspecialidad = new DataGridViewTextBoxColumn();
      colEstado = new DataGridViewTextBoxColumn();
      lblEstado = new Label();
      pnlTop.SuspendLayout();
      pnlBar.SuspendLayout();
      pnlGrid.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)gridAdmision).BeginInit();
      SuspendLayout();
      // 
      // pnlTop
      // 
      pnlTop.BackColor = Color.White;
      pnlTop.Controls.Add(lblTitle);
      pnlTop.Controls.Add(lblSubtitle);
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
      lblTitle.Size = new Size(407, 30);
      lblTitle.TabIndex = 0;
      lblTitle.Text = "Módulo de Recepción y Admisión Diaria";
      // 
      // lblSubtitle
      // 
      lblSubtitle.AutoSize = true;
      lblSubtitle.Font = new Font("Segoe UI", 8.5F);
      lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
      lblSubtitle.Location = new Point(27, 40);
      lblSubtitle.Name = "lblSubtitle";
      lblSubtitle.Size = new Size(638, 20);
      lblSubtitle.TabIndex = 1;
      lblSubtitle.Text = "Control de sala de espera, confirmación de presencia y aplicación de sanciones por ausentismo";
      // 
      // pnlStats
      // 
      pnlStats.AutoScroll = true;
      pnlStats.BackColor = Color.FromArgb(240, 244, 248);
      pnlStats.Dock = DockStyle.Top;
      pnlStats.Location = new Point(0, 70);
      pnlStats.Name = "pnlStats";
      pnlStats.Padding = new Padding(25, 10, 25, 5);
      pnlStats.Size = new Size(1560, 95);
      pnlStats.TabIndex = 1;
      pnlStats.WrapContents = false;
      // 
      // pnlBar
      // 
      pnlBar.BackColor = Color.White;
      pnlBar.Controls.Add(lblFec);
      pnlBar.Controls.Add(dtpFecha);
      pnlBar.Controls.Add(btnBuscar);
      pnlBar.Controls.Add(btnConfirmarPresencia);
      pnlBar.Controls.Add(btnRegistrarAusencia);
      pnlBar.Controls.Add(btnVerMultas);
      pnlBar.Dock = DockStyle.Top;
      pnlBar.Location = new Point(0, 165);
      pnlBar.Name = "pnlBar";
      pnlBar.Padding = new Padding(25, 12, 25, 12);
      pnlBar.Size = new Size(1560, 65);
      pnlBar.TabIndex = 2;
      // 
      // lblFec
      // 
      lblFec.AutoSize = true;
      lblFec.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblFec.ForeColor = Color.FromArgb(30, 41, 59);
      lblFec.Location = new Point(25, 20);
      lblFec.Name = "lblFec";
      lblFec.Size = new Size(158, 21);
      lblFec.TabIndex = 0;
      lblFec.Text = "Fecha de Admisión:";
      // 
      // dtpFecha
      // 
      dtpFecha.Format = DateTimePickerFormat.Short;
      dtpFecha.Location = new Point(170, 17);
      dtpFecha.Name = "dtpFecha";
      dtpFecha.Size = new Size(130, 29);
      dtpFecha.TabIndex = 1;
      dtpFecha.ValueChanged += DtpFecha_ValueChanged;
      // 
      // btnBuscar
      // 
      btnBuscar.BackColor = Color.FromArgb(0, 70, 148);
      btnBuscar.Cursor = Cursors.Hand;
      btnBuscar.FlatAppearance.BorderSize = 0;
      btnBuscar.FlatStyle = FlatStyle.Flat;
      btnBuscar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      btnBuscar.ForeColor = Color.White;
      btnBuscar.Location = new Point(310, 13);
      btnBuscar.Name = "btnBuscar";
      btnBuscar.Padding = new Padding(12, 0, 12, 0);
      btnBuscar.Size = new Size(135, 36);
      btnBuscar.TabIndex = 2;
      btnBuscar.Text = "🔄 Actualizar";
      btnBuscar.UseVisualStyleBackColor = false;
      btnBuscar.Click += BtnBuscar_Click;
      // 
      // btnConfirmarPresencia
      // 
      btnConfirmarPresencia.BackColor = Color.FromArgb(21, 128, 61);
      btnConfirmarPresencia.Cursor = Cursors.Hand;
      btnConfirmarPresencia.FlatAppearance.BorderSize = 0;
      btnConfirmarPresencia.FlatStyle = FlatStyle.Flat;
      btnConfirmarPresencia.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      btnConfirmarPresencia.ForeColor = Color.White;
      btnConfirmarPresencia.Location = new Point(450, 13);
      btnConfirmarPresencia.Name = "btnConfirmarPresencia";
      btnConfirmarPresencia.Padding = new Padding(12, 0, 12, 0);
      btnConfirmarPresencia.Size = new Size(190, 36);
      btnConfirmarPresencia.TabIndex = 3;
      btnConfirmarPresencia.Text = "✅ Confirmar Presencia";
      btnConfirmarPresencia.UseVisualStyleBackColor = false;
      btnConfirmarPresencia.Click += BtnConfirmarPresencia_Click;
      // 
      // btnRegistrarAusencia
      // 
      btnRegistrarAusencia.BackColor = Color.FromArgb(185, 28, 28);
      btnRegistrarAusencia.Cursor = Cursors.Hand;
      btnRegistrarAusencia.FlatAppearance.BorderSize = 0;
      btnRegistrarAusencia.FlatStyle = FlatStyle.Flat;
      btnRegistrarAusencia.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      btnRegistrarAusencia.ForeColor = Color.White;
      btnRegistrarAusencia.Location = new Point(650, 13);
      btnRegistrarAusencia.Name = "btnRegistrarAusencia";
      btnRegistrarAusencia.Padding = new Padding(12, 0, 12, 0);
      btnRegistrarAusencia.Size = new Size(230, 36);
      btnRegistrarAusencia.TabIndex = 4;
      btnRegistrarAusencia.Text = "⚠️ Registrar Ausencia (Multa)";
      btnRegistrarAusencia.UseVisualStyleBackColor = false;
      btnRegistrarAusencia.Click += BtnRegistrarAusencia_Click;
      // 
      // btnVerMultas
      // 
      btnVerMultas.BackColor = Color.White;
      btnVerMultas.Cursor = Cursors.Hand;
      btnVerMultas.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
      btnVerMultas.FlatStyle = FlatStyle.Flat;
      btnVerMultas.Font = new Font("Segoe UI", 9.5F);
      btnVerMultas.ForeColor = Color.FromArgb(30, 41, 59);
      btnVerMultas.Location = new Point(890, 13);
      btnVerMultas.Name = "btnVerMultas";
      btnVerMultas.Padding = new Padding(10, 0, 10, 0);
      btnVerMultas.Size = new Size(160, 36);
      btnVerMultas.TabIndex = 5;
      btnVerMultas.Text = "💳 Cobro de Multas";
      btnVerMultas.UseVisualStyleBackColor = false;
      btnVerMultas.Click += BtnVerMultas_Click;
      // 
      // pnlGrid
      // 
      pnlGrid.BackColor = Color.FromArgb(240, 244, 248);
      pnlGrid.Controls.Add(gridAdmision);
      pnlGrid.Dock = DockStyle.Fill;
      pnlGrid.Location = new Point(0, 230);
      pnlGrid.Name = "pnlGrid";
      pnlGrid.Padding = new Padding(25, 15, 25, 10);
      pnlGrid.Size = new Size(1560, 480);
      pnlGrid.TabIndex = 3;
      // 
      // gridAdmision
      // 
      gridAdmision.AllowUserToAddRows = false;
      gridAdmision.AllowUserToDeleteRows = false;
      gridAdmision.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
      gridAdmision.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      gridAdmision.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      gridAdmision.BackgroundColor = Color.White;
      gridAdmision.BorderStyle = BorderStyle.None;
      gridAdmision.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      gridAdmision.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 70, 148);
      dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      dataGridViewCellStyle2.ForeColor = Color.White;
      dataGridViewCellStyle2.Padding = new Padding(12, 10, 12, 10);
      dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      gridAdmision.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      gridAdmision.ColumnHeadersHeight = 42;
      gridAdmision.Columns.AddRange(new DataGridViewColumn[] { colHora, colPaciente, colOdontologo, colEspecialidad, colEstado });
      dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = Color.White;
      dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F);
      dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 41, 59);
      dataGridViewCellStyle3.Padding = new Padding(10, 4, 10, 4);
      dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(224, 236, 248);
      dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(0, 51, 112);
      dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
      gridAdmision.DefaultCellStyle = dataGridViewCellStyle3;
      gridAdmision.Dock = DockStyle.Fill;
      gridAdmision.EnableHeadersVisualStyles = false;
      gridAdmision.GridColor = Color.FromArgb(235, 240, 245);
      gridAdmision.Location = new Point(25, 15);
      gridAdmision.MultiSelect = false;
      gridAdmision.Name = "gridAdmision";
      gridAdmision.ReadOnly = true;
      gridAdmision.RowHeadersVisible = false;
      gridAdmision.RowHeadersWidth = 51;
      gridAdmision.RowTemplate.Height = 40;
      gridAdmision.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      gridAdmision.Size = new Size(1510, 455);
      gridAdmision.TabIndex = 0;
      gridAdmision.CellFormatting += GridAdmision_CellFormatting;
      // 
      // colHora
      // 
      colHora.DataPropertyName = "HorarioTurno";
      colHora.HeaderText = "Horario";
      colHora.Name = "colHora";
      colHora.ReadOnly = true;
      colHora.Width = 90;
      // 
      // colPaciente
      // 
      colPaciente.DataPropertyName = "PacienteNombre";
      colPaciente.HeaderText = "Paciente Citado";
      colPaciente.Name = "colPaciente";
      colPaciente.ReadOnly = true;
      colPaciente.Width = 240;
      // 
      // colOdontologo
      // 
      colOdontologo.DataPropertyName = "OdontologoNombre";
      colOdontologo.HeaderText = "Profesional Asignado";
      colOdontologo.Name = "colOdontologo";
      colOdontologo.ReadOnly = true;
      colOdontologo.Width = 230;
      // 
      // colEspecialidad
      // 
      colEspecialidad.DataPropertyName = "EspecialidadNombre";
      colEspecialidad.HeaderText = "Especialidad";
      colEspecialidad.Name = "colEspecialidad";
      colEspecialidad.ReadOnly = true;
      colEspecialidad.Width = 200;
      // 
      // colEstado
      // 
      colEstado.DataPropertyName = "EstadoTurno";
      colEstado.HeaderText = "Estado Actual";
      colEstado.Name = "colEstado";
      colEstado.ReadOnly = true;
      colEstado.Width = 180;
      // 
      // lblEstado
      // 
      lblEstado.BackColor = Color.White;
      lblEstado.Dock = DockStyle.Bottom;
      lblEstado.Font = new Font("Segoe UI", 8.5F);
      lblEstado.ForeColor = Color.FromArgb(100, 116, 139);
      lblEstado.Location = new Point(0, 710);
      lblEstado.Name = "lblEstado";
      lblEstado.Padding = new Padding(25, 6, 0, 0);
      lblEstado.Size = new Size(1560, 32);
      lblEstado.TabIndex = 4;
      lblEstado.Text = "Cargando citas...";
      // 
      // AdmisionControl
      // 
      BackColor = Color.FromArgb(240, 244, 248);
      Controls.Add(pnlGrid);
      Controls.Add(lblEstado);
      Controls.Add(pnlBar);
      Controls.Add(pnlStats);
      Controls.Add(pnlTop);
      Font = new Font("Segoe UI", 9.5F);
      Name = "AdmisionControl";
      Size = new Size(1560, 742);
      pnlTop.ResumeLayout(false);
      pnlTop.PerformLayout();
      pnlBar.ResumeLayout(false);
      pnlBar.PerformLayout();
      pnlGrid.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)gridAdmision).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.FlowLayoutPanel pnlStats;
        private System.Windows.Forms.Panel pnlBar;
        private System.Windows.Forms.Label lblFec;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnConfirmarPresencia;
        private System.Windows.Forms.Button btnRegistrarAusencia;
        private System.Windows.Forms.Button btnVerMultas;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView gridAdmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOdontologo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Label lblEstado;
    }
}
