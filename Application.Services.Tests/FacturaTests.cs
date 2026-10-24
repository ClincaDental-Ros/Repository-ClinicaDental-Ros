using Domain.Model;
using Xunit;

namespace Application.Services.Tests
{
    public class FacturaTests
    {
        private static Factura NuevaFactura(params ItemFactura[] items)
        {
            var factura = new Factura(0, null, 1, "Prueba", 0m, 0m, 0m, 0m);
            factura.SetItems(items.ToList());
            return factura;
        }

        [Fact]
        public void CalcularMontos_SumaHonorariosEItemsYAplicaCobertura()
        {
            // Mismos valores que la factura 1 del seed: 12000 de honorarios + 3300 de insumos, OSDE 70 %
            var factura = NuevaFactura(
                new ItemFactura(0, 0, 1, 1, 2500m),
                new ItemFactura(0, 0, 4, 2, 400m));

            factura.CalcularMontos(12000m, 0.70m);

            Assert.Equal(15300m, factura.Subtotal);
            Assert.Equal(15300m, factura.Total);
            Assert.Equal(10710m, factura.DescuentoObraSocial);
            Assert.Equal(4590m, factura.MontoAPagarPaciente);
        }

        [Fact]
        public void CalcularMontos_SinCobertura_ElPacientePagaTodo()
        {
            var factura = NuevaFactura(new ItemFactura(0, 0, 1, 3, 500m));

            factura.CalcularMontos(0m, 0m);

            Assert.Equal(1500m, factura.Total);
            Assert.Equal(0m, factura.DescuentoObraSocial);
            Assert.Equal(1500m, factura.MontoAPagarPaciente);
        }

        [Fact]
        public void CalcularMontos_HonorariosNegativos_LanzaArgumentException()
        {
            var factura = NuevaFactura();
            Assert.Throws<ArgumentException>(() => factura.CalcularMontos(-1m, 0m));
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(1.5)]
        public void CalcularMontos_CoberturaFueraDeRango_LanzaExcepcion(double cobertura)
        {
            var factura = NuevaFactura();
            Assert.Throws<ArgumentOutOfRangeException>(() => factura.CalcularMontos(1000m, (decimal)cobertura));
        }

        [Fact]
        public void ValidarEditable_FacturaPagada_LanzaInvalidOperation()
        {
            var factura = NuevaFactura();
            factura.SetEstadoPago(true);

            Assert.Throws<InvalidOperationException>(() => factura.ValidarEditable());
        }

        [Fact]
        public void ValidarEditable_FacturaPendiente_NoLanza()
        {
            var factura = NuevaFactura();
            factura.ValidarEditable();
        }

        [Fact]
        public void CalcularHonorarios_SinTurno_EsCero()
        {
            Assert.Equal(0m, FacturaService.CalcularHonorarios(null));
        }
    }
}
