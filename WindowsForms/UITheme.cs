using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsForms
{
    public static class UITheme
    {
        
        public static readonly Color Primary = Color.FromArgb(0, 70, 148);          // #004694 Azul Médico Institucional
        public static readonly Color PrimaryDark = Color.FromArgb(0, 51, 112);      // #003370
        public static readonly Color PrimaryLight = Color.FromArgb(230, 240, 250); // #e6f0fa Azul Suave
        public static readonly Color Accent = Color.FromArgb(0, 91, 181);          // #005bb5
        public static readonly Color Secondary = Color.FromArgb(100, 116, 139);    // #64748b Slate
        public static readonly Color DarkSidebar = Color.FromArgb(15, 23, 42);     // #0f172a
        public static readonly Color DarkSidebarHover = Color.FromArgb(30, 41, 59);// #1e293b
        public static readonly Color DarkSidebarActive = Color.FromArgb(0, 70, 148);
        public static readonly Color Background = Color.FromArgb(240, 244, 248);   // #f0f4f8 Fondo suave de Frontend.MVC
        public static readonly Color CardBackground = Color.White;
        public static readonly Color TextPrimary = Color.FromArgb(30, 41, 59);      // #1e293b
        public static readonly Color TextSecondary = Color.FromArgb(100, 116, 139);// #64748b
        public static readonly Color BorderColor = Color.FromArgb(203, 213, 225);  // #cbd5e1
        public static readonly Color Success = Color.FromArgb(21, 128, 61);        // #15803d Verde Éxito
        public static readonly Color SuccessLight = Color.FromArgb(212, 237, 218); // #d4edda
        public static readonly Color Danger = Color.FromArgb(185, 28, 28);         // #b91c1c Rojo Alerta
        public static readonly Color DangerLight = Color.FromArgb(248, 215, 218);  // #f8d7da
        public static readonly Color Warning = Color.FromArgb(180, 83, 9);         // #b45309 Ámbar
        public static readonly Color WarningLight = Color.FromArgb(254, 243, 199); // #fef3c7

       
        public static readonly Font LargeTitleFont = new("Segoe UI", 15F, FontStyle.Bold);
        public static readonly Font HeaderFont = new("Segoe UI", 12.5F, FontStyle.Bold);
        public static readonly Font SubheaderFont = new("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font RegularFont = new("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Font RegularBold = new("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font SmallFont = new("Segoe UI", 8.5F, FontStyle.Regular);
        public static readonly Font SmallBold = new("Segoe UI", 8.5F, FontStyle.Bold);

        public static void StylePrimaryButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Primary;
            btn.ForeColor = Color.White;
            btn.Font = RegularBold;
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(12, 0, 12, 0);
        }

        public static void StyleSecondaryButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = BorderColor;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = Color.White;
            btn.ForeColor = TextPrimary;
            btn.Font = RegularFont;
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(10, 0, 10, 0);
        }

        public static void StyleDangerButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Danger;
            btn.ForeColor = Color.White;
            btn.Font = RegularBold;
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(12, 0, 12, 0);
        }

        public static void StyleSuccessButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Success;
            btn.ForeColor = Color.White;
            btn.Font = RegularBold;
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(12, 0, 12, 0);
        }

        public static void StyleDataGridView(DataGridView grid)
        {
            grid.AutoGenerateColumns = false; // CRÍTICO: Previene columnas duplicadas
            grid.BackgroundColor = CardBackground;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(235, 240, 245);
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = RegularBold;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 10, 12, 10);
            grid.ColumnHeadersHeight = 42;

            grid.DefaultCellStyle.BackColor = CardBackground;
            grid.DefaultCellStyle.ForeColor = TextPrimary;
            grid.DefaultCellStyle.Font = RegularFont;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 236, 248);
            grid.DefaultCellStyle.SelectionForeColor = PrimaryDark;
            grid.DefaultCellStyle.Padding = new Padding(10, 4, 10, 4);
            grid.RowTemplate.Height = 40;

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static Panel CreateStatCard(string title, string value, string subtitle, Color accentColor, int width = 220, int height = 85)
        {
            var card = new Panel
            {
                Size = new Size(width, height),
                BackColor = CardBackground,
                Padding = new Padding(15, 10, 15, 10),
                Margin = new Padding(0, 0, 15, 0)
            };

            card.Paint += (s, e) =>
            {
                using var pen = new Pen(BorderColor, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                using var barBrush = new SolidBrush(accentColor);
                e.Graphics.FillRectangle(barBrush, 0, 0, 4, card.Height);
            };

            var lblT = new Label
            {
                Text = title.ToUpper(),
                Font = SmallBold,
                ForeColor = TextSecondary,
                Location = new Point(12, 10),
                AutoSize = true
            };

            var lblV = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 14.5F, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(10, 28),
                AutoSize = true
            };

            var lblS = new Label
            {
                Text = subtitle,
                Font = SmallFont,
                ForeColor = TextSecondary,
                Location = new Point(12, 58),
                AutoSize = true
            };

            card.Controls.Add(lblT);
            card.Controls.Add(lblV);
            card.Controls.Add(lblS);

            return card;
        }
    }
}
