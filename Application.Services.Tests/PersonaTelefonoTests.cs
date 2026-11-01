using Domain.Model;
using Xunit;

namespace Application.Services.Tests
{
    public class PersonaTelefonoTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("+54 341 555-1234")]
        [InlineData("(0341) 4567890")]
        public void TelefonoValido_FormatosAceptados(string? telefono)
        {
            Assert.True(Persona.TelefonoValido(telefono));
        }

        [Theory]
        [InlineData("abc123")]
        [InlineData("12345")]
        [InlineData("341-555-12a4")]
        public void TelefonoValido_FormatosRechazados(string telefono)
        {
            Assert.False(Persona.TelefonoValido(telefono));
        }

        [Fact]
        public void Paciente_TelefonoInvalido_LanzaArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Paciente(1, "Juan", "Pérez", 35123456, "llamar a la tarde", "juan.perez@gmail.com", "Belgrano 450"));
        }
    }
}
