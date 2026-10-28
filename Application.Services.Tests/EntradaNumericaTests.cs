using API.Clients;
using Xunit;

namespace Application.Services.Tests
{
    /// <summary>Los importes se leen igual sin importar la configuración regional de la PC.</summary>
    public class EntradaNumericaTests
    {
        [Theory]
        [InlineData("980.50", 980.50)]
        [InlineData("980,50", 980.50)]
        [InlineData("1.250,75", 1250.75)]
        [InlineData("1,250.75", 1250.75)]
        [InlineData("1.250", 1250)]
        [InlineData("$ 4500", 4500)]
        public void TryParseImporte_FormatosComunes_LeeElMismoValor(string texto, double esperado)
        {
            Assert.True(EntradaNumerica.TryParseImporte(texto, out var importe));
            Assert.Equal((decimal)esperado, importe);
        }

        [Theory]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData(null)]
        public void TryParseImporte_TextoInvalido_DevuelveFalse(string? texto)
        {
            Assert.False(EntradaNumerica.TryParseImporte(texto, out _));
        }
    }
}
