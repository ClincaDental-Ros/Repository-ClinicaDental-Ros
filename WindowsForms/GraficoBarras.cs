using System.Drawing.Drawing2D;

namespace WindowsForms
{
    /// <summary>
    /// Gráfico de barras horizontales dibujado con GDI+ (sin librerías externas).
    /// Se usa en Reportes para resumir los datos que muestran las grillas.
    /// </summary>
    public class GraficoBarras : Panel
    {
        private readonly List<(string Etiqueta, decimal Valor, Color Color)> _barras = new();
        private string _formato = "N0";

        public string Titulo { get; set; } = "";

        public GraficoBarras()
        {
            DoubleBuffered = true;
            BackColor = UITheme.CardBackground;
            Padding = new Padding(15);
            ResizeRedraw = true;
        }

        public void SetDatos(IEnumerable<(string Etiqueta, decimal Valor, Color Color)> barras, string formato = "N0")
        {
            _barras.Clear();
            _barras.AddRange(barras);
            _formato = formato;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int x = Padding.Left;
            int y = Padding.Top;
            int ancho = ClientSize.Width - Padding.Horizontal;

            using (var brushTitulo = new SolidBrush(UITheme.Primary))
                g.DrawString(Titulo, UITheme.SubheaderFont, brushTitulo, x, y);
            y += 30;

            if (_barras.Count == 0)
            {
                using var brushVacio = new SolidBrush(UITheme.TextSecondary);
                g.DrawString("Sin datos para el período seleccionado.", UITheme.SmallFont, brushVacio, x, y);
                return;
            }

            const int anchoEtiqueta = 110;
            const int anchoValor = 90;
            int altoBarra = Math.Clamp((ClientSize.Height - y - Padding.Bottom) / _barras.Count - 10, 14, 34);
            int anchoMaxBarra = Math.Max(10, ancho - anchoEtiqueta - anchoValor);
            decimal maximo = Math.Max(_barras.Max(b => b.Valor), 1m);

            using var brushTexto = new SolidBrush(UITheme.TextPrimary);
            using var brushFondo = new SolidBrush(UITheme.Background);
            using var centrado = new StringFormat { LineAlignment = StringAlignment.Center };

            foreach (var (etiqueta, valor, color) in _barras)
            {
                var filaEtiqueta = new RectangleF(x, y, anchoEtiqueta - 8, altoBarra);
                g.DrawString(etiqueta, UITheme.SmallBold, brushTexto, filaEtiqueta, centrado);

                g.FillRectangle(brushFondo, x + anchoEtiqueta, y, anchoMaxBarra, altoBarra);
                int largo = (int)(anchoMaxBarra * (valor / maximo));
                if (largo > 0)
                {
                    using var brushBarra = new SolidBrush(color);
                    g.FillRectangle(brushBarra, x + anchoEtiqueta, y, largo, altoBarra);
                }

                var filaValor = new RectangleF(x + anchoEtiqueta + anchoMaxBarra + 8, y, anchoValor - 8, altoBarra);
                g.DrawString(valor.ToString(_formato), UITheme.SmallBold, brushTexto, filaValor, centrado);

                y += altoBarra + 10;
            }
        }
    }
}
