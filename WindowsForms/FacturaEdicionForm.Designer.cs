#nullable disable

namespace WindowsForms
{
    partial class FacturaEdicionForm
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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle precioStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle subtotalStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblPac = new System.Windows.Forms.Label();
            this.cbPaciente = new System.Windows.Forms.ComboBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.cbInsumo = new System.Windows.Forms.ComboBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.colInsumoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.SuspendLayout();
            //
            // lblHeader
            //
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblHeader.Location = new System.Drawing.Point(25, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(210, 28);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "🧾 Registrar Factura";
            //
            // lblPac
            //
            this.lblPac.AutoSize = true;
            this.lblPac.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPac.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblPac.Location = new System.Drawing.Point(25, 70);
            this.lblPac.Name = "lblPac";
            this.lblPac.Size = new System.Drawing.Size(80, 17);
            this.lblPac.TabIndex = 1;
            this.lblPac.Text = "Paciente *:";
            //
            // cbPaciente
            //
            this.cbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaciente.Location = new System.Drawing.Point(150, 66);
            this.cbPaciente.Name = "cbPaciente";
            this.cbPaciente.Size = new System.Drawing.Size(520, 25);
            this.cbPaciente.TabIndex = 2;
            this.cbPaciente.SelectedIndexChanged += new System.EventHandler(this.CbPaciente_SelectedIndexChanged);
            //
            // lblTurno
            //
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTurno.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTurno.Location = new System.Drawing.Point(25, 108);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(50, 17);
            this.lblTurno.TabIndex = 3;
            this.lblTurno.Text = "Turno:";
            //
            // cbTurno
            //
            this.cbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurno.Location = new System.Drawing.Point(150, 104);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(520, 25);
            this.cbTurno.TabIndex = 4;
            //
            // lblDesc
            //
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblDesc.Location = new System.Drawing.Point(25, 146);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(87, 17);
            this.lblDesc.TabIndex = 5;
            this.lblDesc.Text = "Descripción:";
            //
            // txtDescripcion
            //
            this.txtDescripcion.Location = new System.Drawing.Point(150, 142);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PlaceholderText = "Opcional: si queda vacía se genera automáticamente";
            this.txtDescripcion.Size = new System.Drawing.Size(520, 24);
            this.txtDescripcion.TabIndex = 6;
            //
            // lblDetalle
            //
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblDetalle.Location = new System.Drawing.Point(25, 190);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(128, 19);
            this.lblDetalle.TabIndex = 7;
            this.lblDetalle.Text = "Ítems (insumos):";
            //
            // cbInsumo
            //
            this.cbInsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInsumo.Location = new System.Drawing.Point(25, 222);
            this.cbInsumo.Name = "cbInsumo";
            this.cbInsumo.Size = new System.Drawing.Size(380, 25);
            this.cbInsumo.TabIndex = 8;
            //
            // nudCantidad
            //
            this.nudCantidad.Location = new System.Drawing.Point(415, 222);
            this.nudCantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(80, 24);
            this.nudCantidad.TabIndex = 9;
            this.nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnAgregar
            //
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(505, 219);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnAgregar.Size = new System.Drawing.Size(80, 30);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "➕ Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            //
            // btnQuitar
            //
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.btnQuitar.Location = new System.Drawing.Point(590, 219);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnQuitar.Size = new System.Drawing.Size(80, 30);
            this.btnQuitar.TabIndex = 11;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            //
            // gridItems
            //
            this.gridItems.AllowUserToAddRows = false;
            this.gridItems.AllowUserToDeleteRows = false;
            this.gridItems.AllowUserToResizeRows = false;
            altRowStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.gridItems.AlternatingRowsDefaultCellStyle = altRowStyle;
            this.gridItems.AutoGenerateColumns = false;
            this.gridItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridItems.BackgroundColor = System.Drawing.Color.White;
            this.gridItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gridItems.ColumnHeadersDefaultCellStyle = headerStyle;
            this.gridItems.ColumnHeadersHeight = 42;
            this.gridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colInsumoNombre,
                this.colCantidadInsumo,
                this.colPrecioUnitario,
                this.colSubtotal
            });
            cellStyle.BackColor = System.Drawing.Color.White;
            cellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            cellStyle.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            cellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 236, 248);
            cellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 51, 112);
            this.gridItems.DefaultCellStyle = cellStyle;
            this.gridItems.EnableHeadersVisualStyles = false;
            this.gridItems.GridColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.gridItems.Location = new System.Drawing.Point(25, 260);
            this.gridItems.MultiSelect = false;
            this.gridItems.Name = "gridItems";
            this.gridItems.ReadOnly = true;
            this.gridItems.RowHeadersVisible = false;
            this.gridItems.RowTemplate.Height = 40;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(645, 200);
            this.gridItems.TabIndex = 12;
            //
            // colInsumoNombre
            //
            this.colInsumoNombre.DataPropertyName = "InsumoNombre";
            this.colInsumoNombre.HeaderText = "Insumo";
            this.colInsumoNombre.Name = "colInsumoNombre";
            this.colInsumoNombre.ReadOnly = true;
            this.colInsumoNombre.Width = 290;
            //
            // colCantidadInsumo
            //
            this.colCantidadInsumo.DataPropertyName = "CantidadInsumo";
            this.colCantidadInsumo.HeaderText = "Cant.";
            this.colCantidadInsumo.Name = "colCantidadInsumo";
            this.colCantidadInsumo.ReadOnly = true;
            this.colCantidadInsumo.Width = 80;
            //
            // colPrecioUnitario
            //
            this.colPrecioUnitario.DataPropertyName = "PrecioUnitario";
            precioStyle.Format = "C2";
            this.colPrecioUnitario.DefaultCellStyle = precioStyle;
            this.colPrecioUnitario.HeaderText = "P. Unitario";
            this.colPrecioUnitario.Name = "colPrecioUnitario";
            this.colPrecioUnitario.ReadOnly = true;
            this.colPrecioUnitario.Width = 120;
            //
            // colSubtotal
            //
            this.colSubtotal.DataPropertyName = "Subtotal";
            subtotalStyle.Format = "C2";
            this.colSubtotal.DefaultCellStyle = subtotalStyle;
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.ReadOnly = true;
            this.colSubtotal.Width = 120;
            //
            // lblTotalItems
            //
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalItems.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalItems.Location = new System.Drawing.Point(25, 470);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(645, 22);
            this.lblTotalItems.TabIndex = 13;
            //
            // lblNota
            //
            this.lblNota.AutoSize = true;
            this.lblNota.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNota.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNota.Location = new System.Drawing.Point(25, 494);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(446, 15);
            this.lblNota.TabIndex = 14;
            this.lblNota.Text = "Los honorarios del turno y el descuento de la obra social se calculan al guardar.";
            //
            // lblError
            //
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.lblError.Location = new System.Drawing.Point(25, 520);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(645, 22);
            this.lblError.TabIndex = 15;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(400, 550);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnGuardar.Size = new System.Drawing.Size(130, 38);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCancelar.FlatAppearance.BorderSize = 1;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnCancelar.Location = new System.Drawing.Point(540, 550);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCancelar.Size = new System.Drawing.Size(130, 38);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            //
            // FacturaEdicionForm
            //
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(704, 601);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblPac);
            this.Controls.Add(this.cbPaciente);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.cbTurno);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.cbInsumo);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.lblTotalItems);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FacturaEdicionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Factura";
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblPac;
        private System.Windows.Forms.ComboBox cbPaciente;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ComboBox cbTurno;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.ComboBox cbInsumo;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.DataGridView gridItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsumoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
