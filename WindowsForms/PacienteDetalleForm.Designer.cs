#nullable disable

namespace WindowsForms
{
    partial class PacienteDetalleForm
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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblDoc = new System.Windows.Forms.Label();
            this.pnlDoc = new System.Windows.Forms.Panel();
            this.cbTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.lblObraSocial = new System.Windows.Forms.Label();
            this.cbObraSocial = new System.Windows.Forms.ComboBox();
            this.lblAfiliado = new System.Windows.Forms.Label();
            this.txtAfiliado = new System.Windows.Forms.TextBox();
            this.lblCredHeader = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlCard.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlDoc.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlCard
            //
            this.pnlCard.AutoScroll = true;
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.pnlHeader);
            this.pnlCard.Controls.Add(this.lblNombre);
            this.pnlCard.Controls.Add(this.txtNombre);
            this.pnlCard.Controls.Add(this.lblApellido);
            this.pnlCard.Controls.Add(this.txtApellido);
            this.pnlCard.Controls.Add(this.lblDoc);
            this.pnlCard.Controls.Add(this.pnlDoc);
            this.pnlCard.Controls.Add(this.lblFechaNac);
            this.pnlCard.Controls.Add(this.dtpFechaNac);
            this.pnlCard.Controls.Add(this.lblTelefono);
            this.pnlCard.Controls.Add(this.txtTelefono);
            this.pnlCard.Controls.Add(this.lblMail);
            this.pnlCard.Controls.Add(this.txtMail);
            this.pnlCard.Controls.Add(this.lblDomicilio);
            this.pnlCard.Controls.Add(this.txtDomicilio);
            this.pnlCard.Controls.Add(this.lblObraSocial);
            this.pnlCard.Controls.Add(this.cbObraSocial);
            this.pnlCard.Controls.Add(this.lblAfiliado);
            this.pnlCard.Controls.Add(this.txtAfiliado);
            this.pnlCard.Controls.Add(this.lblCredHeader);
            this.pnlCard.Controls.Add(this.lblUsuario);
            this.pnlCard.Controls.Add(this.txtUsuario);
            this.pnlCard.Controls.Add(this.lblPassword);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.chkHabilitado);
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.pnlActions);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlCard.Size = new System.Drawing.Size(564, 711);
            this.pnlCard.TabIndex = 0;
            //
            // pnlHeader
            //
            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Location = new System.Drawing.Point(20, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(490, 50);
            this.pnlHeader.TabIndex = 0;
            //
            // lblLogo
            //
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(40, 32);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "🦷";
            //
            // lblHeader
            //
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblHeader.Location = new System.Drawing.Point(45, 5);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(256, 28);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Registrar Nuevo Paciente";
            //
            // lblNombre
            //
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblNombre.Location = new System.Drawing.Point(20, 73);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(150, 22);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre *:";
            //
            // txtNombre
            //
            this.txtNombre.Location = new System.Drawing.Point(170, 70);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(330, 24);
            this.txtNombre.TabIndex = 2;
            //
            // lblApellido
            //
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblApellido.Location = new System.Drawing.Point(20, 111);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(150, 22);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "Apellido *:";
            //
            // txtApellido
            //
            this.txtApellido.Location = new System.Drawing.Point(170, 108);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(330, 24);
            this.txtApellido.TabIndex = 4;
            //
            // lblDoc
            //
            this.lblDoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDoc.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblDoc.Location = new System.Drawing.Point(20, 149);
            this.lblDoc.Name = "lblDoc";
            this.lblDoc.Size = new System.Drawing.Size(150, 22);
            this.lblDoc.TabIndex = 5;
            this.lblDoc.Text = "Documento *:";
            //
            // pnlDoc
            //
            this.pnlDoc.Controls.Add(this.cbTipoDoc);
            this.pnlDoc.Controls.Add(this.txtDni);
            this.pnlDoc.Location = new System.Drawing.Point(170, 146);
            this.pnlDoc.Name = "pnlDoc";
            this.pnlDoc.Size = new System.Drawing.Size(330, 30);
            this.pnlDoc.TabIndex = 6;
            //
            // cbTipoDoc
            //
            this.cbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDoc.Items.AddRange(new object[] { "DNI", "CUIL", "Pasaporte", "Otros" });
            this.cbTipoDoc.Location = new System.Drawing.Point(0, 0);
            this.cbTipoDoc.Name = "cbTipoDoc";
            this.cbTipoDoc.Size = new System.Drawing.Size(95, 25);
            this.cbTipoDoc.TabIndex = 0;
            //
            // txtDni
            //
            this.txtDni.Location = new System.Drawing.Point(105, 0);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(225, 24);
            this.txtDni.TabIndex = 1;
            //
            // lblFechaNac
            //
            this.lblFechaNac.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFechaNac.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblFechaNac.Location = new System.Drawing.Point(20, 187);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(150, 22);
            this.lblFechaNac.TabIndex = 7;
            this.lblFechaNac.Text = "Fecha Nacimiento:";
            //
            // dtpFechaNac
            //
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(170, 184);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(330, 24);
            this.dtpFechaNac.TabIndex = 8;
            this.dtpFechaNac.Value = new System.DateTime(1995, 1, 1, 0, 0, 0, 0);
            //
            // lblTelefono
            //
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTelefono.Location = new System.Drawing.Point(20, 225);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(150, 22);
            this.lblTelefono.TabIndex = 9;
            this.lblTelefono.Text = "Teléfono *:";
            //
            // txtTelefono
            //
            this.txtTelefono.Location = new System.Drawing.Point(170, 222);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(330, 24);
            this.txtTelefono.TabIndex = 10;
            //
            // lblMail
            //
            this.lblMail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMail.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblMail.Location = new System.Drawing.Point(20, 263);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(150, 22);
            this.lblMail.TabIndex = 11;
            this.lblMail.Text = "Correo Electrónico *:";
            //
            // txtMail
            //
            this.txtMail.Location = new System.Drawing.Point(170, 260);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(330, 24);
            this.txtMail.TabIndex = 12;
            //
            // lblDomicilio
            //
            this.lblDomicilio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDomicilio.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblDomicilio.Location = new System.Drawing.Point(20, 301);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(150, 22);
            this.lblDomicilio.TabIndex = 13;
            this.lblDomicilio.Text = "Domicilio:";
            //
            // txtDomicilio
            //
            this.txtDomicilio.Location = new System.Drawing.Point(170, 298);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(330, 24);
            this.txtDomicilio.TabIndex = 14;
            //
            // lblObraSocial
            //
            this.lblObraSocial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblObraSocial.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblObraSocial.Location = new System.Drawing.Point(20, 339);
            this.lblObraSocial.Name = "lblObraSocial";
            this.lblObraSocial.Size = new System.Drawing.Size(150, 22);
            this.lblObraSocial.TabIndex = 15;
            this.lblObraSocial.Text = "Obra Social *:";
            //
            // cbObraSocial
            //
            this.cbObraSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbObraSocial.Location = new System.Drawing.Point(170, 336);
            this.cbObraSocial.Name = "cbObraSocial";
            this.cbObraSocial.Size = new System.Drawing.Size(330, 25);
            this.cbObraSocial.TabIndex = 16;
            //
            // lblAfiliado
            //
            this.lblAfiliado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAfiliado.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblAfiliado.Location = new System.Drawing.Point(20, 377);
            this.lblAfiliado.Name = "lblAfiliado";
            this.lblAfiliado.Size = new System.Drawing.Size(150, 22);
            this.lblAfiliado.TabIndex = 17;
            this.lblAfiliado.Text = "N° de Afiliado / Cred:";
            //
            // txtAfiliado
            //
            this.txtAfiliado.Location = new System.Drawing.Point(170, 374);
            this.txtAfiliado.Name = "txtAfiliado";
            this.txtAfiliado.Size = new System.Drawing.Size(330, 24);
            this.txtAfiliado.TabIndex = 18;
            //
            // lblCredHeader
            //
            this.lblCredHeader.AutoSize = true;
            this.lblCredHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCredHeader.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblCredHeader.Location = new System.Drawing.Point(20, 417);
            this.lblCredHeader.Name = "lblCredHeader";
            this.lblCredHeader.Size = new System.Drawing.Size(327, 17);
            this.lblCredHeader.TabIndex = 19;
            this.lblCredHeader.Text = "🔑 Credenciales de Acceso (Portal del Paciente)";
            //
            // lblUsuario
            //
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblUsuario.Location = new System.Drawing.Point(20, 443);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(150, 22);
            this.lblUsuario.TabIndex = 20;
            this.lblUsuario.Text = "Usuario Portal:";
            //
            // txtUsuario
            //
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            this.txtUsuario.Location = new System.Drawing.Point(170, 440);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(330, 24);
            this.txtUsuario.TabIndex = 21;
            this.txtUsuario.Text = "(Se generará automáticamente al guardar)";
            //
            // lblPassword
            //
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblPassword.Location = new System.Drawing.Point(20, 481);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(150, 22);
            this.lblPassword.TabIndex = 22;
            this.lblPassword.Text = "Clave Inicial:";
            //
            // txtPassword
            //
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            this.txtPassword.Location = new System.Drawing.Point(170, 478);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(330, 24);
            this.txtPassword.TabIndex = 23;
            this.txtPassword.Text = "paciente123";
            //
            // chkHabilitado
            //
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Checked = true;
            this.chkHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHabilitado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkHabilitado.ForeColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.chkHabilitado.Location = new System.Drawing.Point(170, 516);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(296, 21);
            this.chkHabilitado.TabIndex = 24;
            this.chkHabilitado.Text = "Paciente Habilitado para Turnos (Sin Deudas)";
            this.chkHabilitado.CheckedChanged += new System.EventHandler(this.ChkHabilitado_CheckedChanged);
            //
            // lblError
            //
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.lblError.Location = new System.Drawing.Point(20, 551);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(490, 30);
            this.lblError.TabIndex = 25;
            //
            // pnlActions
            //
            this.pnlActions.Controls.Add(this.btnGuardar);
            this.pnlActions.Controls.Add(this.btnCancelar);
            this.pnlActions.Location = new System.Drawing.Point(170, 586);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(330, 45);
            this.pnlActions.TabIndex = 26;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnGuardar.Size = new System.Drawing.Size(180, 40);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "💾 Guardar Paciente";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCancelar.FlatAppearance.BorderSize = 1;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnCancelar.Location = new System.Drawing.Point(190, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCancelar.Size = new System.Drawing.Size(130, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            //
            // PacienteDetalleForm
            //
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize = new System.Drawing.Size(564, 711);
            this.Controls.Add(this.pnlCard);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PacienteDetalleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta de Paciente - Clínica Odontológica";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlDoc.ResumeLayout(false);
            this.pnlDoc.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDoc;
        private System.Windows.Forms.Panel pnlDoc;
        private System.Windows.Forms.ComboBox cbTipoDoc;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label lblObraSocial;
        private System.Windows.Forms.ComboBox cbObraSocial;
        private System.Windows.Forms.Label lblAfiliado;
        private System.Windows.Forms.TextBox txtAfiliado;
        private System.Windows.Forms.Label lblCredHeader;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
