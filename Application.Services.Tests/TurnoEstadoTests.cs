using Application.Services;
using Domain.Model;
using Xunit;
using Estado = Domain.Model.TurnoOdontologico.EstadoTurnoEnum;

namespace Application.Services.Tests
{
    /// <summary>Reglas de cambio de estado del turno, aplicadas en el servidor.</summary>
    public class TurnoEstadoTests
    {
        private static TurnoOdontologico Turno(Estado estado, string? motivo = null) =>
            new(1, DateTime.Today.AddDays(1), new TimeOnly(10, 0), estado, motivo, 1, 1, 1, 12000m);

        [Theory]
        [InlineData(Estado.Pendiente, Estado.Presente)]
        [InlineData(Estado.Pendiente, Estado.Cancelado)]
        [InlineData(Estado.Pendiente, Estado.NoAsistido)]
        [InlineData(Estado.Presente, Estado.Atendido)]
        [InlineData(Estado.Presente, Estado.Cancelado)]
        public void PuedeCambiar_TransicionValida_DevuelveTrue(Estado desde, Estado hacia)
        {
            Assert.True(TurnoOdontologico.PuedeCambiar(desde, hacia));
        }

        [Fact]
        public void ConfirmarPresencia_TurnoCancelado_LanzaInvalidOperation()
        {
            var turno = Turno(Estado.Cancelado, "Sin motivo");
            Assert.Throws<InvalidOperationException>(() => turno.ConfirmarPresencia());
        }

        [Fact]
        public void SetEstado_AtendidoOtraVez_NoCambiaNada()
        {
            var turno = Turno(Estado.Atendido);
            Assert.Throws<InvalidOperationException>(() => turno.RegistrarAusencia());
            Assert.Equal(Estado.Atendido, turno.EstadoTurno);
        }

        [Fact]
        public void Atender_TurnoPendienteSinPasarPorSala_LanzaInvalidOperation()
        {
            var turno = Turno(Estado.Pendiente);
            Assert.Throws<InvalidOperationException>(() => turno.Atender());
        }

        [Fact]
        public void SetEstado_EstadoInexistente_LanzaArgumentException()
        {
            var turno = Turno(Estado.Pendiente);
            Assert.Throws<ArgumentException>(() => turno.SetEstado((Estado)99));
        }

        [Fact]
        public void FlujoCompleto_PendientePresenteAtendido_Funciona()
        {
            var turno = Turno(Estado.Pendiente);
            turno.ConfirmarPresencia();
            turno.Atender();
            Assert.Equal(Estado.Atendido, turno.EstadoTurno);
        }

        [Fact]
        public void ValidarReprogramable_TurnoAtendido_LanzaInvalidOperation()
        {
            var turno = Turno(Estado.Atendido);
            Assert.Throws<InvalidOperationException>(() => turno.ValidarReprogramable());
        }

        [Theory]
        [InlineData("Pendiente", Estado.Pendiente)]
        [InlineData("cancelado", Estado.Cancelado)]
        [InlineData(" NoAsistido ", Estado.NoAsistido)]
        public void ParsearEstado_TextoValido_DevuelveEstado(string texto, Estado esperado)
        {
            Assert.Equal(esperado, TurnoOdontologicoService.ParsearEstado(texto));
        }

        [Theory]
        [InlineData("Inventado")]
        [InlineData("99")]
        [InlineData("2")]
        public void ParsearEstado_TextoInvalido_LanzaArgumentException(string texto)
        {
            Assert.Throws<ArgumentException>(() => TurnoOdontologicoService.ParsearEstado(texto));
        }
    }
}
