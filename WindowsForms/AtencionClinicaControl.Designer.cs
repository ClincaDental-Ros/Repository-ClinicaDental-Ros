#nullable disable

namespace WindowsForms
{
    partial class AtencionClinicaControl
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
      lblSubtitle = new Label();
      pnlBody = new Panel();
      lblTurno = new Label();
      cbTurnosPresentes = new ComboBox();
      btnActualizar = new Button();
      lblPacienteInfo = new Label();
      lblDiag = new Label();
      txtDiagnostico = new TextBox();
      lblTrat = new Label();
      cbTratamiento = new ComboBox();
      pnlChecks = new Panel();
      chkAnestesia = new CheckBox();
      chkRadiografia = new CheckBox();
      lblObs = new Label();
      txtObservaciones = new TextBox();
      lblIns = new Label();
      clbInsumos = new CheckedListBox();
      btnFinalizar = new Button();
      lblEstado = new Label();
      pnlTop.SuspendLayout();
      pnlBody.SuspendLayout();
      pnlChecks.SuspendLayout();
      SuspendLayout();
      // 
      // pnlTop
      // 
      pnlTop.BackColor = Color.White;
      pnlTop.Controls.Add(lblTitle);
      pnlTop.Controls.Add(lblSubtitle);
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
      lblTitle.Size = new Size(496, 30);
      lblTitle.TabIndex = 0;
      lblTitle.Text = "Consola Médica Odontológica - Evolución Clínica";
      // 
      // lblSubtitle
      // 
      lblSubtitle.AutoSize = true;
      lblSubtitle.Font = new Font("Segoe UI", 8.5F);
      lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
      lblSubtitle.Location = new Point(27, 40);
      lblSubtitle.Name = "lblSubtitle";
      lblSubtitle.Size = new Size(708, 20);
      lblSubtitle.TabIndex = 1;
      lblSubtitle.Text = "Diagnóstico (CIE-10), tratamientos realizados, consumo de insumos y derivación automática a facturación";
      // 
      // pnlBody
      // 
      pnlBody.AutoScroll = true;
      pnlBody.BackColor = Color.White;
      pnlBody.Controls.Add(lblTurno);
      pnlBody.Controls.Add(cbTurnosPresentes);
      pnlBody.Controls.Add(btnActualizar);
      pnlBody.Controls.Add(lblPacienteInfo);
      pnlBody.Controls.Add(lblDiag);
      pnlBody.Controls.Add(txtDiagnostico);
      pnlBody.Controls.Add(lblTrat);
      pnlBody.Controls.Add(cbTratamiento);
      pnlBody.Controls.Add(pnlChecks);
      pnlBody.Controls.Add(lblObs);
      pnlBody.Controls.Add(txtObservaciones);
      pnlBody.Controls.Add(lblIns);
      pnlBody.Controls.Add(clbInsumos);
      pnlBody.Controls.Add(btnFinalizar);
      pnlBody.Dock = DockStyle.Fill;
      pnlBody.Location = new Point(0, 70);
      pnlBody.Name = "pnlBody";
      pnlBody.Padding = new Padding(25, 15, 25, 15);
      pnlBody.Size = new Size(1560, 640);
      pnlBody.TabIndex = 1;
      // 
      // lblTurno
      // 
      lblTurno.AutoSize = true;
      lblTurno.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
      lblTurno.ForeColor = Color.FromArgb(0, 70, 148);
      lblTurno.Location = new Point(20, 15);
      lblTurno.Name = "lblTurno";
      lblTurno.Size = new Size(394, 23);
      lblTurno.TabIndex = 0;
      lblTurno.Text = "1. Paciente en Sala de Espera (Estado: Presente):";
      // 
      // cbTurnosPresentes
      // 
      cbTurnosPresentes.DropDownStyle = ComboBoxStyle.DropDownList;
      cbTurnosPresentes.FormattingEnabled = true;
      cbTurnosPresentes.Location = new Point(20, 50);
      cbTurnosPresentes.Name = "cbTurnosPresentes";
      cbTurnosPresentes.Size = new Size(520, 29);
      cbTurnosPresentes.TabIndex = 1;
      cbTurnosPresentes.SelectedIndexChanged += CbTurnosPresentes_SelectedIndexChanged;
      // 
      // btnActualizar
      // 
      btnActualizar.BackColor = Color.White;
      btnActualizar.Cursor = Cursors.Hand;
      btnActualizar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
      btnActualizar.FlatStyle = FlatStyle.Flat;
      btnActualizar.Font = new Font("Segoe UI", 9.5F);
      btnActualizar.ForeColor = Color.FromArgb(30, 41, 59);
      btnActualizar.Location = new Point(555, 48);
      btnActualizar.Name = "btnActualizar";
      btnActualizar.Padding = new Padding(10, 0, 10, 0);
      btnActualizar.Size = new Size(170, 32);
      btnActualizar.TabIndex = 2;
      btnActualizar.Text = "🔄 Refrescar Espera";
      btnActualizar.UseVisualStyleBackColor = false;
      btnActualizar.Click += BtnActualizar_Click;
      // 
      // lblPacienteInfo
      // 
      lblPacienteInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblPacienteInfo.ForeColor = Color.FromArgb(100, 116, 139);
      lblPacienteInfo.Location = new Point(20, 85);
      lblPacienteInfo.Name = "lblPacienteInfo";
      lblPacienteInfo.Size = new Size(720, 25);
      lblPacienteInfo.TabIndex = 3;
      // 
      // lblDiag
      // 
      lblDiag.AutoSize = true;
      lblDiag.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblDiag.ForeColor = Color.FromArgb(30, 41, 59);
      lblDiag.Location = new Point(20, 120);
      lblDiag.Name = "lblDiag";
      lblDiag.Size = new Size(313, 21);
      lblDiag.TabIndex = 4;
      lblDiag.Text = "2. Diagnóstico Clínico / Código CIE-10 *:";
      // 
      // txtDiagnostico
      // 
      txtDiagnostico.Location = new Point(20, 145);
      txtDiagnostico.Name = "txtDiagnostico";
      txtDiagnostico.Size = new Size(720, 29);
      txtDiagnostico.TabIndex = 5;
      txtDiagnostico.Text = "K02.1 Caries de la dentina / Restauración estética";
      // 
      // lblTrat
      // 
      lblTrat.AutoSize = true;
      lblTrat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblTrat.ForeColor = Color.FromArgb(30, 41, 59);
      lblTrat.Location = new Point(20, 180);
      lblTrat.Name = "lblTrat";
      lblTrat.Size = new Size(385, 21);
      lblTrat.TabIndex = 6;
      lblTrat.Text = "3. Tipo de Tratamiento Odontológico Realizado *:";
      // 
      // cbTratamiento
      // 
      cbTratamiento.DropDownStyle = ComboBoxStyle.DropDownList;
      cbTratamiento.FormattingEnabled = true;
      cbTratamiento.Items.AddRange(new object[] { "Limpieza y Profilaxis Dental", "Restauración con Resina Fotocurable", "Tratamiento de Conducto (Endodoncia)", "Extracción Simple", "Extracción Quirúrgica / Implante", "Ajuste y Control de Ortodoncia", "Consulta y Diagnóstico General" });
      cbTratamiento.Location = new Point(20, 205);
      cbTratamiento.Name = "cbTratamiento";
      cbTratamiento.Size = new Size(420, 29);
      cbTratamiento.TabIndex = 7;
      // 
      // pnlChecks
      // 
      pnlChecks.Controls.Add(chkAnestesia);
      pnlChecks.Controls.Add(chkRadiografia);
      pnlChecks.Location = new Point(20, 240);
      pnlChecks.Name = "pnlChecks";
      pnlChecks.Size = new Size(720, 35);
      pnlChecks.TabIndex = 8;
      // 
      // chkAnestesia
      // 
      chkAnestesia.AutoSize = true;
      chkAnestesia.Checked = true;
      chkAnestesia.CheckState = CheckState.Checked;
      chkAnestesia.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      chkAnestesia.ForeColor = Color.FromArgb(30, 41, 59);
      chkAnestesia.Location = new Point(0, 5);
      chkAnestesia.Name = "chkAnestesia";
      chkAnestesia.Size = new Size(202, 25);
      chkAnestesia.TabIndex = 0;
      chkAnestesia.Text = "Aplicó Anestesia Local";
      chkAnestesia.UseVisualStyleBackColor = true;
      // 
      // chkRadiografia
      // 
      chkRadiografia.AutoSize = true;
      chkRadiografia.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      chkRadiografia.ForeColor = Color.FromArgb(30, 41, 59);
      chkRadiografia.Location = new Point(240, 5);
      chkRadiografia.Name = "chkRadiografia";
      chkRadiografia.Size = new Size(384, 25);
      chkRadiografia.TabIndex = 1;
      chkRadiografia.Text = "Tomó Radiografías Periapicales / Panorámicas";
      chkRadiografia.UseVisualStyleBackColor = true;
      // 
      // lblObs
      // 
      lblObs.AutoSize = true;
      lblObs.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblObs.ForeColor = Color.FromArgb(30, 41, 59);
      lblObs.Location = new Point(20, 280);
      lblObs.Name = "lblObs";
      lblObs.Size = new Size(292, 21);
      lblObs.TabIndex = 9;
      lblObs.Text = "4. Observaciones y Evolución Clínica:";
      // 
      // txtObservaciones
      // 
      txtObservaciones.Location = new Point(20, 305);
      txtObservaciones.Multiline = true;
      txtObservaciones.Name = "txtObservaciones";
      txtObservaciones.Size = new Size(720, 65);
      txtObservaciones.TabIndex = 10;
      txtObservaciones.Text = "Paciente tolera adecuadamente el procedimiento. Se indica control preventivo en 6 meses.";
      // 
      // lblIns
      // 
      lblIns.AutoSize = true;
      lblIns.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      lblIns.ForeColor = Color.FromArgb(30, 41, 59);
      lblIns.Location = new Point(20, 385);
      lblIns.Name = "lblIns";
      lblIns.Size = new Size(689, 21);
      lblIns.TabIndex = 11;
      lblIns.Text = "5. Insumos Consumidos durante la Atención (Se descontarán de Stock automáticamente):";
      // 
      // clbInsumos
      // 
      clbInsumos.CheckOnClick = true;
      clbInsumos.FormattingEnabled = true;
      clbInsumos.Location = new Point(20, 410);
      clbInsumos.Name = "clbInsumos";
      clbInsumos.Size = new Size(720, 100);
      clbInsumos.TabIndex = 12;
      // 
      // btnFinalizar
      // 
      btnFinalizar.BackColor = Color.FromArgb(21, 128, 61);
      btnFinalizar.Cursor = Cursors.Hand;
      btnFinalizar.FlatAppearance.BorderSize = 0;
      btnFinalizar.FlatStyle = FlatStyle.Flat;
      btnFinalizar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      btnFinalizar.ForeColor = Color.White;
      btnFinalizar.Location = new Point(20, 525);
      btnFinalizar.Name = "btnFinalizar";
      btnFinalizar.Padding = new Padding(12, 0, 12, 0);
      btnFinalizar.Size = new Size(360, 44);
      btnFinalizar.TabIndex = 13;
      btnFinalizar.Text = "\U0001fa7a Finalizar Atención y Enviar Orden a Caja";
      btnFinalizar.UseVisualStyleBackColor = false;
      btnFinalizar.Click += BtnFinalizar_Click;
      // 
      // lblEstado
      // 
      lblEstado.BackColor = Color.White;
      lblEstado.Dock = DockStyle.Bottom;
      lblEstado.Font = new Font("Segoe UI", 8.5F);
      lblEstado.ForeColor = Color.FromArgb(100, 116, 139);
      lblEstado.Location = new Point(0, 710);
      lblEstado.Name = "lblEstado";
      lblEstado.Padding = new Padding(25, 6, 0, 0);
      lblEstado.Size = new Size(1560, 32);
      lblEstado.TabIndex = 2;
      // 
      // AtencionClinicaControl
      // 
      BackColor = Color.FromArgb(240, 244, 248);
      Controls.Add(pnlBody);
      Controls.Add(lblEstado);
      Controls.Add(pnlTop);
      Font = new Font("Segoe UI", 9.5F);
      Name = "AtencionClinicaControl";
      Size = new Size(1560, 742);
      pnlTop.ResumeLayout(false);
      pnlTop.PerformLayout();
      pnlBody.ResumeLayout(false);
      pnlBody.PerformLayout();
      pnlChecks.ResumeLayout(false);
      pnlChecks.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ComboBox cbTurnosPresentes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblPacienteInfo;
        private System.Windows.Forms.Label lblDiag;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label lblTrat;
        private System.Windows.Forms.ComboBox cbTratamiento;
        private System.Windows.Forms.Panel pnlChecks;
        private System.Windows.Forms.CheckBox chkAnestesia;
        private System.Windows.Forms.CheckBox chkRadiografia;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblIns;
        private System.Windows.Forms.CheckedListBox clbInsumos;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label lblEstado;
    }
}
