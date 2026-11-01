using API.Clients;
using DTOs;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class InsumoDetalleForm : Form
    {
        private readonly InsumoApiClient _apiClient = new();
        private readonly InsumoDTO? _insumoExistente;

        public InsumoDetalleForm(InsumoDTO? insumo = null)
        {
            _insumoExistente = insumo;
            InitializeComponent();

            if (_insumoExistente != null)
            {
                this.Text = "Modificar Insumo";
                lblHeader.Text = "Editar Insumo";
                txtNombre.Text = _insumoExistente.Nombre;
                txtDescripcion.Text = _insumoExistente.Descripcion;
                txtPrecio.Text = _insumoExistente.Precio.ToString("F2");
                txtStock.Text = _insumoExistente.Stock.ToString();
            }
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblError.Text = "El nombre del insumo es obligatorio.";
                return;
            }

            if (!EntradaNumerica.TryParseImporte(txtPrecio.Text, out var precio) || precio < 0)
            {
                lblError.Text = "El precio debe ser un número válido mayor o igual a 0.";
                return;
            }

            if (!int.TryParse(txtStock.Text.Trim(), out var stock) || stock < 0)
            {
                lblError.Text = "El stock debe ser un número entero no negativo.";
                return;
            }

            try
            {
                var dto = new InsumoDTO
                {
                    Id = _insumoExistente?.Id ?? 0,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = precio,
                    Stock = stock
                };

                if (_insumoExistente == null)
                    await _apiClient.CreateAsync(dto);
                else
                    await _apiClient.UpdateAsync(dto);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
