using API.Auth.WindowsForms;
using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PacientePortalControl : UserControl
    {
        private readonly WindowsFormsAuthService _authService = null!;
        private readonly TurnoApiClient _turnoClient = new();
        private readonly PacienteApiClient _pacienteClient = new();
        private readonly ReportesApiClient _reportesClient = new();
        private readonly MultaApiClient _multaClient = new();

        private TurnoOdontologicoDTO? _proximoTurno;
        private int _pacienteId;
        private PacienteDTO? _pacienteInfo;
        private List<TurnoOdontologicoDTO> _misTurnos = new();
        private List<MultaDTO> _misMultas = new();

        public PacientePortalControl()
        {
            InitializeComponent();
            if (lstTarjetas.Items.Count > 0)
                lstTarjetas.SelectedIndex = 0;
        }

        public PacientePortalControl(WindowsFormsAuthService authService) : this()
        {
            _authService = authService;
            lblBienvenida.Text = $"¡Hola, {_authService.GetNombreCompleto() ?? "Paciente"}! Bienvenido a tu portal de salud dental.";
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnControlLoad;
            }
        }

        public void SeleccionarPestaña(int index)
        {
            if (index >= 0 && index < tabPortal.TabPages.Count)
            {
                tabPortal.SelectedIndex = index;
            }
        }

        private void PnlBorder_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Control box) return;
            using var pen = new Pen(UITheme.BorderColor, 1);
            e.Graphics.DrawRectangle(pen, 0, 0, box.Width - 1, box.Height - 1);
        }

        private void GridMisTurnos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridMisTurnos.Columns[e.ColumnIndex].Name == "Fecha" && e.RowIndex >= 0 && e.RowIndex < _misTurnos.Count)
            {
                e.Value = _misTurnos[e.RowIndex].Fecha.ToString("dd/MM/yyyy");
            }
        }

        private void GridMultas_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridMultas.Columns[e.ColumnIndex].Name == "Pagada" && e.RowIndex >= 0 && e.RowIndex < _misMultas.Count)
            {
                e.Value = _misMultas[e.RowIndex].EstadoPago ? "✅ Pagada" : "❌ Impaga";
                if (e.CellStyle != null)
                {
                    e.CellStyle.ForeColor = _misMultas[e.RowIndex].EstadoPago ? UITheme.Success : UITheme.Danger;
                    e.CellStyle.Font = UITheme.RegularBold;
                }
            }
        }

        private void BtnReservarTurno_Click(object? sender, EventArgs e)
        {
            AbrirReservaTurno();
        }

        private async void BtnRefrescarTurnos_Click(object? sender, EventArgs e)
        {
            await CargarDatos();
        }

        private void BtnAgregarTarjeta_Click(object? sender, EventArgs e)
        {
            AbrirModalNuevaTarjeta(lstTarjetas);
        }

        private void BtnEliminarTarjeta_Click(object? sender, EventArgs e)
        {
            if (lstTarjetas.SelectedIndex >= 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar este medio de pago?", "Clínica Odontológica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lstTarjetas.Items.RemoveAt(lstTarjetas.SelectedIndex);
                }
            }
        }

        private void AbrirModalNuevaTarjeta(ListBox lstTarjetas)
        {
            var formModal = new Form
            {
                Text = "Alta de Nuevo Medio de Pago - Clínica Odontológica",
                Size = new Size(460, 480),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.White,
                Font = UITheme.RegularFont
            };

            var pnlH = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = UITheme.Primary, Padding = new Padding(20, 15, 20, 10) };
            var lblT = new Label { Text = "💳 Registrar Tarjeta / Medio de Pago", ForeColor = Color.White, Font = UITheme.HeaderFont, AutoSize = true };
            pnlH.Controls.Add(lblT);

            int my = 20;
            int lx = 25;
            var pnlB = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 20, 25, 20) };

            void AddFormRow(string label, Control ctrl)
            {
                var l = new Label { Text = label, Location = new Point(lx, my), AutoSize = true, Font = UITheme.SmallBold, ForeColor = UITheme.TextPrimary };
                ctrl.Location = new Point(lx, my + 20);
                ctrl.Size = new Size(390, 28);
                pnlB.Controls.Add(l);
                pnlB.Controls.Add(ctrl);
                my += 55;
            }

            var cbTipo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cbTipo.Items.AddRange(new object[] { "Tarjeta de Débito", "Tarjeta de Crédito", "Billetera Virtual" });
            cbTipo.SelectedIndex = 0;
            AddFormRow("Tipo de Medio de Pago *:", cbTipo);

            var txtTitular = new TextBox { PlaceholderText = "Nombre como figura en el plástico" };
            AddFormRow("Titular de la Tarjeta *:", txtTitular);

            var txtNumero = new TextBox { PlaceholderText = "XXXX XXXX XXXX XXXX", MaxLength = 19 };
            AddFormRow("Número de Tarjeta (16 dígitos) *:", txtNumero);

            var pnlExpCvv = new Panel { Location = new Point(lx, my), Size = new Size(390, 50) };
            var lblExp = new Label { Text = "Vencimiento (MM/AA):", Location = new Point(0, 0), AutoSize = true, Font = UITheme.SmallBold };
            var txtExp = new TextBox { Location = new Point(0, 20), Width = 180, PlaceholderText = "12/28", MaxLength = 5 };
            var lblCvv = new Label { Text = "CVV (3 dígitos):", Location = new Point(200, 0), AutoSize = true, Font = UITheme.SmallBold };
            var txtCvv = new TextBox { Location = new Point(200, 20), Width = 180, PlaceholderText = "123", MaxLength = 4, UseSystemPasswordChar = true };

            pnlExpCvv.Controls.Add(lblExp);
            pnlExpCvv.Controls.Add(txtExp);
            pnlExpCvv.Controls.Add(lblCvv);
            pnlExpCvv.Controls.Add(txtCvv);
            pnlB.Controls.Add(pnlExpCvv);
            my += 55;

            var btnGuardar = new Button { Text = "💾 Guardar Medio de Pago", Location = new Point(lx, my + 10), Size = new Size(230, 40) };
            UITheme.StyleSuccessButton(btnGuardar);
            btnGuardar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTitular.Text) || string.IsNullOrWhiteSpace(txtNumero.Text) || txtNumero.Text.Trim().Length < 4)
                {
                    MessageBox.Show("Por favor complete los datos obligatorios de la tarjeta.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ultimos4 = txtNumero.Text.Trim().Length >= 4 ? txtNumero.Text.Trim().Substring(txtNumero.Text.Trim().Length - 4) : "0000";
                var nuevoItem = $"💳 {cbTipo.SelectedItem} **** {ultimos4} • {txtTitular.Text.Trim()}";
                lstTarjetas.Items.Add(nuevoItem);

                MessageBox.Show("¡Medio de pago agregado correctamente a tu cuenta!", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                formModal.Close();
            };

            var btnCerrar = new Button { Text = "Cancelar", Location = new Point(lx + 245, my + 10), Size = new Size(145, 40) };
            UITheme.StyleSecondaryButton(btnCerrar);
            btnCerrar.Click += (s, e) => formModal.Close();

            pnlB.Controls.Add(btnGuardar);
            pnlB.Controls.Add(btnCerrar);

            formModal.Controls.Add(pnlB);
            formModal.Controls.Add(pnlH);
            formModal.ShowDialog(FindForm());
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarDatos();
        }

        public async Task CargarDatos()
        {
            try
            {
                // El paciente se identifica por el EntidadId de su token, nunca por búsqueda en la lista
                var entidadId = _authService.GetEntidadId();
                if (entidadId == null)
                {
                    lblProxDoctor.Text = "Este usuario no tiene un paciente asociado.";
                    return;
                }

                _pacienteId = entidadId.Value;
                _pacienteInfo = await _pacienteClient.GetByIdAsync(_pacienteId);

                if (_pacienteInfo != null)
                {
                    lblOSNombre.Text = $"Obra Social: {_pacienteInfo.ObraSocialNombre}";
                    lblOSAfiliado.Text = $"N° de Afiliado / Credencial: {_pacienteInfo.NumeroAfiliado ?? "S/D"}";
                }

                // Cargar Turnos
                var allTurnos = await _turnoClient.GetByCriteriaAsync(new TurnoCriteriaDTO { PacienteId = _pacienteId });
                _misTurnos = allTurnos;
                gridMisTurnos.DataSource = null;
                gridMisTurnos.DataSource = _misTurnos;

                _proximoTurno = _misTurnos.Where(t => t.Fecha >= DateTime.Today && t.EstadoTurno != "Cancelado").OrderBy(t => t.Fecha).FirstOrDefault();

                if (_proximoTurno != null)
                {
                    lblProxDoctor.Text = $"Profesional: {_proximoTurno.OdontologoNombre}";
                    lblProxFecha.Text = $"Fecha y Hora: {_proximoTurno.Fecha:dd/MM/yyyy} a las {_proximoTurno.HorarioTurno} hs";
                    lblProxEspecialidad.Text = $"Especialidad: {_proximoTurno.EspecialidadNombre}";
                    lblProxEstado.Text = $"ESTADO: {_proximoTurno.EstadoTurno.ToUpper()}";
                    btnVerTicket.Visible = true;
                }
                else
                {
                    lblProxDoctor.Text = "No tienes turnos próximos agendados.";
                    lblProxFecha.Text = "Presiona el botón de abajo para solicitar una cita.";
                    lblProxEspecialidad.Text = "";
                    lblProxEstado.Text = "";
                    btnVerTicket.Visible = false;
                }

                // Cargar Historia Clínica
                var hc = await _reportesClient.GetHistoriaClinicaAsync(_pacienteId);
                if (hc != null)
                {
                    lblHCPaciente.Text = $"📋 Historia Clínica N° {hc.NumeroHistoriaClinica:D5} - {hc.PacienteNombre}\n" +
                                         $"• Antecedentes: {hc.AntecedentesMedicos} | Alergias: {hc.Alergias}";
                    gridHCPaciente.DataSource = hc.ConsultasPrevias;
                }

                // Cargar Multas / Deudas
                _misMultas = await _multaClient.GetAllAsync(_pacienteId);
                gridMultas.DataSource = null;
                gridMultas.DataSource = _misMultas;

                var impagas = _misMultas.Where(m => !m.EstadoPago).ToList();
                decimal deudaTotal = impagas.Sum(m => m.Monto);

                if (deudaTotal > 0)
                {
                    lblSaldoDeuda.Text = $"Saldo Deudor Pendiente: {deudaTotal:C2}";
                    lblEstadoHabilitacion.Text = "ESTADO: INHABILITADO PARA NUEVOS TURNOS (Registra multas impagas)";
                    lblEstadoHabilitacion.ForeColor = Color.FromArgb(248, 113, 113);
                    btnPagarDeuda.Visible = true;
                }
                else
                {
                    lblSaldoDeuda.Text = "Saldo Deudor Pendiente: $ 0,00 (Al día)";
                    lblEstadoHabilitacion.Text = "ESTADO: HABILITADO PARA RESERVAS";
                    lblEstadoHabilitacion.ForeColor = Color.FromArgb(52, 211, 153);
                    btnPagarDeuda.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(FindForm(), $"No se pudieron cargar tus datos: {ex.Message}", "Portal del Paciente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AbrirReservaTurno()
        {
            using var form = new TurnoReservaForm(_pacienteId);
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
            {
                _ = CargarDatos();
            }
        }

        private void BtnVerTicket_Click(object? sender, EventArgs e)
        {
            if (_proximoTurno == null) return;

            var formTicket = new Form
            {
                Text = "Comprobante de Turno - Clínica Odontológica",
                Size = new Size(480, 520),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.White
            };

            var pnlH = new Panel { Dock = DockStyle.Top, Height = 100, BackColor = UITheme.Primary, Padding = new Padding(20) };
            var lblT1 = new Label { Text = "🦷 Clínica Odontológica Rosario", ForeColor = Color.White, Font = UITheme.LargeTitleFont, Location = new Point(20, 15), AutoSize = true };
            var lblT2 = new Label { Text = "COMPROBANTE DE ATENCIÓN / TICKET DIGITAL", ForeColor = UITheme.PrimaryLight, Font = UITheme.SmallBold, Location = new Point(22, 55), AutoSize = true };
            pnlH.Controls.Add(lblT1);
            pnlH.Controls.Add(lblT2);

            var pnlBody = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25) };
            var lblCodigo = new Label { Text = $"CÓDIGO DE RESERVA: TM-{_proximoTurno.Id:D5}", Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = UITheme.Primary, Location = new Point(25, 15), AutoSize = true };

            int y = 50;
            void AddDetail(string label, string? val)
            {
                var l1 = new Label { Text = label, Location = new Point(25, y), Size = new Size(140, 20), Font = UITheme.SmallBold, ForeColor = UITheme.TextSecondary };
                var l2 = new Label { Text = val ?? "N/A", Location = new Point(170, y), Size = new Size(260, 20), Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
                pnlBody.Controls.Add(l1);
                pnlBody.Controls.Add(l2);
                y += 28;
            }

            AddDetail("PACIENTE:", _proximoTurno.PacienteNombre);
            AddDetail("PROFESIONAL:", _proximoTurno.OdontologoNombre);
            AddDetail("ESPECIALIDAD:", _proximoTurno.EspecialidadNombre);
            AddDetail("FECHA Y HORA:", $"{_proximoTurno.Fecha:dd/MM/yyyy} a las {_proximoTurno.HorarioTurno}");
            AddDetail("ESTADO:", "RESERVA CONFIRMADA (Citado)");

            var btnCerrar = new Button { Text = "Imprimir / Aceptar", Location = new Point(130, y + 20), Size = new Size(180, 38) };
            UITheme.StyleSuccessButton(btnCerrar);
            btnCerrar.Click += (s, e) => formTicket.Close();

            pnlBody.Controls.Add(lblCodigo);
            pnlBody.Controls.Add(btnCerrar);

            formTicket.Controls.Add(pnlBody);
            formTicket.Controls.Add(pnlH);
            formTicket.ShowDialog(FindForm());
        }

        private async void BtnCancelarTurno_Click(object? sender, EventArgs e)
        {
            if (gridMisTurnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un turno para cancelar.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var turno = (TurnoOdontologicoDTO)gridMisTurnos.SelectedRows[0].DataBoundItem;
            if (turno.EstadoTurno == "Cancelado" || turno.EstadoTurno == "Atendido")
            {
                MessageBox.Show($"No se puede cancelar un turno en estado {turno.EstadoTurno}.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Desea cancelar el turno para el {turno.Fecha:dd/MM/yyyy} a las {turno.HorarioTurno}?", "Cancelar Turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _turnoClient.CancelarAsync(turno.Id, "Cancelado por el paciente desde el portal");
                MessageBox.Show("Turno cancelado con éxito.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarDatos();
            }
        }

        private async void BtnPagarDeuda_Click(object? sender, EventArgs e)
        {
            var impaga = _misMultas.FirstOrDefault(m => !m.EstadoPago);
            if (impaga == null) return;

            if (MessageBox.Show($"¿Desea abonar la multa de {impaga.Monto:C2} con su tarjeta guardada para rehabilitar su cuenta?", "Pagar Deuda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _multaClient.PagarAsync(impaga.Id);
                MessageBox.Show("¡Pago procesado con éxito! Tu cuenta ha sido rehabilitada para agendar turnos.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarDatos();
            }
        }
    }
}
