#nullable disable

namespace WindowsForms
{
    partial class TurnoListaControl
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.chkFiltrarFecha = new System.Windows.Forms.CheckBox();
            this.dtpFiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.lblEst = new System.Windows.Forms.Label();
            this.cbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblOdo = new System.Windows.Forms.Label();
            this.cbFiltroOdontologo = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnModificarTurno = new System.Windows.Forms.Button();
            this.btnCancelarTurno = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gridTurnos = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOdontologo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(344, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Gestión de Turnos y Agenda Odontológica";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(27, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(392, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Monitoreo de citas, estados de atención, cancelaciones y sala de espera";
            //
            // pnlStats
            //
            this.pnlStats.AutoScroll = true;
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 70);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(25, 10, 25, 5);
            this.pnlStats.Size = new System.Drawing.Size(1000, 95);
            this.pnlStats.TabIndex = 1;
            this.pnlStats.WrapContents = false;
            //
            // pnlFilters
            //
            this.pnlFilters.BackColor = System.Drawing.Color.White;
            this.pnlFilters.Controls.Add(this.chkFiltrarFecha);
            this.pnlFilters.Controls.Add(this.dtpFiltroFecha);
            this.pnlFilters.Controls.Add(this.lblEst);
            this.pnlFilters.Controls.Add(this.cbFiltroEstado);
            this.pnlFilters.Controls.Add(this.lblOdo);
            this.pnlFilters.Controls.Add(this.cbFiltroOdontologo);
            this.pnlFilters.Controls.Add(this.btnBuscar);
            this.pnlFilters.Controls.Add(this.btnReservar);
            this.pnlFilters.Controls.Add(this.btnModificarTurno);
            this.pnlFilters.Controls.Add(this.btnCancelarTurno);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 165);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.pnlFilters.Size = new System.Drawing.Size(1000, 65);
            this.pnlFilters.TabIndex = 2;
            //
            // chkFiltrarFecha
            //
            this.chkFiltrarFecha.AutoSize = true;
            this.chkFiltrarFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkFiltrarFecha.Location = new System.Drawing.Point(25, 20);
            this.chkFiltrarFecha.Name = "chkFiltrarFecha";
            this.chkFiltrarFecha.Size = new System.Drawing.Size(66, 21);
            this.chkFiltrarFecha.TabIndex = 0;
            this.chkFiltrarFecha.Text = "Fecha:";
            this.chkFiltrarFecha.CheckedChanged += new System.EventHandler(this.ChkFiltrarFecha_CheckedChanged);
            //
            // dtpFiltroFecha
            //
            this.dtpFiltroFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroFecha.Location = new System.Drawing.Point(95, 17);
            this.dtpFiltroFecha.Name = "dtpFiltroFecha";
            this.dtpFiltroFecha.Size = new System.Drawing.Size(120, 24);
            this.dtpFiltroFecha.TabIndex = 1;
            this.dtpFiltroFecha.ValueChanged += new System.EventHandler(this.DtpFiltroFecha_ValueChanged);
            //
            // lblEst
            //
            this.lblEst.AutoSize = true;
            this.lblEst.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEst.Location = new System.Drawing.Point(230, 20);
            this.lblEst.Name = "lblEst";
            this.lblEst.Size = new System.Drawing.Size(52, 17);
            this.lblEst.TabIndex = 2;
            this.lblEst.Text = "Estado:";
            //
            // cbFiltroEstado
            //
            this.cbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroEstado.Items.AddRange(new object[] {
            "Todos los estados",
            "Pendiente",
            "Presente",
            "Atendido",
            "Cancelado",
            "NoAsistido"});
            this.cbFiltroEstado.Location = new System.Drawing.Point(290, 17);
            this.cbFiltroEstado.Name = "cbFiltroEstado";
            this.cbFiltroEstado.Size = new System.Drawing.Size(150, 25);
            this.cbFiltroEstado.TabIndex = 3;
            this.cbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.CbFiltroEstado_SelectedIndexChanged);
            //
            // lblOdo
            //
            this.lblOdo.AutoSize = true;
            this.lblOdo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOdo.Location = new System.Drawing.Point(460, 20);
            this.lblOdo.Name = "lblOdo";
            this.lblOdo.Size = new System.Drawing.Size(87, 17);
            this.lblOdo.TabIndex = 4;
            this.lblOdo.Text = "Odontólogo:";
            //
            // cbFiltroOdontologo
            //
            this.cbFiltroOdontologo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroOdontologo.Location = new System.Drawing.Point(555, 17);
            this.cbFiltroOdontologo.Name = "cbFiltroOdontologo";
            this.cbFiltroOdontologo.Size = new System.Drawing.Size(200, 25);
            this.cbFiltroOdontologo.TabIndex = 5;
            this.cbFiltroOdontologo.SelectedIndexChanged += new System.EventHandler(this.CbFiltroOdontologo_SelectedIndexChanged);
            //
            // btnBuscar
            //
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(770, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnBuscar.Size = new System.Drawing.Size(110, 36);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "🔍 Filtrar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            //
            // btnReservar
            //
            this.btnReservar.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnReservar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservar.FlatAppearance.BorderSize = 0;
            this.btnReservar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReservar.ForeColor = System.Drawing.Color.White;
            this.btnReservar.Location = new System.Drawing.Point(890, 13);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnReservar.Size = new System.Drawing.Size(170, 36);
            this.btnReservar.TabIndex = 7;
            this.btnReservar.Text = "📅 + Agendar Turno";
            this.btnReservar.UseVisualStyleBackColor = false;
            this.btnReservar.Click += new System.EventHandler(this.BtnReservar_Click);
            //
            // btnModificarTurno
            //
            this.btnModificarTurno.BackColor = System.Drawing.Color.White;
            this.btnModificarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarTurno.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnModificarTurno.FlatAppearance.BorderSize = 1;
            this.btnModificarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarTurno.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificarTurno.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnModificarTurno.Location = new System.Drawing.Point(1070, 13);
            this.btnModificarTurno.Name = "btnModificarTurno";
            this.btnModificarTurno.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnModificarTurno.Size = new System.Drawing.Size(120, 36);
            this.btnModificarTurno.TabIndex = 8;
            this.btnModificarTurno.Text = "✏️ Modificar";
            this.btnModificarTurno.UseVisualStyleBackColor = false;
            this.btnModificarTurno.Click += new System.EventHandler(this.BtnModificarTurno_Click);
            //
            // btnCancelarTurno
            //
            this.btnCancelarTurno.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnCancelarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarTurno.FlatAppearance.BorderSize = 0;
            this.btnCancelarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarTurno.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelarTurno.ForeColor = System.Drawing.Color.White;
            this.btnCancelarTurno.Location = new System.Drawing.Point(1200, 13);
            this.btnCancelarTurno.Name = "btnCancelarTurno";
            this.btnCancelarTurno.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnCancelarTurno.Size = new System.Drawing.Size(140, 36);
            this.btnCancelarTurno.TabIndex = 9;
            this.btnCancelarTurno.Text = "❌ Cancelar Turno";
            this.btnCancelarTurno.UseVisualStyleBackColor = false;
            this.btnCancelarTurno.Click += new System.EventHandler(this.BtnCancelarTurno_Click);
            //
            // pnlGrid
            //
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlGrid.Controls.Add(this.gridTurnos);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 230);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);
            this.pnlGrid.Size = new System.Drawing.Size(1000, 388);
            this.pnlGrid.TabIndex = 3;
            //
            // gridTurnos
            //
            this.gridTurnos.AllowUserToAddRows = false;
            this.gridTurnos.AllowUserToDeleteRows = false;
            this.gridTurnos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.gridTurnos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTurnos.AutoGenerateColumns = false;
            this.gridTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTurnos.BackgroundColor = System.Drawing.Color.White;
            this.gridTurnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTurnos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridTurnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTurnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridTurnos.ColumnHeadersHeight = 42;
            this.gridTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFecha,
            this.colHora,
            this.colPaciente,
            this.colOdontologo,
            this.colEspecialidad,
            this.colEstado,
            this.colMotivo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(224, 236, 248);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(0, 51, 112);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTurnos.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTurnos.EnableHeadersVisualStyles = false;
            this.gridTurnos.GridColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.gridTurnos.Location = new System.Drawing.Point(25, 15);
            this.gridTurnos.MultiSelect = false;
            this.gridTurnos.Name = "gridTurnos";
            this.gridTurnos.ReadOnly = true;
            this.gridTurnos.RowHeadersVisible = false;
            this.gridTurnos.RowTemplate.Height = 40;
            this.gridTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTurnos.Size = new System.Drawing.Size(950, 363);
            this.gridTurnos.TabIndex = 0;
            this.gridTurnos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridTurnos_CellFormatting);
            //
            // colId
            //
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "Id";
            this.colId.ReadOnly = true;
            this.colId.Width = 60;
            //
            // colFecha
            //
            this.colFecha.HeaderText = "Fecha Cita";
            this.colFecha.Name = "Fecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 110;
            //
            // colHora
            //
            this.colHora.DataPropertyName = "HorarioTurno";
            this.colHora.HeaderText = "Horario";
            this.colHora.Name = "Hora";
            this.colHora.ReadOnly = true;
            this.colHora.Width = 90;
            //
            // colPaciente
            //
            this.colPaciente.DataPropertyName = "PacienteNombre";
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.Name = "Paciente";
            this.colPaciente.ReadOnly = true;
            this.colPaciente.Width = 200;
            //
            // colOdontologo
            //
            this.colOdontologo.DataPropertyName = "OdontologoNombre";
            this.colOdontologo.HeaderText = "Odontólogo Asignado";
            this.colOdontologo.Name = "Odontologo";
            this.colOdontologo.ReadOnly = true;
            this.colOdontologo.Width = 200;
            //
            // colEspecialidad
            //
            this.colEspecialidad.DataPropertyName = "EspecialidadNombre";
            this.colEspecialidad.HeaderText = "Especialidad";
            this.colEspecialidad.Name = "Especialidad";
            this.colEspecialidad.ReadOnly = true;
            this.colEspecialidad.Width = 170;
            //
            // colEstado
            //
            this.colEstado.DataPropertyName = "EstadoTurno";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "Estado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 150;
            //
            // colMotivo
            //
            this.colMotivo.DataPropertyName = "MotivoCancelacion";
            this.colMotivo.HeaderText = "Observación / Motivo";
            this.colMotivo.Name = "Motivo";
            this.colMotivo.ReadOnly = true;
            this.colMotivo.Width = 200;
            //
            // lblEstado
            //
            this.lblEstado.BackColor = System.Drawing.Color.White;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEstado.Location = new System.Drawing.Point(0, 618);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Padding = new System.Windows.Forms.Padding(25, 6, 0, 0);
            this.lblEstado.Size = new System.Drawing.Size(1000, 32);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Cargando turnos...";
            //
            // TurnoListaControl
            //
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "TurnoListaControl";
            this.Size = new System.Drawing.Size(1000, 650);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.FlowLayoutPanel pnlStats;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.CheckBox chkFiltrarFecha;
        private System.Windows.Forms.DateTimePicker dtpFiltroFecha;
        private System.Windows.Forms.Label lblEst;
        private System.Windows.Forms.ComboBox cbFiltroEstado;
        private System.Windows.Forms.Label lblOdo;
        private System.Windows.Forms.ComboBox cbFiltroOdontologo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnModificarTurno;
        private System.Windows.Forms.Button btnCancelarTurno;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView gridTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOdontologo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.Label lblEstado;
    }
}
