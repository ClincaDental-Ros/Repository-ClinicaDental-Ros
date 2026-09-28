using Domain.Model;
using Xunit;

namespace Application.Services.Tests
{
    public class DomainEntityValidationTests
    {
        [Fact]
        public void Paciente_CrearConDatosValidos_InstanciaCorrectamente()
        {
            var paciente = new Paciente(1, "Juan", "Pérez", 35123456, "11-2345-6789", "juan.perez@gmail.com", "Belgrano 450", true);
            
            Assert.Equal("Juan", paciente.Nombre);
            Assert.Equal("Pérez", paciente.Apellido);
            Assert.Equal(35123456, paciente.Dni);
        }

        [Fact]
        public void Paciente_NombreVacio_LanzaArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Paciente(1, "", "Pérez", 35123456, "11-2345-6789", "juan.perez@gmail.com", "Belgrano 450")
            );
            Assert.Contains("nombre es obligatorio", ex.Message);
        }

        [Fact]
        public void Paciente_DniInvalido_LanzaArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Paciente(1, "Juan", "Pérez", 0, "11-2345-6789", "juan.perez@gmail.com", "Belgrano 450")
            );
            Assert.Contains("DNI debe ser un número entero mayor a cero", ex.Message);
        }

        [Fact]
        public void Odontologo_MatriculaInvalida_LanzaArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Odontologo(1, -5, "Martín", "Gómez", 28345678, "11-4567-8901", "mgomez@turnomolar.com", "Santa Fe 1234")
            );
            Assert.Contains("matrícula debe ser mayor a cero", ex.Message);
        }

        [Fact]
        public void Usuario_UsernameVacio_LanzaArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Usuario(1, "", "pass123", "Admin", "Admin User", "admin@test.com")
            );
            Assert.Contains("nombre de usuario es obligatorio", ex.Message);
        }

        [Fact]
        public void Consulta_DiagnosticoVacio_LanzaArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Consulta(1, 1, "", "Tratamiento", "Obs")
            );
            Assert.Contains("diagnóstico es obligatorio", ex.Message);
        }

        [Fact]
        public void Factura_SubtotalNegativo_LanzaArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Factura(1, 1, 1, "Factura", -100m, 0m, 100m, 100m)
            );
            Assert.Contains("subtotal no puede ser negativo", ex.Message);
        }

        [Fact]
        public void ObraSocial_PorcentajeInvalido_LanzaArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new ObraSocial(1, "OSDE", "Plan 210", 1.5m)
            );
        }

        [Fact]
        public void TurnoOdontologico_CanceladoSinMotivo_LanzaArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new TurnoOdontologico(1, DateTime.Now, new TimeOnly(10, 0), TurnoOdontologico.EstadoTurnoEnum.Cancelado, null, 1, 1, 1, 1000m)
            );
            Assert.Contains("motivo al cancelar", ex.Message);
        }
    }
}
