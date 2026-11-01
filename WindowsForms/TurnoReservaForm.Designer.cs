#nullable disable

namespace WindowsForms
{
    partial class TurnoReservaForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.cbPaciente = new System.Windows.Forms.ComboBox();
            this.lblEstadoPaciente = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblOdontologo = new System.Windows.Forms.Label();
            this.cbOdontologo = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHorario = new System.Windows.Forms.Label();
            this.cbHorario = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMontoEstimado = new System.Windows.Forms.Label();
            this.chkPoliticas = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            //
            // lblHeader
            //
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.lblHeader.Location = new System.Drawing.Point(25, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(392, 28);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "📅 Agendamiento de Turno Odontológico";
            //
            // lblPaciente
            //
            this.lblPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPaciente.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblPaciente.Location = new System.Drawing.Point(25, 68);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(150, 22);
            this.lblPaciente.TabIndex = 1;
            this.lblPaciente.Text = "1. Paciente *:";
            //
            // cbPaciente
            //
            this.cbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaciente.Location = new System.Drawing.Point(175, 65);
            this.cbPaciente.Name = "cbPaciente";
            this.cbPaciente.Size = new System.Drawing.Size(380, 28);
            this.cbPaciente.TabIndex = 2;
            this.cbPaciente.SelectedIndexChanged += new System.EventHandler(this.CbPaciente_SelectedIndexChanged);
            //
            // lblEstadoPaciente
            //
            this.lblEstadoPaciente.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEstadoPaciente.Location = new System.Drawing.Point(175, 98);
            this.lblEstadoPaciente.Name = "lblEstadoPaciente";
            this.lblEstadoPaciente.Size = new System.Drawing.Size(380, 24);
            this.lblEstadoPaciente.TabIndex = 3;
            //
            // lblEspecialidad
            //
            this.lblEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEspecialidad.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblEspecialidad.Location = new System.Drawing.Point(25, 131);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(150, 22);
            this.lblEspecialidad.TabIndex = 4;
            this.lblEspecialidad.Text = "2. Especialidad *:";
            //
            // cbEspecialidad
            //
            this.cbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspecialidad.Location = new System.Drawing.Point(175, 128);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(380, 28);
            this.cbEspecialidad.TabIndex = 5;
            this.cbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.CbEspecialidad_SelectedIndexChanged);
            //
            // lblOdontologo
            //
            this.lblOdontologo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOdontologo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblOdontologo.Location = new System.Drawing.Point(25, 169);
            this.lblOdontologo.Name = "lblOdontologo";
            this.lblOdontologo.Size = new System.Drawing.Size(150, 22);
            this.lblOdontologo.TabIndex = 6;
            this.lblOdontologo.Text = "3. Profesional *:";
            //
            // cbOdontologo
            //
            this.cbOdontologo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOdontologo.Location = new System.Drawing.Point(175, 166);
            this.cbOdontologo.Name = "cbOdontologo";
            this.cbOdontologo.Size = new System.Drawing.Size(380, 28);
            this.cbOdontologo.TabIndex = 7;
            //
            // lblFecha
            //
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblFecha.Location = new System.Drawing.Point(25, 207);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(150, 22);
            this.lblFecha.TabIndex = 8;
            this.lblFecha.Text = "4. Fecha de Cita *:";
            //
            // dtpFecha
            //
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(175, 204);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(380, 28);
            this.dtpFecha.TabIndex = 9;
            //
            // lblHorario
            //
            this.lblHorario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHorario.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblHorario.Location = new System.Drawing.Point(25, 245);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(150, 22);
            this.lblHorario.TabIndex = 10;
            this.lblHorario.Text = "5. Horario *:";
            //
            // cbHorario
            //
            this.cbHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHorario.Items.AddRange(new object[] {
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00"});
            this.cbHorario.Location = new System.Drawing.Point(175, 242);
            this.cbHorario.Name = "cbHorario";
            this.cbHorario.Size = new System.Drawing.Size(380, 28);
            this.cbHorario.TabIndex = 11;
            //
            // lblMetodoPago
            //
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblMetodoPago.Location = new System.Drawing.Point(25, 283);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(150, 22);
            this.lblMetodoPago.TabIndex = 12;
            this.lblMetodoPago.Text = "6. Cobertura / Pago *:";
            //
            // cbMetodoPago
            //
            this.cbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetodoPago.Items.AddRange(new object[] {
            "Obra Social / Cobertura Médica",
            "Particular (Efectivo / Tarjeta)"});
            this.cbMetodoPago.Location = new System.Drawing.Point(175, 280);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(380, 28);
            this.cbMetodoPago.TabIndex = 13;
            //
            // lblMontoEstimado
            //
            this.lblMontoEstimado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMontoEstimado.ForeColor = System.Drawing.Color.FromArgb(0, 51, 112);
            this.lblMontoEstimado.Location = new System.Drawing.Point(175, 318);
            this.lblMontoEstimado.Name = "lblMontoEstimado";
            this.lblMontoEstimado.Size = new System.Drawing.Size(380, 24);
            this.lblMontoEstimado.TabIndex = 14;
            this.lblMontoEstimado.Text = "Arancel Estimado de Consulta: $ 12.000,00 (Sujeto a cobertura)";
            //
            // chkPoliticas
            //
            this.chkPoliticas.Checked = true;
            this.chkPoliticas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPoliticas.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkPoliticas.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkPoliticas.Location = new System.Drawing.Point(175, 353);
            this.chkPoliticas.Name = "chkPoliticas";
            this.chkPoliticas.Size = new System.Drawing.Size(380, 30);
            this.chkPoliticas.TabIndex = 15;
            this.chkPoliticas.Text = "Acepto las políticas de cancelación (mínimo 24 hs antes) y asistencia.";
            //
            // lblError
            //
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.lblError.Location = new System.Drawing.Point(25, 388);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(540, 35);
            this.lblError.TabIndex = 16;
            //
            // pnlActions
            //
            this.pnlActions.Controls.Add(this.btnReservar);
            this.pnlActions.Controls.Add(this.btnCancelar);
            this.pnlActions.Location = new System.Drawing.Point(175, 428);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(380, 45);
            this.pnlActions.TabIndex = 17;
            //
            // btnReservar
            //
            this.btnReservar.BackColor = System.Drawing.Color.FromArgb(0, 70, 148);
            this.btnReservar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservar.FlatAppearance.BorderSize = 0;
            this.btnReservar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReservar.ForeColor = System.Drawing.Color.White;
            this.btnReservar.Location = new System.Drawing.Point(0, 0);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnReservar.Size = new System.Drawing.Size(190, 40);
            this.btnReservar.TabIndex = 0;
            this.btnReservar.Text = "✅ Confirmar Reserva";
            this.btnReservar.UseVisualStyleBackColor = false;
            this.btnReservar.Click += new System.EventHandler(this.BtnReservar_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(200, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCancelar.Size = new System.Drawing.Size(130, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            //
            // TurnoReservaForm
            //
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(604, 641);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.cbPaciente);
            this.Controls.Add(this.lblEstadoPaciente);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.cbEspecialidad);
            this.Controls.Add(this.lblOdontologo);
            this.Controls.Add(this.cbOdontologo);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.cbHorario);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.cbMetodoPago);
            this.Controls.Add(this.lblMontoEstimado);
            this.Controls.Add(this.chkPoliticas);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pnlActions);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TurnoReservaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agendar Turno Odontológico - Clínica Dental";
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cbPaciente;
        private System.Windows.Forms.Label lblEstadoPaciente;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cbEspecialidad;
        private System.Windows.Forms.Label lblOdontologo;
        private System.Windows.Forms.ComboBox cbOdontologo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.ComboBox cbHorario;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.Label lblMontoEstimado;
        private System.Windows.Forms.CheckBox chkPoliticas;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
