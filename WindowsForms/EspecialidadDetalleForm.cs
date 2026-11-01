using API.Clients;
using DTOs;
using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Alta y modificación de una especialidad. Los controles y sus propiedades están en
    /// EspecialidadDetalleForm.Designer.cs (se editan con el Diseñador de Windows Forms); acá queda solo la lógica.
    /// </summary>
    public partial class EspecialidadDetalleForm : Form
    {
        private readonly EspecialidadApiClient _apiClient = new();
        private readonly EspecialidadDTO? _especialidadExistente;

        // Sin especialidad = alta; con especialidad = modificación.
        // El Diseñador de Visual Studio usa este constructor sin argumentos (modo alta).
        public EspecialidadDetalleForm(EspecialidadDTO? especialidad = null)
        {
            _especialidadExistente = especialidad;
            InitializeComponent();

            if (_especialidadExistente != null)
            {
                this.Text = "Modificar Especialidad";
                lblHeader.Text = "Editar Especialidad";
                txtNombre.Text = _especialidadExistente.Nombre;
                txtDescripcion.Text = _especialidadExistente.Descripcion;
            }
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblError.Text = "El nombre de la especialidad es obligatorio.";
                return;
            }

            try
            {
                var dto = new EspecialidadDTO
                {
                    Id = _especialidadExistente?.Id ?? 0,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim()
                };

                if (_especialidadExistente == null)
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
