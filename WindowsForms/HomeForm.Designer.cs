#nullable disable

namespace WindowsForms
{
    partial class HomeForm
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuMaestros = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOdontologos = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.itemInsumos = new System.Windows.Forms.ToolStripMenuItem();
            this.sepMaestros1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.sepMaestros2 = new System.Windows.Forms.ToolStripSeparator();
            this.itemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClinica = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTurnos = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAdmision = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAtencion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCaja = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCobro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMetricas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPortal = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPortalHome = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPortalTurnos = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPortalHistoria = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPortalPagos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            //
            // menuMain
            //
            this.menuMain.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.menuMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuMain.ForeColor = System.Drawing.Color.White;
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.menuMaestros,
                this.menuClinica,
                this.menuCaja,
                this.menuReportes,
                this.menuPortal
            });
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.menuMain.Size = new System.Drawing.Size(1284, 29);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuMain";
            //
            // menuMaestros
            //
            this.menuMaestros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuMaestros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.itemPacientes,
                this.itemOdontologos,
                this.itemEspecialidades,
                this.itemInsumos,
                this.sepMaestros1,
                this.itemConfig,
                this.sepMaestros2,
                this.itemLogout,
                this.itemSalir
            });
            this.menuMaestros.ForeColor = System.Drawing.Color.White;
            this.menuMaestros.Name = "menuMaestros";
            this.menuMaestros.Size = new System.Drawing.Size(92, 21);
            this.menuMaestros.Text = "📁 Maestros";
            //
            // itemPacientes
            //
            this.itemPacientes.Name = "itemPacientes";
            this.itemPacientes.Size = new System.Drawing.Size(235, 24);
            this.itemPacientes.Text = "👥 Pacientes";
            this.itemPacientes.Click += new System.EventHandler(this.ItemPacientes_Click);
            //
            // itemOdontologos
            //
            this.itemOdontologos.Name = "itemOdontologos";
            this.itemOdontologos.Size = new System.Drawing.Size(235, 24);
            this.itemOdontologos.Text = "🩺 Odontólogos";
            this.itemOdontologos.Click += new System.EventHandler(this.ItemOdontologos_Click);
            //
            // itemEspecialidades
            //
            this.itemEspecialidades.Name = "itemEspecialidades";
            this.itemEspecialidades.Size = new System.Drawing.Size(235, 24);
            this.itemEspecialidades.Text = "🏷️ Especialidades";
            this.itemEspecialidades.Click += new System.EventHandler(this.ItemEspecialidades_Click);
            //
            // itemInsumos
            //
            this.itemInsumos.Name = "itemInsumos";
            this.itemInsumos.Size = new System.Drawing.Size(235, 24);
            this.itemInsumos.Text = "📦 Insumos y Stock";
            this.itemInsumos.Click += new System.EventHandler(this.ItemInsumos_Click);
            //
            // sepMaestros1
            //
            this.sepMaestros1.Name = "sepMaestros1";
            this.sepMaestros1.Size = new System.Drawing.Size(232, 6);
            //
            // itemConfig
            //
            this.itemConfig.Name = "itemConfig";
            this.itemConfig.Size = new System.Drawing.Size(235, 24);
            this.itemConfig.Text = "⚙️ Configuración de Perfil";
            this.itemConfig.Click += new System.EventHandler(this.ItemConfig_Click);
            //
            // sepMaestros2
            //
            this.sepMaestros2.Name = "sepMaestros2";
            this.sepMaestros2.Size = new System.Drawing.Size(232, 6);
            //
            // itemLogout
            //
            this.itemLogout.Name = "itemLogout";
            this.itemLogout.Size = new System.Drawing.Size(235, 24);
            this.itemLogout.Text = "🚪 Cerrar Sesión";
            this.itemLogout.Click += new System.EventHandler(this.ItemLogout_Click);
            //
            // itemSalir
            //
            this.itemSalir.Name = "itemSalir";
            this.itemSalir.Size = new System.Drawing.Size(235, 24);
            this.itemSalir.Text = "❌ Salir";
            this.itemSalir.Click += new System.EventHandler(this.ItemSalir_Click);
            //
            // menuClinica
            //
            this.menuClinica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuClinica.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.itemTurnos,
                this.itemAdmision,
                this.itemAtencion
            });
            this.menuClinica.ForeColor = System.Drawing.Color.White;
            this.menuClinica.Name = "menuClinica";
            this.menuClinica.Size = new System.Drawing.Size(130, 21);
            this.menuClinica.Text = "🏥 Gestión Clínica";
            //
            // itemTurnos
            //
            this.itemTurnos.Name = "itemTurnos";
            this.itemTurnos.Size = new System.Drawing.Size(252, 24);
            this.itemTurnos.Text = "📅 Gestión de Turnos";
            this.itemTurnos.Click += new System.EventHandler(this.ItemTurnos_Click);
            //
            // itemAdmision
            //
            this.itemAdmision.Name = "itemAdmision";
            this.itemAdmision.Size = new System.Drawing.Size(252, 24);
            this.itemAdmision.Text = "🛎️ Recepción / Sala de Espera";
            this.itemAdmision.Click += new System.EventHandler(this.ItemAdmision_Click);
            //
            // itemAtencion
            //
            this.itemAtencion.Name = "itemAtencion";
            this.itemAtencion.Size = new System.Drawing.Size(252, 24);
            this.itemAtencion.Text = "💉 Consola Médica";
            this.itemAtencion.Click += new System.EventHandler(this.ItemAtencion_Click);
            //
            // menuCaja
            //
            this.menuCaja.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuCaja.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.itemCobro
            });
            this.menuCaja.ForeColor = System.Drawing.Color.White;
            this.menuCaja.Name = "menuCaja";
            this.menuCaja.Size = new System.Drawing.Size(156, 21);
            this.menuCaja.Text = "💳 Caja y Facturación";
            //
            // itemCobro
            //
            this.itemCobro.Name = "itemCobro";
            this.itemCobro.Size = new System.Drawing.Size(242, 24);
            this.itemCobro.Text = "🧾 Cobro, Caja y Liquidación";
            this.itemCobro.Click += new System.EventHandler(this.ItemCobro_Click);
            //
            // menuReportes
            //
            this.menuReportes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.itemMetricas
            });
            this.menuReportes.ForeColor = System.Drawing.Color.White;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(92, 21);
            this.menuReportes.Text = "📊 Reportes";
            //
            // itemMetricas
            //
            this.itemMetricas.Name = "itemMetricas";
            this.itemMetricas.Size = new System.Drawing.Size(202, 24);
            this.itemMetricas.Text = "📈 Reportes y Métricas";
            this.itemMetricas.Click += new System.EventHandler(this.ItemMetricas_Click);
            //
            // menuPortal
            //
            this.menuPortal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuPortal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.itemPortalHome,
                this.itemPortalTurnos,
                this.itemPortalHistoria,
                this.itemPortalPagos
            });
            this.menuPortal.ForeColor = System.Drawing.Color.White;
            this.menuPortal.Name = "menuPortal";
            this.menuPortal.Size = new System.Drawing.Size(128, 21);
            this.menuPortal.Text = "👤 Portal Paciente";
            this.menuPortal.Visible = false;
            //
            // itemPortalHome
            //
            this.itemPortalHome.Name = "itemPortalHome";
            this.itemPortalHome.Size = new System.Drawing.Size(218, 24);
            this.itemPortalHome.Text = "🏠 Mi Portal del Paciente";
            this.itemPortalHome.Click += new System.EventHandler(this.ItemPortalHome_Click);
            //
            // itemPortalTurnos
            //
            this.itemPortalTurnos.Name = "itemPortalTurnos";
            this.itemPortalTurnos.Size = new System.Drawing.Size(218, 24);
            this.itemPortalTurnos.Text = "📅 Mis Turnos y Citas";
            this.itemPortalTurnos.Click += new System.EventHandler(this.ItemPortalTurnos_Click);
            //
            // itemPortalHistoria
            //
            this.itemPortalHistoria.Name = "itemPortalHistoria";
            this.itemPortalHistoria.Size = new System.Drawing.Size(218, 24);
            this.itemPortalHistoria.Text = "📋 Mi Historial Clínico";
            this.itemPortalHistoria.Click += new System.EventHandler(this.ItemPortalHistoria_Click);
            //
            // itemPortalPagos
            //
            this.itemPortalPagos.Name = "itemPortalPagos";
            this.itemPortalPagos.Size = new System.Drawing.Size(218, 24);
            this.itemPortalPagos.Text = "💳 Mis Pagos y Deudas";
            this.itemPortalPagos.Click += new System.EventHandler(this.ItemPortalPagos_Click);
            //
            // HomeForm
            //
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize = new System.Drawing.Size(1284, 811);
            this.Controls.Add(this.menuMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(1080, 680);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínica Odontológica - Sistema MDI de Gestión Integral";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuMaestros;
        private System.Windows.Forms.ToolStripMenuItem itemPacientes;
        private System.Windows.Forms.ToolStripMenuItem itemOdontologos;
        private System.Windows.Forms.ToolStripMenuItem itemEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem itemInsumos;
        private System.Windows.Forms.ToolStripSeparator sepMaestros1;
        private System.Windows.Forms.ToolStripMenuItem itemConfig;
        private System.Windows.Forms.ToolStripSeparator sepMaestros2;
        private System.Windows.Forms.ToolStripMenuItem itemLogout;
        private System.Windows.Forms.ToolStripMenuItem itemSalir;
        private System.Windows.Forms.ToolStripMenuItem menuClinica;
        private System.Windows.Forms.ToolStripMenuItem itemTurnos;
        private System.Windows.Forms.ToolStripMenuItem itemAdmision;
        private System.Windows.Forms.ToolStripMenuItem itemAtencion;
        private System.Windows.Forms.ToolStripMenuItem menuCaja;
        private System.Windows.Forms.ToolStripMenuItem itemCobro;
        private System.Windows.Forms.ToolStripMenuItem menuReportes;
        private System.Windows.Forms.ToolStripMenuItem itemMetricas;
        private System.Windows.Forms.ToolStripMenuItem menuPortal;
        private System.Windows.Forms.ToolStripMenuItem itemPortalHome;
        private System.Windows.Forms.ToolStripMenuItem itemPortalTurnos;
        private System.Windows.Forms.ToolStripMenuItem itemPortalHistoria;
        private System.Windows.Forms.ToolStripMenuItem itemPortalPagos;
    }
}
