#nullable disable

namespace WindowsForms
{
    partial class CobroControl
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
            this.pnlBar = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gridFacturas = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescuentoOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBar.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(447, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Módulo de Cobro, Caja y Liquidación a Obras Sociales";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(27, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(511, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Emisión de comprobantes, liquidación de coseguros, descuentos de obras sociales y pagos recibidos";
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
            this.pnlBar.Controls.Add(this.btnActualizar);
            this.pnlBar.Controls.Add(this.btnCobrar);
            this.pnlBar.Controls.Add(this.btnNueva);
            this.pnlBar.Controls.Add(this.btnModificar);
            this.pnlBar.Controls.Add(this.btnEliminar);
            this.pnlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBar.Location = new System.Drawing.Point(0, 165);
            this.pnlBar.Name = "pnlBar";
            this.pnlBar.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.pnlBar.Size = new System.Drawing.Size(1000, 65);
            this.pnlBar.TabIndex = 2;
            //
            // btnActualizar
            //
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(25, 13);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnActualizar.Size = new System.Drawing.Size(150, 36);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "🔄 Actualizar Lista";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            //
            // btnCobrar
            //
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobrar.FlatAppearance.BorderSize = 0;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCobrar.ForeColor = System.Drawing.Color.White;
            this.btnCobrar.Location = new System.Drawing.Point(185, 13);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnCobrar.Size = new System.Drawing.Size(210, 36);
            this.btnCobrar.TabIndex = 1;
            this.btnCobrar.Text = "🧾 Abrir Detalle y Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.BtnCobrar_Click);
            //
            // btnNueva
            //
            this.btnNueva.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnNueva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNueva.FlatAppearance.BorderSize = 0;
            this.btnNueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNueva.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNueva.ForeColor = System.Drawing.Color.White;
            this.btnNueva.Location = new System.Drawing.Point(405, 13);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnNueva.Size = new System.Drawing.Size(150, 36);
            this.btnNueva.TabIndex = 2;
            this.btnNueva.Text = "➕ Nueva Factura";
            this.btnNueva.UseVisualStyleBackColor = false;
            this.btnNueva.Click += new System.EventHandler(this.BtnNueva_Click);
            //
            // btnModificar
            //
            this.btnModificar.BackColor = System.Drawing.Color.White;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnModificar.FlatAppearance.BorderSize = 1;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnModificar.Location = new System.Drawing.Point(565, 13);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnModificar.Size = new System.Drawing.Size(130, 36);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "✏️ Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            //
            // btnEliminar
            //
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(705, 13);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnEliminar.Size = new System.Drawing.Size(130, 36);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "🗑️ Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            //
            // pnlGrid
            //
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlGrid.Controls.Add(this.gridFacturas);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 230);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);
            this.pnlGrid.Size = new System.Drawing.Size(1000, 388);
            this.pnlGrid.TabIndex = 3;
            //
            // gridFacturas
            //
            this.gridFacturas.AllowUserToAddRows = false;
            this.gridFacturas.AllowUserToDeleteRows = false;
            this.gridFacturas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.gridFacturas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridFacturas.AutoGenerateColumns = false;
            this.gridFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFacturas.BackgroundColor = System.Drawing.Color.White;
            this.gridFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridFacturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridFacturas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridFacturas.ColumnHeadersHeight = 42;
            this.gridFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFecha,
            this.colPaciente,
            this.colObraSocial,
            this.colTotal,
            this.colDescuentoOS,
            this.colTotalPaciente,
            this.colEstado,
            this.colMetodo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(224, 236, 248);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(0, 51, 112);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridFacturas.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFacturas.EnableHeadersVisualStyles = false;
            this.gridFacturas.GridColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.gridFacturas.Location = new System.Drawing.Point(25, 15);
            this.gridFacturas.MultiSelect = false;
            this.gridFacturas.Name = "gridFacturas";
            this.gridFacturas.ReadOnly = true;
            this.gridFacturas.RowHeadersVisible = false;
            this.gridFacturas.RowTemplate.Height = 40;
            this.gridFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFacturas.Size = new System.Drawing.Size(950, 363);
            this.gridFacturas.TabIndex = 0;
            this.gridFacturas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridFacturas_CellDoubleClick);
            this.gridFacturas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridFacturas_CellFormatting);
            //
            // colId
            //
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Factura N°";
            this.colId.Name = "Id";
            this.colId.ReadOnly = true;
            this.colId.Width = 90;
            //
            // colFecha
            //
            this.colFecha.DataPropertyName = "FechaEmision";
            this.colFecha.HeaderText = "Fecha Emisión";
            this.colFecha.Name = "Fecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 130;
            //
            // colPaciente
            //
            this.colPaciente.DataPropertyName = "PacienteNombre";
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.Name = "Paciente";
            this.colPaciente.ReadOnly = true;
            this.colPaciente.Width = 200;
            //
            // colObraSocial
            //
            this.colObraSocial.DataPropertyName = "ObraSocialNombre";
            this.colObraSocial.HeaderText = "Obra Social";
            this.colObraSocial.Name = "ObraSocial";
            this.colObraSocial.ReadOnly = true;
            this.colObraSocial.Width = 160;
            //
            // colTotal
            //
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "Total Prestación";
            this.colTotal.Name = "Total";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 130;
            //
            // colDescuentoOS
            //
            this.colDescuentoOS.DataPropertyName = "DescuentoObraSocial";
            this.colDescuentoOS.HeaderText = "Desc. Obra Social";
            this.colDescuentoOS.Name = "DescuentoOS";
            this.colDescuentoOS.ReadOnly = true;
            this.colDescuentoOS.Width = 140;
            //
            // colTotalPaciente
            //
            this.colTotalPaciente.DataPropertyName = "MontoAPagarPaciente";
            this.colTotalPaciente.HeaderText = "A Pagar Paciente";
            this.colTotalPaciente.Name = "TotalPaciente";
            this.colTotalPaciente.ReadOnly = true;
            this.colTotalPaciente.Width = 140;
            //
            // colEstado
            //
            this.colEstado.HeaderText = "Estado Cobro";
            this.colEstado.Name = "Estado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 130;
            //
            // colMetodo
            //
            this.colMetodo.DataPropertyName = "MetodoPago";
            this.colMetodo.HeaderText = "Medio de Pago";
            this.colMetodo.Name = "Metodo";
            this.colMetodo.ReadOnly = true;
            this.colMetodo.Width = 160;
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
            this.lblEstado.Text = "Cargando facturas...";
            //
            // CobroControl
            //
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.pnlBar);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "CobroControl";
            this.Size = new System.Drawing.Size(1000, 650);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBar.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.FlowLayoutPanel pnlStats;
        private System.Windows.Forms.Panel pnlBar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView gridFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObraSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescuentoOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetodo;
        private System.Windows.Forms.Label lblEstado;
    }
}
