#nullable disable

namespace WindowsForms
{
    partial class LoginForm
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
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnPassword = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblFoot = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlCard
            //
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblLogo);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblSub);
            this.pnlCard.Controls.Add(this.lblUser);
            this.pnlCard.Controls.Add(this.txtUsername);
            this.pnlCard.Controls.Add(this.lblPass);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.btnPassword);
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.btnLogin);
            this.pnlCard.Controls.Add(this.lblFoot);
            this.pnlCard.Location = new System.Drawing.Point(20, 15);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(415, 390);
            this.pnlCard.TabIndex = 0;
            this.pnlCard.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlCard_Paint);
            //
            // lblLogo
            //
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLogo.Location = new System.Drawing.Point(0, 20);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(415, 45);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "🦷";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblTitle.Location = new System.Drawing.Point(0, 68);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(415, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Clínica Odontológica";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSub
            //
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSub.Location = new System.Drawing.Point(0, 98);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(415, 20);
            this.lblSub.TabIndex = 2;
            this.lblSub.Text = "Gestión Odontológica Profesional • Sede Rosario";
            this.lblSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblUser
            //
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblUser.Location = new System.Drawing.Point(30, 133);
            this.lblUser.Name = "lblUser";
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Usuario / Número de Documento:";
            //
            // txtUsername
            //
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.Location = new System.Drawing.Point(30, 155);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(355, 24);
            this.txtUsername.TabIndex = 4;
            //
            // lblPass
            //
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblPass.Location = new System.Drawing.Point(30, 190);
            this.lblPass.Name = "lblPass";
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Contraseña:";
            //
            // txtPassword
            //
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(30, 212);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(315, 24);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            //
            // btnPassword
            //
            this.btnPassword.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassword.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPassword.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnPassword.Location = new System.Drawing.Point(350, 211);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(35, 27);
            this.btnPassword.TabIndex = 7;
            this.btnPassword.Text = "";
            this.btnPassword.UseVisualStyleBackColor = false;
            this.btnPassword.Click += new System.EventHandler(this.BtnPassword_Click);
            //
            // lblError
            //
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.lblError.Location = new System.Drawing.Point(30, 252);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(355, 20);
            this.lblError.TabIndex = 8;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnLogin
            //
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(30, 276);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnLogin.Size = new System.Drawing.Size(355, 42);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            //
            // lblFoot
            //
            this.lblFoot.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFoot.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblFoot.Location = new System.Drawing.Point(0, 326);
            this.lblFoot.Name = "lblFoot";
            this.lblFoot.Size = new System.Drawing.Size(415, 18);
            this.lblFoot.TabIndex = 10;
            this.lblFoot.Text = "© 2026 Clínica Odontológica Rosario • Todos los derechos reservados";
            this.lblFoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // LoginForm
            //
            this.AcceptButton = this.btnLogin;
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize = new System.Drawing.Size(455, 420);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínica Odontológica - Acceso al Sistema";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblFoot;
    }
}
