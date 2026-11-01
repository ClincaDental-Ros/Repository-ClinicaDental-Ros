#nullable disable

namespace WindowsForms
{
    partial class OdontologoListaControl
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
            System.Windows.Forms.DataGridViewCellStyle columnHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle defaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternatingRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.lblEsp = new System.Windows.Forms.Label();
            this.cbFiltroEspecialidad = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gridOdontologos = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOdontologos)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(238, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cuerpo Médico Odontológico";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(27, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(421, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Plantel de profesionales, matrículas habilitadas y asignación de especialidades";
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
            this.pnlFilters.Controls.Add(this.lblEsp);
            this.pnlFilters.Controls.Add(this.cbFiltroEspecialidad);
            this.pnlFilters.Controls.Add(this.btnBuscar);
            this.pnlFilters.Controls.Add(this.btnNuevo);
            this.pnlFilters.Controls.Add(this.btnEditar);
            this.pnlFilters.Controls.Add(this.btnEliminar);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 165);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.pnlFilters.Size = new System.Drawing.Size(1000, 65);
            this.pnlFilters.TabIndex = 2;
            //
            // lblEsp
            //
            this.lblEsp.AutoSize = true;
            this.lblEsp.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEsp.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblEsp.Location = new System.Drawing.Point(25, 20);
            this.lblEsp.Name = "lblEsp";
            this.lblEsp.Size = new System.Drawing.Size(86, 17);
            this.lblEsp.TabIndex = 0;
            this.lblEsp.Text = "Especialidad:";
            //
            // cbFiltroEspecialidad
            //
            this.cbFiltroEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroEspecialidad.FormattingEnabled = true;
            this.cbFiltroEspecialidad.Location = new System.Drawing.Point(125, 17);
            this.cbFiltroEspecialidad.Name = "cbFiltroEspecialidad";
            this.cbFiltroEspecialidad.Size = new System.Drawing.Size(260, 24);
            this.cbFiltroEspecialidad.TabIndex = 1;
            this.cbFiltroEspecialidad.SelectedIndexChanged += new System.EventHandler(this.CbFiltroEspecialidad_SelectedIndexChanged);
            //
            // btnBuscar
            //
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(400, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnBuscar.Size = new System.Drawing.Size(120, 36);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "🔄 Refrescar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            //
            // btnNuevo
            //
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(535, 13);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnNuevo.Size = new System.Drawing.Size(180, 36);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "+ Nuevo Profesional";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            //
            // btnEditar
            //
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnEditar.FlatAppearance.BorderSize = 1;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnEditar.Location = new System.Drawing.Point(725, 13);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnEditar.Size = new System.Drawing.Size(120, 36);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "✏️ Modificar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            //
            // btnEliminar
            //
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(855, 13);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnEliminar.Size = new System.Drawing.Size(110, 36);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "🗑️ Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            //
            // pnlGrid
            //
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlGrid.Controls.Add(this.gridOdontologos);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 230);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);
            this.pnlGrid.Size = new System.Drawing.Size(1000, 388);
            this.pnlGrid.TabIndex = 3;
            //
            // gridOdontologos
            //
            this.gridOdontologos.AllowUserToAddRows = false;
            this.gridOdontologos.AllowUserToDeleteRows = false;
            this.gridOdontologos.AllowUserToResizeRows = false;
            alternatingRowStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.gridOdontologos.AlternatingRowsDefaultCellStyle = alternatingRowStyle;
            this.gridOdontologos.AutoGenerateColumns = false;
            this.gridOdontologos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridOdontologos.BackgroundColor = System.Drawing.Color.White;
            this.gridOdontologos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridOdontologos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridOdontologos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            columnHeaderStyle.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            columnHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            columnHeaderStyle.ForeColor = System.Drawing.Color.White;
            columnHeaderStyle.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.gridOdontologos.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            this.gridOdontologos.ColumnHeadersHeight = 42;
            this.gridOdontologos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colMatricula,
            this.colApellido,
            this.colNombre,
            this.colEspecialidad,
            this.colTelefono,
            this.colMail});
            defaultCellStyle.BackColor = System.Drawing.Color.White;
            defaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            defaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            defaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            defaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 236, 248);
            defaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 51, 112);
            this.gridOdontologos.DefaultCellStyle = defaultCellStyle;
            this.gridOdontologos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOdontologos.EnableHeadersVisualStyles = false;
            this.gridOdontologos.GridColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.gridOdontologos.Location = new System.Drawing.Point(25, 15);
            this.gridOdontologos.MultiSelect = false;
            this.gridOdontologos.Name = "gridOdontologos";
            this.gridOdontologos.ReadOnly = true;
            this.gridOdontologos.RowHeadersVisible = false;
            this.gridOdontologos.RowTemplate.Height = 40;
            this.gridOdontologos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOdontologos.Size = new System.Drawing.Size(950, 363);
            this.gridOdontologos.TabIndex = 0;
            this.gridOdontologos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridOdontologos_CellDoubleClick);
            //
            // colId
            //
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "Id";
            this.colId.ReadOnly = true;
            this.colId.Width = 60;
            //
            // colMatricula
            //
            this.colMatricula.DataPropertyName = "NumMatricula";
            this.colMatricula.HeaderText = "Matrícula Nac.";
            this.colMatricula.Name = "Matricula";
            this.colMatricula.ReadOnly = true;
            this.colMatricula.Width = 130;
            //
            // colApellido
            //
            this.colApellido.DataPropertyName = "Apellido";
            this.colApellido.HeaderText = "Apellido";
            this.colApellido.Name = "Apellido";
            this.colApellido.ReadOnly = true;
            this.colApellido.Width = 160;
            //
            // colNombre
            //
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "Nombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 160;
            //
            // colEspecialidad
            //
            this.colEspecialidad.DataPropertyName = "EspecialidadNombre";
            this.colEspecialidad.HeaderText = "Especialidad Principal";
            this.colEspecialidad.Name = "Especialidad";
            this.colEspecialidad.ReadOnly = true;
            this.colEspecialidad.Width = 200;
            //
            // colTelefono
            //
            this.colTelefono.DataPropertyName = "Telefono";
            this.colTelefono.HeaderText = "Teléfono Directo";
            this.colTelefono.Name = "Telefono";
            this.colTelefono.ReadOnly = true;
            this.colTelefono.Width = 140;
            //
            // colMail
            //
            this.colMail.DataPropertyName = "Mail";
            this.colMail.HeaderText = "Correo Electrónico";
            this.colMail.Name = "Mail";
            this.colMail.ReadOnly = true;
            this.colMail.Width = 220;
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
            this.lblEstado.Text = "Cargando odontólogos...";
            //
            // OdontologoListaControl
            //
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "OdontologoListaControl";
            this.Size = new System.Drawing.Size(1000, 650);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOdontologos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.FlowLayoutPanel pnlStats;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblEsp;
        private System.Windows.Forms.ComboBox cbFiltroEspecialidad;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView gridOdontologos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMail;
        private System.Windows.Forms.Label lblEstado;
    }
}
