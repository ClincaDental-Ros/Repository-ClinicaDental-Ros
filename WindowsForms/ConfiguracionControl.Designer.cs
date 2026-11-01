#nullable disable

namespace WindowsForms
{
    partial class ConfiguracionControl
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
      pnlTop = new Panel();
      lblTitle = new Label();
      lblSub = new Label();
      pnlBody = new Panel();
      pnlFotoCard = new Panel();
      picAvatar = new PictureBox();
      lblAvatarIniciales = new Label();
      btnCambiarFoto = new Button();
      btnQuitarFoto = new Button();
      lblFotoInfo = new Label();
      pnlDatosCard = new Panel();
      lblDatosTitle = new Label();
      lblNombre = new Label();
      txtNombre = new TextBox();
      lblApellido = new Label();
      txtApellido = new TextBox();
      lblDni = new Label();
      txtDni = new TextBox();
      lblMail = new Label();
      txtMail = new TextBox();
      lblTelefono = new Label();
      txtTelefono = new TextBox();
      lblDomicilio = new Label();
      txtDomicilio = new TextBox();
      pnlOSCard = new Panel();
      lblOSTitle = new Label();
      lblOS = new Label();
      cbObraSocial = new ComboBox();
      lblAf = new Label();
      txtAfiliado = new TextBox();
      pnlSegCard = new Panel();
      lblSegTitle = new Label();
      lblPassActual = new Label();
      txtPassActual = new TextBox();
      btnEyeActual = new Button();
      lblPassNueva = new Label();
      txtPassNueva = new TextBox();
      btnEyeNueva = new Button();
      lblPassConfirmar = new Label();
      txtPassConfirmar = new TextBox();
      btnEyeConfirmar = new Button();
      lblPassMatch = new Label();
      chkNotifEmail = new CheckBox();
      chkNotifWhatsapp = new CheckBox();
      btnGuardar = new Button();
      lblFeedback = new Label();
      pnlTop.SuspendLayout();
      pnlBody.SuspendLayout();
      pnlFotoCard.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
      pnlDatosCard.SuspendLayout();
      pnlOSCard.SuspendLayout();
      pnlSegCard.SuspendLayout();
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
      lblTitle.Size = new Size(444, 30);
      lblTitle.TabIndex = 0;
      lblTitle.Text = "Configuración de Cuenta y Perfil de Usuario";
      // 
      // lblSub
      // 
      lblSub.AutoSize = true;
      lblSub.Font = new Font("Segoe UI", 8.5F);
      lblSub.ForeColor = Color.FromArgb(100, 116, 139);
      lblSub.Location = new Point(27, 40);
      lblSub.Name = "lblSub";
      lblSub.Size = new Size(647, 20);
      lblSub.TabIndex = 1;
      lblSub.Text = "Administrá tu foto de perfil, datos personales, cobertura de obra social, seguridad y preferencias";
      // 
      // pnlBody
      // 
      pnlBody.AutoScroll = true;
      pnlBody.Controls.Add(pnlFotoCard);
      pnlBody.Controls.Add(pnlDatosCard);
      pnlBody.Controls.Add(pnlOSCard);
      pnlBody.Controls.Add(pnlSegCard);
      pnlBody.Controls.Add(btnGuardar);
      pnlBody.Controls.Add(lblFeedback);
      pnlBody.Dock = DockStyle.Fill;
      pnlBody.Location = new Point(0, 70);
      pnlBody.Name = "pnlBody";
      pnlBody.Padding = new Padding(25, 15, 25, 25);
      pnlBody.Size = new Size(1560, 672);
      pnlBody.TabIndex = 1;
      // 
      // pnlFotoCard
      // 
      pnlFotoCard.BackColor = Color.White;
      pnlFotoCard.Controls.Add(picAvatar);
      pnlFotoCard.Controls.Add(lblAvatarIniciales);
      pnlFotoCard.Controls.Add(btnCambiarFoto);
      pnlFotoCard.Controls.Add(btnQuitarFoto);
      pnlFotoCard.Controls.Add(lblFotoInfo);
      pnlFotoCard.Location = new Point(25, 15);
      pnlFotoCard.Name = "pnlFotoCard";
      pnlFotoCard.Padding = new Padding(20);
      pnlFotoCard.Size = new Size(740, 115);
      pnlFotoCard.TabIndex = 0;
      pnlFotoCard.Paint += PnlCard_Paint;
      // 
      // picAvatar
      // 
      picAvatar.Location = new Point(20, 15);
      picAvatar.Name = "picAvatar";
      picAvatar.Size = new Size(80, 80);
      picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
      picAvatar.TabIndex = 0;
      picAvatar.TabStop = false;
      picAvatar.Visible = false;
      picAvatar.Paint += PicAvatar_Paint;
      // 
      // lblAvatarIniciales
      // 
      lblAvatarIniciales.BackColor = Color.FromArgb(0, 70, 148);
      lblAvatarIniciales.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
      lblAvatarIniciales.ForeColor = Color.White;
      lblAvatarIniciales.Location = new Point(20, 15);
      lblAvatarIniciales.Name = "lblAvatarIniciales";
      lblAvatarIniciales.Size = new Size(80, 80);
      lblAvatarIniciales.TabIndex = 1;
      lblAvatarIniciales.Text = "U";
      lblAvatarIniciales.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // btnCambiarFoto
      // 
      btnCambiarFoto.BackColor = Color.FromArgb(0, 70, 148);
      btnCambiarFoto.Cursor = Cursors.Hand;
      btnCambiarFoto.FlatAppearance.BorderSize = 0;
      btnCambiarFoto.FlatStyle = FlatStyle.Flat;
      btnCambiarFoto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      btnCambiarFoto.ForeColor = Color.White;
      btnCambiarFoto.Location = new Point(120, 25);
      btnCambiarFoto.Name = "btnCambiarFoto";
      btnCambiarFoto.Padding = new Padding(12, 0, 12, 0);
      btnCambiarFoto.Size = new Size(190, 36);
      btnCambiarFoto.TabIndex = 2;
      btnCambiarFoto.Text = "📷 Cargar Foto de Perfil";
      btnCambiarFoto.UseVisualStyleBackColor = false;
      btnCambiarFoto.Click += BtnCambiarFoto_Click;
      // 
      // btnQuitarFoto
      // 
      btnQuitarFoto.BackColor = Color.White;
      btnQuitarFoto.Cursor = Cursors.Hand;
      btnQuitarFoto.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
      btnQuitarFoto.FlatStyle = FlatStyle.Flat;
      btnQuitarFoto.Font = new Font("Segoe UI", 9.5F);
      btnQuitarFoto.ForeColor = Color.FromArgb(30, 41, 59);
      btnQuitarFoto.Location = new Point(320, 25);
      btnQuitarFoto.Name = "btnQuitarFoto";
      btnQuitarFoto.Padding = new Padding(10, 0, 10, 0);
      btnQuitarFoto.Size = new Size(120, 36);
      btnQuitarFoto.TabIndex = 3;
      btnQuitarFoto.Text = "Quitar Foto";
      btnQuitarFoto.UseVisualStyleBackColor = false;
      btnQuitarFoto.Click += BtnQuitarFoto_Click;
      // 
      // lblFotoInfo
      // 
      lblFotoInfo.AutoSize = true;
      lblFotoInfo.Font = new Font("Segoe UI", 8.5F);
      lblFotoInfo.ForeColor = Color.FromArgb(100, 116, 139);
      lblFotoInfo.Location = new Point(122, 68);
      lblFotoInfo.Name = "lblFotoInfo";
      lblFotoInfo.Size = new Size(467, 20);
      lblFotoInfo.TabIndex = 4;
      lblFotoInfo.Text = "Formatos soportados: JPG, PNG. Tamaño máximo recomendado 2MB.";
      // 
      // pnlDatosCard
      // 
      pnlDatosCard.BackColor = Color.White;
      pnlDatosCard.Controls.Add(lblDatosTitle);
      pnlDatosCard.Controls.Add(lblNombre);
      pnlDatosCard.Controls.Add(txtNombre);
      pnlDatosCard.Controls.Add(lblApellido);
      pnlDatosCard.Controls.Add(txtApellido);
      pnlDatosCard.Controls.Add(lblDni);
      pnlDatosCard.Controls.Add(txtDni);
      pnlDatosCard.Controls.Add(lblMail);
      pnlDatosCard.Controls.Add(txtMail);
      pnlDatosCard.Controls.Add(lblTelefono);
      pnlDatosCard.Controls.Add(txtTelefono);
      pnlDatosCard.Controls.Add(lblDomicilio);
      pnlDatosCard.Controls.Add(txtDomicilio);
      pnlDatosCard.Location = new Point(25, 145);
      pnlDatosCard.Name = "pnlDatosCard";
      pnlDatosCard.Padding = new Padding(25, 20, 25, 20);
      pnlDatosCard.Size = new Size(740, 210);
      pnlDatosCard.TabIndex = 1;
      pnlDatosCard.Paint += PnlCard_Paint;
      // 
      // lblDatosTitle
      // 
      lblDatosTitle.AutoSize = true;
      lblDatosTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
      lblDatosTitle.ForeColor = Color.FromArgb(0, 70, 148);
      lblDatosTitle.Location = new Point(20, 15);
      lblDatosTitle.Name = "lblDatosTitle";
      lblDatosTitle.Size = new Size(260, 23);
      lblDatosTitle.TabIndex = 0;
      lblDatosTitle.Text = "👤 Datos Personales del Titular";
      // 
      // lblNombre
      // 
      lblNombre.AutoSize = true;
      lblNombre.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblNombre.ForeColor = Color.FromArgb(30, 41, 59);
      lblNombre.Location = new Point(20, 45);
      lblNombre.Name = "lblNombre";
      lblNombre.Size = new Size(82, 20);
      lblNombre.TabIndex = 1;
      lblNombre.Text = "Nombre *:";
      // 
      // txtNombre
      // 
      txtNombre.Font = new Font("Segoe UI", 9.5F);
      txtNombre.Location = new Point(20, 65);
      txtNombre.Name = "txtNombre";
      txtNombre.Size = new Size(215, 29);
      txtNombre.TabIndex = 2;
      // 
      // lblApellido
      // 
      lblApellido.AutoSize = true;
      lblApellido.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblApellido.ForeColor = Color.FromArgb(30, 41, 59);
      lblApellido.Location = new Point(250, 45);
      lblApellido.Name = "lblApellido";
      lblApellido.Size = new Size(82, 20);
      lblApellido.TabIndex = 3;
      lblApellido.Text = "Apellido *:";
      // 
      // txtApellido
      // 
      txtApellido.Font = new Font("Segoe UI", 9.5F);
      txtApellido.Location = new Point(250, 65);
      txtApellido.Name = "txtApellido";
      txtApellido.Size = new Size(215, 29);
      txtApellido.TabIndex = 4;
      // 
      // lblDni
      // 
      lblDni.AutoSize = true;
      lblDni.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblDni.ForeColor = Color.FromArgb(30, 41, 59);
      lblDni.Location = new Point(480, 45);
      lblDni.Name = "lblDni";
      lblDni.Size = new Size(138, 20);
      lblDni.TabIndex = 5;
      lblDni.Text = "DNI / Documento:";
      // 
      // txtDni
      // 
      txtDni.Enabled = false;
      txtDni.Font = new Font("Segoe UI", 9.5F);
      txtDni.Location = new Point(480, 65);
      txtDni.Name = "txtDni";
      txtDni.Size = new Size(215, 29);
      txtDni.TabIndex = 6;
      // 
      // lblMail
      // 
      lblMail.AutoSize = true;
      lblMail.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblMail.ForeColor = Color.FromArgb(30, 41, 59);
      lblMail.Location = new Point(20, 110);
      lblMail.Name = "lblMail";
      lblMail.Size = new Size(152, 20);
      lblMail.TabIndex = 7;
      lblMail.Text = "Correo Electrónico *:";
      // 
      // txtMail
      // 
      txtMail.Font = new Font("Segoe UI", 9.5F);
      txtMail.Location = new Point(20, 130);
      txtMail.Name = "txtMail";
      txtMail.Size = new Size(215, 29);
      txtMail.TabIndex = 8;
      // 
      // lblTelefono
      // 
      lblTelefono.AutoSize = true;
      lblTelefono.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblTelefono.ForeColor = Color.FromArgb(30, 41, 59);
      lblTelefono.Location = new Point(250, 110);
      lblTelefono.Name = "lblTelefono";
      lblTelefono.Size = new Size(128, 20);
      lblTelefono.TabIndex = 9;
      lblTelefono.Text = "Teléfono Móvil *:";
      // 
      // txtTelefono
      // 
      txtTelefono.Font = new Font("Segoe UI", 9.5F);
      txtTelefono.Location = new Point(250, 130);
      txtTelefono.Name = "txtTelefono";
      txtTelefono.Size = new Size(215, 29);
      txtTelefono.TabIndex = 10;
      // 
      // lblDomicilio
      // 
      lblDomicilio.AutoSize = true;
      lblDomicilio.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblDomicilio.ForeColor = Color.FromArgb(30, 41, 59);
      lblDomicilio.Location = new Point(480, 110);
      lblDomicilio.Name = "lblDomicilio";
      lblDomicilio.Size = new Size(79, 20);
      lblDomicilio.TabIndex = 11;
      lblDomicilio.Text = "Domicilio:";
      // 
      // txtDomicilio
      // 
      txtDomicilio.Font = new Font("Segoe UI", 9.5F);
      txtDomicilio.Location = new Point(480, 130);
      txtDomicilio.Name = "txtDomicilio";
      txtDomicilio.Size = new Size(215, 29);
      txtDomicilio.TabIndex = 12;
      // 
      // pnlOSCard
      // 
      pnlOSCard.BackColor = Color.White;
      pnlOSCard.Controls.Add(lblOSTitle);
      pnlOSCard.Controls.Add(lblOS);
      pnlOSCard.Controls.Add(cbObraSocial);
      pnlOSCard.Controls.Add(lblAf);
      pnlOSCard.Controls.Add(txtAfiliado);
      pnlOSCard.Location = new Point(25, 370);
      pnlOSCard.Name = "pnlOSCard";
      pnlOSCard.Padding = new Padding(25, 20, 25, 20);
      pnlOSCard.Size = new Size(740, 125);
      pnlOSCard.TabIndex = 2;
      pnlOSCard.Paint += PnlCard_Paint;
      // 
      // lblOSTitle
      // 
      lblOSTitle.AutoSize = true;
      lblOSTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
      lblOSTitle.ForeColor = Color.FromArgb(0, 70, 148);
      lblOSTitle.Location = new Point(20, 15);
      lblOSTitle.Name = "lblOSTitle";
      lblOSTitle.Size = new Size(294, 23);
      lblOSTitle.TabIndex = 0;
      lblOSTitle.Text = "🛡️ Obra Social y Cobertura Médica";
      // 
      // lblOS
      // 
      lblOS.AutoSize = true;
      lblOS.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblOS.ForeColor = Color.FromArgb(30, 41, 59);
      lblOS.Location = new Point(20, 48);
      lblOS.Name = "lblOS";
      lblOS.Size = new Size(163, 20);
      lblOS.TabIndex = 1;
      lblOS.Text = "Obra Social / Prepaga:";
      // 
      // cbObraSocial
      // 
      cbObraSocial.DropDownStyle = ComboBoxStyle.DropDownList;
      cbObraSocial.Font = new Font("Segoe UI", 9.5F);
      cbObraSocial.Items.AddRange(new object[] { "Particular (Sin Obra Social)", "OSDE (Plan 210 / 310)", "Swiss Medical", "IOMA" });
      cbObraSocial.Location = new Point(20, 70);
      cbObraSocial.Name = "cbObraSocial";
      cbObraSocial.Size = new Size(320, 29);
      cbObraSocial.TabIndex = 2;
      // 
      // lblAf
      // 
      lblAf.AutoSize = true;
      lblAf.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblAf.ForeColor = Color.FromArgb(30, 41, 59);
      lblAf.Location = new Point(360, 48);
      lblAf.Name = "lblAf";
      lblAf.Size = new Size(198, 20);
      lblAf.TabIndex = 3;
      lblAf.Text = "N° de Afiliado / Credencial:";
      // 
      // txtAfiliado
      // 
      txtAfiliado.Font = new Font("Segoe UI", 9.5F);
      txtAfiliado.Location = new Point(360, 70);
      txtAfiliado.Name = "txtAfiliado";
      txtAfiliado.Size = new Size(340, 29);
      txtAfiliado.TabIndex = 4;
      // 
      // pnlSegCard
      // 
      pnlSegCard.BackColor = Color.White;
      pnlSegCard.Controls.Add(lblSegTitle);
      pnlSegCard.Controls.Add(lblPassActual);
      pnlSegCard.Controls.Add(txtPassActual);
      pnlSegCard.Controls.Add(btnEyeActual);
      pnlSegCard.Controls.Add(lblPassNueva);
      pnlSegCard.Controls.Add(txtPassNueva);
      pnlSegCard.Controls.Add(btnEyeNueva);
      pnlSegCard.Controls.Add(lblPassConfirmar);
      pnlSegCard.Controls.Add(txtPassConfirmar);
      pnlSegCard.Controls.Add(btnEyeConfirmar);
      pnlSegCard.Controls.Add(lblPassMatch);
      pnlSegCard.Controls.Add(chkNotifEmail);
      pnlSegCard.Controls.Add(chkNotifWhatsapp);
      pnlSegCard.Location = new Point(25, 510);
      pnlSegCard.Name = "pnlSegCard";
      pnlSegCard.Padding = new Padding(25, 20, 25, 20);
      pnlSegCard.Size = new Size(740, 215);
      pnlSegCard.TabIndex = 3;
      pnlSegCard.Paint += PnlCard_Paint;
      // 
      // lblSegTitle
      // 
      lblSegTitle.AutoSize = true;
      lblSegTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
      lblSegTitle.ForeColor = Color.FromArgb(0, 70, 148);
      lblSegTitle.Location = new Point(20, 15);
      lblSegTitle.Name = "lblSegTitle";
      lblSegTitle.Size = new Size(254, 23);
      lblSegTitle.TabIndex = 0;
      lblSegTitle.Text = "🔒 Seguridad y Notificaciones";
      // 
      // lblPassActual
      // 
      lblPassActual.AutoSize = true;
      lblPassActual.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblPassActual.ForeColor = Color.FromArgb(30, 41, 59);
      lblPassActual.Location = new Point(20, 45);
      lblPassActual.Name = "lblPassActual";
      lblPassActual.Size = new Size(141, 20);
      lblPassActual.TabIndex = 1;
      lblPassActual.Text = "Contraseña Actual:";
      // 
      // txtPassActual
      // 
      txtPassActual.Font = new Font("Segoe UI", 9.5F);
      txtPassActual.Location = new Point(20, 65);
      txtPassActual.Name = "txtPassActual";
      txtPassActual.Size = new Size(179, 29);
      txtPassActual.TabIndex = 2;
      txtPassActual.UseSystemPasswordChar = true;
      // 
      // btnEyeActual
      // 
      btnEyeActual.BackColor = Color.FromArgb(241, 245, 249);
      btnEyeActual.Cursor = Cursors.Hand;
      btnEyeActual.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
      btnEyeActual.FlatStyle = FlatStyle.Flat;
      btnEyeActual.Font = new Font("Segoe MDL2 Assets", 10F);
      btnEyeActual.ForeColor = Color.FromArgb(0, 70, 148);
      btnEyeActual.Location = new Point(203, 64);
      btnEyeActual.Name = "btnEyeActual";
      btnEyeActual.Size = new Size(32, 27);
      btnEyeActual.TabIndex = 3;
      btnEyeActual.Text = "";
      btnEyeActual.UseVisualStyleBackColor = false;
      btnEyeActual.Click += BtnEyeActual_Click;
      // 
      // lblPassNueva
      // 
      lblPassNueva.AutoSize = true;
      lblPassNueva.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblPassNueva.ForeColor = Color.FromArgb(30, 41, 59);
      lblPassNueva.Location = new Point(250, 45);
      lblPassNueva.Name = "lblPassNueva";
      lblPassNueva.Size = new Size(141, 20);
      lblPassNueva.TabIndex = 4;
      lblPassNueva.Text = "Nueva Contraseña:";
      // 
      // txtPassNueva
      // 
      txtPassNueva.Font = new Font("Segoe UI", 9.5F);
      txtPassNueva.Location = new Point(250, 65);
      txtPassNueva.Name = "txtPassNueva";
      txtPassNueva.Size = new Size(179, 29);
      txtPassNueva.TabIndex = 5;
      txtPassNueva.UseSystemPasswordChar = true;
      txtPassNueva.TextChanged += TxtPass_TextChanged;
      // 
      // btnEyeNueva
      // 
      btnEyeNueva.BackColor = Color.FromArgb(241, 245, 249);
      btnEyeNueva.Cursor = Cursors.Hand;
      btnEyeNueva.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
      btnEyeNueva.FlatStyle = FlatStyle.Flat;
      btnEyeNueva.Font = new Font("Segoe MDL2 Assets", 10F);
      btnEyeNueva.ForeColor = Color.FromArgb(0, 70, 148);
      btnEyeNueva.Location = new Point(433, 64);
      btnEyeNueva.Name = "btnEyeNueva";
      btnEyeNueva.Size = new Size(32, 27);
      btnEyeNueva.TabIndex = 6;
      btnEyeNueva.Text = "";
      btnEyeNueva.UseVisualStyleBackColor = false;
      btnEyeNueva.Click += BtnEyeNueva_Click;
      // 
      // lblPassConfirmar
      // 
      lblPassConfirmar.AutoSize = true;
      lblPassConfirmar.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblPassConfirmar.ForeColor = Color.FromArgb(30, 41, 59);
      lblPassConfirmar.Location = new Point(480, 45);
      lblPassConfirmar.Name = "lblPassConfirmar";
      lblPassConfirmar.Size = new Size(133, 20);
      lblPassConfirmar.TabIndex = 7;
      lblPassConfirmar.Text = "Confirmar Nueva:";
      // 
      // txtPassConfirmar
      // 
      txtPassConfirmar.Font = new Font("Segoe UI", 9.5F);
      txtPassConfirmar.Location = new Point(480, 65);
      txtPassConfirmar.Name = "txtPassConfirmar";
      txtPassConfirmar.Size = new Size(179, 29);
      txtPassConfirmar.TabIndex = 8;
      txtPassConfirmar.UseSystemPasswordChar = true;
      txtPassConfirmar.TextChanged += TxtPass_TextChanged;
      // 
      // btnEyeConfirmar
      // 
      btnEyeConfirmar.BackColor = Color.FromArgb(241, 245, 249);
      btnEyeConfirmar.Cursor = Cursors.Hand;
      btnEyeConfirmar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
      btnEyeConfirmar.FlatStyle = FlatStyle.Flat;
      btnEyeConfirmar.Font = new Font("Segoe MDL2 Assets", 10F);
      btnEyeConfirmar.ForeColor = Color.FromArgb(0, 70, 148);
      btnEyeConfirmar.Location = new Point(663, 64);
      btnEyeConfirmar.Name = "btnEyeConfirmar";
      btnEyeConfirmar.Size = new Size(32, 27);
      btnEyeConfirmar.TabIndex = 9;
      btnEyeConfirmar.Text = "";
      btnEyeConfirmar.UseVisualStyleBackColor = false;
      btnEyeConfirmar.Click += BtnEyeConfirmar_Click;
      // 
      // lblPassMatch
      // 
      lblPassMatch.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      lblPassMatch.ForeColor = Color.FromArgb(185, 28, 28);
      lblPassMatch.Location = new Point(250, 97);
      lblPassMatch.Name = "lblPassMatch";
      lblPassMatch.Size = new Size(450, 20);
      lblPassMatch.TabIndex = 10;
      // 
      // chkNotifEmail
      // 
      chkNotifEmail.AutoSize = true;
      chkNotifEmail.Checked = true;
      chkNotifEmail.CheckState = CheckState.Checked;
      chkNotifEmail.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      chkNotifEmail.ForeColor = Color.FromArgb(30, 41, 59);
      chkNotifEmail.Location = new Point(20, 130);
      chkNotifEmail.Name = "chkNotifEmail";
      chkNotifEmail.Size = new Size(435, 24);
      chkNotifEmail.TabIndex = 11;
      chkNotifEmail.Text = "Recibir recordatorios y comprobantes de turnos por Email";
      // 
      // chkNotifWhatsapp
      // 
      chkNotifWhatsapp.AutoSize = true;
      chkNotifWhatsapp.Checked = true;
      chkNotifWhatsapp.CheckState = CheckState.Checked;
      chkNotifWhatsapp.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
      chkNotifWhatsapp.ForeColor = Color.FromArgb(30, 41, 59);
      chkNotifWhatsapp.Location = new Point(20, 155);
      chkNotifWhatsapp.Name = "chkNotifWhatsapp";
      chkNotifWhatsapp.Size = new Size(464, 24);
      chkNotifWhatsapp.TabIndex = 12;
      chkNotifWhatsapp.Text = "Recibir avisos de estado de sala y alertas por SMS / WhatsApp";
      // 
      // btnGuardar
      // 
      btnGuardar.BackColor = Color.FromArgb(0, 70, 148);
      btnGuardar.Cursor = Cursors.Hand;
      btnGuardar.FlatAppearance.BorderSize = 0;
      btnGuardar.FlatStyle = FlatStyle.Flat;
      btnGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      btnGuardar.ForeColor = Color.White;
      btnGuardar.Location = new Point(25, 740);
      btnGuardar.Name = "btnGuardar";
      btnGuardar.Padding = new Padding(12, 0, 12, 0);
      btnGuardar.Size = new Size(260, 44);
      btnGuardar.TabIndex = 4;
      btnGuardar.Text = "💾 Guardar Todos los Cambios";
      btnGuardar.UseVisualStyleBackColor = false;
      btnGuardar.Click += BtnGuardar_Click;
      // 
      // lblFeedback
      // 
      lblFeedback.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblFeedback.ForeColor = Color.FromArgb(21, 128, 61);
      lblFeedback.Location = new Point(300, 750);
      lblFeedback.Name = "lblFeedback";
      lblFeedback.Size = new Size(465, 30);
      lblFeedback.TabIndex = 5;
      // 
      // ConfiguracionControl
      // 
      BackColor = Color.FromArgb(240, 244, 248);
      Controls.Add(pnlBody);
      Controls.Add(pnlTop);
      Font = new Font("Segoe UI", 9.5F);
      Name = "ConfiguracionControl";
      Size = new Size(1560, 742);
      pnlTop.ResumeLayout(false);
      pnlTop.PerformLayout();
      pnlBody.ResumeLayout(false);
      pnlFotoCard.ResumeLayout(false);
      pnlFotoCard.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
      pnlDatosCard.ResumeLayout(false);
      pnlDatosCard.PerformLayout();
      pnlOSCard.ResumeLayout(false);
      pnlOSCard.PerformLayout();
      pnlSegCard.ResumeLayout(false);
      pnlSegCard.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlFotoCard;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblAvatarIniciales;
        private System.Windows.Forms.Button btnCambiarFoto;
        private System.Windows.Forms.Button btnQuitarFoto;
        private System.Windows.Forms.Label lblFotoInfo;
        private System.Windows.Forms.Panel pnlDatosCard;
        private System.Windows.Forms.Label lblDatosTitle;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Panel pnlOSCard;
        private System.Windows.Forms.Label lblOSTitle;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.ComboBox cbObraSocial;
        private System.Windows.Forms.Label lblAf;
        private System.Windows.Forms.TextBox txtAfiliado;
        private System.Windows.Forms.Panel pnlSegCard;
        private System.Windows.Forms.Label lblSegTitle;
        private System.Windows.Forms.Label lblPassActual;
        private System.Windows.Forms.TextBox txtPassActual;
        private System.Windows.Forms.Button btnEyeActual;
        private System.Windows.Forms.Label lblPassNueva;
        private System.Windows.Forms.TextBox txtPassNueva;
        private System.Windows.Forms.Button btnEyeNueva;
        private System.Windows.Forms.Label lblPassConfirmar;
        private System.Windows.Forms.TextBox txtPassConfirmar;
        private System.Windows.Forms.Button btnEyeConfirmar;
        private System.Windows.Forms.Label lblPassMatch;
        private System.Windows.Forms.CheckBox chkNotifEmail;
        private System.Windows.Forms.CheckBox chkNotifWhatsapp;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblFeedback;
    }
}
