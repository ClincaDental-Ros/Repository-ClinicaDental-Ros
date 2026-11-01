#nullable disable

namespace WindowsForms
{
    partial class InsumoListaControl
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
            this.pnlBar = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gridInsumos = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBar.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsumos)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(392, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Control de Insumos, Materiales y Stock Clínico";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(27, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(346, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Inventario odontológico, costos unitarios y control de stock crítico";
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
            // pnlBar
            //
            this.pnlBar.BackColor = System.Drawing.Color.White;
            this.pnlBar.Controls.Add(this.btnNuevo);
            this.pnlBar.Controls.Add(this.btnEditar);
            this.pnlBar.Controls.Add(this.btnEliminar);
            this.pnlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBar.Location = new System.Drawing.Point(0, 165);
            this.pnlBar.Name = "pnlBar";
            this.pnlBar.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.pnlBar.Size = new System.Drawing.Size(1000, 65);
            this.pnlBar.TabIndex = 2;
            //
            // btnNuevo
            //
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(25, 13);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnNuevo.Size = new System.Drawing.Size(170, 36);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "+ Nuevo Insumo";
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
            this.btnEditar.Location = new System.Drawing.Point(205, 13);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnEditar.Size = new System.Drawing.Size(130, 36);
            this.btnEditar.TabIndex = 1;
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
            this.btnEliminar.Location = new System.Drawing.Point(345, 13);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnEliminar.Size = new System.Drawing.Size(120, 36);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "🗑️ Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            //
            // pnlGrid
            //
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlGrid.Controls.Add(this.gridInsumos);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 230);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);
            this.pnlGrid.Size = new System.Drawing.Size(1000, 388);
            this.pnlGrid.TabIndex = 3;
            //
            // gridInsumos
            //
            this.gridInsumos.AllowUserToAddRows = false;
            this.gridInsumos.AllowUserToDeleteRows = false;
            this.gridInsumos.AllowUserToResizeRows = false;
            alternatingRowStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.gridInsumos.AlternatingRowsDefaultCellStyle = alternatingRowStyle;
            this.gridInsumos.AutoGenerateColumns = false;
            this.gridInsumos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInsumos.BackgroundColor = System.Drawing.Color.White;
            this.gridInsumos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInsumos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridInsumos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            columnHeaderStyle.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            columnHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            columnHeaderStyle.ForeColor = System.Drawing.Color.White;
            columnHeaderStyle.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.gridInsumos.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            this.gridInsumos.ColumnHeadersHeight = 42;
            this.gridInsumos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNombre,
            this.colDescripcion,
            this.colPrecio,
            this.colStock});
            defaultCellStyle.BackColor = System.Drawing.Color.White;
            defaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            defaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            defaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            defaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 236, 248);
            defaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 51, 112);
            this.gridInsumos.DefaultCellStyle = defaultCellStyle;
            this.gridInsumos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInsumos.EnableHeadersVisualStyles = false;
            this.gridInsumos.GridColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.gridInsumos.Location = new System.Drawing.Point(25, 15);
            this.gridInsumos.MultiSelect = false;
            this.gridInsumos.Name = "gridInsumos";
            this.gridInsumos.ReadOnly = true;
            this.gridInsumos.RowHeadersVisible = false;
            this.gridInsumos.RowTemplate.Height = 40;
            this.gridInsumos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInsumos.Size = new System.Drawing.Size(950, 363);
            this.gridInsumos.TabIndex = 0;
            this.gridInsumos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridInsumos_CellDoubleClick);
            this.gridInsumos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridInsumos_CellFormatting);
            //
            // colId
            //
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "Id";
            this.colId.ReadOnly = true;
            this.colId.Width = 60;
            //
            // colNombre
            //
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Insumo / Material";
            this.colNombre.Name = "Nombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 260;
            //
            // colDescripcion
            //
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "Descripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 280;
            //
            // colPrecio
            //
            this.colPrecio.DataPropertyName = "Precio";
            this.colPrecio.HeaderText = "Precio Unitario ($)";
            this.colPrecio.Name = "Precio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 160;
            //
            // colStock
            //
            this.colStock.DataPropertyName = "Stock";
            this.colStock.HeaderText = "Stock Disponible";
            this.colStock.Name = "Stock";
            this.colStock.ReadOnly = true;
            this.colStock.Width = 150;
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
            this.lblEstado.Text = "Cargando inventario...";
            //
            // InsumoListaControl
            //
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.pnlBar);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "InsumoListaControl";
            this.Size = new System.Drawing.Size(1000, 650);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBar.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInsumos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.FlowLayoutPanel pnlStats;
        private System.Windows.Forms.Panel pnlBar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView gridInsumos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.Label lblEstado;
    }
}
