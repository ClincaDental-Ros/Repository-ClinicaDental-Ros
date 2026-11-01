#nullable disable

namespace WindowsForms
{
    partial class FacturaDetalleForm
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
            this.lblPaciente = new System.Windows.Forms.Label();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblFec = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.colConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblTotalPaciente = new System.Windows.Forms.Label();
            this.lblMetodo = new System.Windows.Forms.Label();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblPaciente);
            this.pnlTop.Controls.Add(this.lblOS);
            this.pnlTop.Controls.Add(this.lblFec);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(25, 20, 25, 15);
            this.pnlTop.Size = new System.Drawing.Size(650, 140);
            this.pnlTop.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(297, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🧾 Liquidación Fiscal N° 001000";
            //
            // lblPaciente
            //
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPaciente.ForeColor = System.Drawing.Color.FromArgb(230, 240, 250);
            this.lblPaciente.Location = new System.Drawing.Point(25, 50);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(78, 17);
            this.lblPaciente.TabIndex = 1;
            this.lblPaciente.Text = "Paciente: ...";
            //
            // lblOS
            //
            this.lblOS.AutoSize = true;
            this.lblOS.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOS.ForeColor = System.Drawing.Color.FromArgb(220, 235, 255);
            this.lblOS.Location = new System.Drawing.Point(25, 75);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(128, 17);
            this.lblOS.TabIndex = 2;
            this.lblOS.Text = "Cobertura Médica: ...";
            //
            // lblFec
            //
            this.lblFec.AutoSize = true;
            this.lblFec.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFec.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblFec.Location = new System.Drawing.Point(25, 100);
            this.lblFec.Name = "lblFec";
            this.lblFec.Size = new System.Drawing.Size(114, 15);
            this.lblFec.TabIndex = 3;
            this.lblFec.Text = "Fecha de Emisión: ...";
            //
            // pnlGrid
            //
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlGrid.Controls.Add(this.gridItems);
            this.pnlGrid.Controls.Add(this.lblDetalle);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 140);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);
            this.pnlGrid.Size = new System.Drawing.Size(650, 300);
            this.pnlGrid.TabIndex = 1;
            //
            // gridItems
            //
            this.gridItems.AllowUserToAddRows = false;
            this.gridItems.AllowUserToDeleteRows = false;
            this.gridItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.gridItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridItems.AutoGenerateColumns = false;
            this.gridItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridItems.BackgroundColor = System.Drawing.Color.White;
            this.gridItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridItems.ColumnHeadersHeight = 42;
            this.gridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConcepto,
            this.colCantidad,
            this.colPrecioUnitario,
            this.colSubtotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(224, 236, 248);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(0, 51, 112);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItems.EnableHeadersVisualStyles = false;
            this.gridItems.GridColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.gridItems.Location = new System.Drawing.Point(25, 45);
            this.gridItems.MultiSelect = false;
            this.gridItems.Name = "gridItems";
            this.gridItems.ReadOnly = true;
            this.gridItems.RowHeadersVisible = false;
            this.gridItems.RowTemplate.Height = 40;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(600, 245);
            this.gridItems.TabIndex = 0;
            //
            // colConcepto
            //
            this.colConcepto.DataPropertyName = "InsumoNombre";
            this.colConcepto.HeaderText = "Insumo / Concepto Prestacional";
            this.colConcepto.Name = "Concepto";
            this.colConcepto.ReadOnly = true;
            this.colConcepto.Width = 300;
            //
            // colCantidad
            //
            this.colCantidad.DataPropertyName = "CantidadInsumo";
            this.colCantidad.HeaderText = "Cant.";
            this.colCantidad.Name = "Cantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 80;
            //
            // colPrecioUnitario
            //
            this.colPrecioUnitario.DataPropertyName = "PrecioUnitario";
            this.colPrecioUnitario.HeaderText = "P. Unitario";
            this.colPrecioUnitario.Name = "PrecioUnitario";
            this.colPrecioUnitario.ReadOnly = true;
            this.colPrecioUnitario.Width = 110;
            //
            // colSubtotal
            //
            this.colSubtotal.DataPropertyName = "Subtotal";
            this.colSubtotal.HeaderText = "Subtotal ($)";
            this.colSubtotal.Name = "Subtotal";
            this.colSubtotal.ReadOnly = true;
            this.colSubtotal.Width = 110;
            //
            // lblDetalle
            //
            this.lblDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblDetalle.Location = new System.Drawing.Point(25, 15);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(600, 30);
            this.lblDetalle.TabIndex = 1;
            this.lblDetalle.Text = "Detalle de Honorarios Profesionales e Insumos Consumidos:";
            //
            // pnlBottom
            //
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
            this.pnlBottom.Controls.Add(this.lblSubtotal);
            this.pnlBottom.Controls.Add(this.lblDescuento);
            this.pnlBottom.Controls.Add(this.lblTotalPaciente);
            this.pnlBottom.Controls.Add(this.lblMetodo);
            this.pnlBottom.Controls.Add(this.cbMetodoPago);
            this.pnlBottom.Controls.Add(this.btnCobrar);
            this.pnlBottom.Controls.Add(this.btnCerrar);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 440);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.pnlBottom.Size = new System.Drawing.Size(650, 210);
            this.pnlBottom.TabIndex = 2;
            //
            // lblSubtotal
            //
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblSubtotal.Location = new System.Drawing.Point(25, 12);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(242, 17);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Subtotal Honorarios + Insumos: $0.00";
            //
            // lblDescuento
            //
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.lblDescuento.Location = new System.Drawing.Point(25, 38);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(268, 17);
            this.lblDescuento.TabIndex = 1;
            this.lblDescuento.Text = "Descuento Cobertura Obra Social: -$0.00";
            //
            // lblTotalPaciente
            //
            this.lblTotalPaciente.AutoSize = true;
            this.lblTotalPaciente.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalPaciente.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblTotalPaciente.Location = new System.Drawing.Point(25, 68);
            this.lblTotalPaciente.Name = "lblTotalPaciente";
            this.lblTotalPaciente.Size = new System.Drawing.Size(305, 25);
            this.lblTotalPaciente.TabIndex = 2;
            this.lblTotalPaciente.Text = "TOTAL A COBRAR PACIENTE: $0.00";
            //
            // lblMetodo
            //
            this.lblMetodo.AutoSize = true;
            this.lblMetodo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMetodo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblMetodo.Location = new System.Drawing.Point(25, 112);
            this.lblMetodo.Name = "lblMetodo";
            this.lblMetodo.Size = new System.Drawing.Size(102, 17);
            this.lblMetodo.TabIndex = 3;
            this.lblMetodo.Text = "Medio de Pago:";
            //
            // cbMetodoPago
            //
            this.cbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta de Débito",
            "Tarjeta de Crédito",
            "Transferencia Bancaria / QR"});
            this.cbMetodoPago.Location = new System.Drawing.Point(145, 108);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(230, 25);
            this.cbMetodoPago.TabIndex = 4;
            //
            // btnCobrar
            //
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobrar.FlatAppearance.BorderSize = 0;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCobrar.ForeColor = System.Drawing.Color.White;
            this.btnCobrar.Location = new System.Drawing.Point(25, 150);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnCobrar.Size = new System.Drawing.Size(220, 42);
            this.btnCobrar.TabIndex = 5;
            this.btnCobrar.Text = "💳 Registrar Cobro en Caja";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.BtnCobrar_Click);
            //
            // btnCerrar
            //
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCerrar.FlatAppearance.BorderSize = 1;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnCerrar.Location = new System.Drawing.Point(255, 150);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCerrar.Size = new System.Drawing.Size(130, 42);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            //
            // FacturaDetalleForm
            //
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 650);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FacturaDetalleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comprobante de Facturación / Liquidación";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.Label lblFec;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView gridItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblTotalPaciente;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnCerrar;
    }
}
