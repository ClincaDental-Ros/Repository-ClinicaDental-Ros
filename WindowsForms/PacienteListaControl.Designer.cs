#nullable disable

namespace WindowsForms
{
    partial class PacienteListaControl
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.chkSoloHabilitados = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnToggleEstado = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gridPacientes = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPacientes)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(316, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Gestión de Pacientes y Fichas Médicas";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(27, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(442, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Padrón general, control de habilitaciones, obras sociales y antecedentes clínicos";
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
            this.pnlFilters.Controls.Add(this.lblSearch);
            this.pnlFilters.Controls.Add(this.txtBuscar);
            this.pnlFilters.Controls.Add(this.chkSoloHabilitados);
            this.pnlFilters.Controls.Add(this.btnBuscar);
            this.pnlFilters.Controls.Add(this.btnNuevo);
            this.pnlFilters.Controls.Add(this.btnEditar);
            this.pnlFilters.Controls.Add(this.btnToggleEstado);
            this.pnlFilters.Controls.Add(this.btnEliminar);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 165);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.pnlFilters.Size = new System.Drawing.Size(1000, 65);
            this.pnlFilters.TabIndex = 2;
            //
            // lblSearch
            //
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblSearch.Location = new System.Drawing.Point(15, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(51, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Buscar:";
            //
            // txtBuscar
            //
            this.txtBuscar.Location = new System.Drawing.Point(75, 17);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Nombre, Apellido, DNI o Email...";
            this.txtBuscar.Size = new System.Drawing.Size(220, 24);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBuscar_KeyDown);
            //
            // chkSoloHabilitados
            //
            this.chkSoloHabilitados.AutoSize = true;
            this.chkSoloHabilitados.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkSoloHabilitados.Location = new System.Drawing.Point(305, 19);
            this.chkSoloHabilitados.Name = "chkSoloHabilitados";
            this.chkSoloHabilitados.Size = new System.Drawing.Size(119, 21);
            this.chkSoloHabilitados.TabIndex = 2;
            this.chkSoloHabilitados.Text = "Solo Habilitados";
            this.chkSoloHabilitados.UseVisualStyleBackColor = true;
            this.chkSoloHabilitados.CheckedChanged += new System.EventHandler(this.ChkSoloHabilitados_CheckedChanged);
            //
            // btnBuscar
            //
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(440, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnBuscar.Size = new System.Drawing.Size(100, 36);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "🔍 Buscar";
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
            this.btnNuevo.Location = new System.Drawing.Point(550, 13);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnNuevo.Size = new System.Drawing.Size(140, 36);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "+ Nuevo Paciente";
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
            this.btnEditar.Location = new System.Drawing.Point(700, 13);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnEditar.Size = new System.Drawing.Size(110, 36);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "✏️ Modificar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            //
            // btnToggleEstado
            //
            this.btnToggleEstado.BackColor = System.Drawing.Color.White;
            this.btnToggleEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleEstado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnToggleEstado.FlatAppearance.BorderSize = 1;
            this.btnToggleEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnToggleEstado.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnToggleEstado.Location = new System.Drawing.Point(820, 13);
            this.btnToggleEstado.Name = "btnToggleEstado";
            this.btnToggleEstado.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnToggleEstado.Size = new System.Drawing.Size(130, 36);
            this.btnToggleEstado.TabIndex = 6;
            this.btnToggleEstado.Text = "🔒 Cambiar Estado";
            this.btnToggleEstado.UseVisualStyleBackColor = false;
            this.btnToggleEstado.Click += new System.EventHandler(this.BtnToggleEstado_Click);
            //
            // btnEliminar
            //
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(960, 13);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnEliminar.Size = new System.Drawing.Size(100, 36);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "🗑️ Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            //
            // pnlGrid
            //
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlGrid.Controls.Add(this.gridPacientes);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 230);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);
            this.pnlGrid.Size = new System.Drawing.Size(1000, 388);
            this.pnlGrid.TabIndex = 3;
            //
            // gridPacientes
            //
            this.gridPacientes.AllowUserToAddRows = false;
            this.gridPacientes.AllowUserToDeleteRows = false;
            this.gridPacientes.AllowUserToResizeRows = false;
            alternatingRowStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.gridPacientes.AlternatingRowsDefaultCellStyle = alternatingRowStyle;
            this.gridPacientes.AutoGenerateColumns = false;
            this.gridPacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPacientes.BackgroundColor = System.Drawing.Color.White;
            this.gridPacientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPacientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridPacientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            columnHeaderStyle.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            columnHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            columnHeaderStyle.ForeColor = System.Drawing.Color.White;
            columnHeaderStyle.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.gridPacientes.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            this.gridPacientes.ColumnHeadersHeight = 42;
            this.gridPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDni,
            this.colApellido,
            this.colNombre,
            this.colUsername,
            this.colTelefono,
            this.colMail,
            this.colObraSocial,
            this.colEstado});
            defaultCellStyle.BackColor = System.Drawing.Color.White;
            defaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            defaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            defaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            defaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 236, 248);
            defaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 51, 112);
            this.gridPacientes.DefaultCellStyle = defaultCellStyle;
            this.gridPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPacientes.EnableHeadersVisualStyles = false;
            this.gridPacientes.GridColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.gridPacientes.Location = new System.Drawing.Point(25, 15);
            this.gridPacientes.MultiSelect = false;
            this.gridPacientes.Name = "gridPacientes";
            this.gridPacientes.ReadOnly = true;
            this.gridPacientes.RowHeadersVisible = false;
            this.gridPacientes.RowTemplate.Height = 40;
            this.gridPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPacientes.Size = new System.Drawing.Size(950, 363);
            this.gridPacientes.TabIndex = 0;
            this.gridPacientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPacientes_CellDoubleClick);
            this.gridPacientes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridPacientes_CellFormatting);
            //
            // colId
            //
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "Id";
            this.colId.ReadOnly = true;
            this.colId.Width = 60;
            //
            // colDni
            //
            this.colDni.DataPropertyName = "Dni";
            this.colDni.HeaderText = "DNI / Doc.";
            this.colDni.Name = "Dni";
            this.colDni.ReadOnly = true;
            this.colDni.Width = 110;
            //
            // colApellido
            //
            this.colApellido.DataPropertyName = "Apellido";
            this.colApellido.HeaderText = "Apellido";
            this.colApellido.Name = "Apellido";
            this.colApellido.ReadOnly = true;
            this.colApellido.Width = 150;
            //
            // colNombre
            //
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "Nombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 150;
            //
            // colUsername
            //
            this.colUsername.DataPropertyName = "Username";
            this.colUsername.HeaderText = "Usuario Portal";
            this.colUsername.Name = "Username";
            this.colUsername.ReadOnly = true;
            this.colUsername.Width = 140;
            //
            // colTelefono
            //
            this.colTelefono.DataPropertyName = "Telefono";
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.Name = "Telefono";
            this.colTelefono.ReadOnly = true;
            this.colTelefono.Width = 130;
            //
            // colMail
            //
            this.colMail.DataPropertyName = "Mail";
            this.colMail.HeaderText = "Correo Electrónico";
            this.colMail.Name = "Mail";
            this.colMail.ReadOnly = true;
            this.colMail.Width = 220;
            //
            // colObraSocial
            //
            this.colObraSocial.DataPropertyName = "ObraSocialNombre";
            this.colObraSocial.HeaderText = "Obra Social / Cobertura";
            this.colObraSocial.Name = "ObraSocial";
            this.colObraSocial.ReadOnly = true;
            this.colObraSocial.Width = 180;
            //
            // colEstado
            //
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "Estado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 140;
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
            this.lblEstado.Text = "Cargando pacientes...";
            //
            // PacienteListaControl
            //
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "PacienteListaControl";
            this.Size = new System.Drawing.Size(1000, 650);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPacientes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.FlowLayoutPanel pnlStats;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.CheckBox chkSoloHabilitados;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnToggleEstado;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView gridPacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObraSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Label lblEstado;
    }
}
