using Xunit;

namespace Application.Services.Tests
{
    public class PasswordHasherTests
    {
        [Fact]
        public void Hash_GeneraSaltDistintoEnCadaLlamada()
        {
            var h1 = PasswordHasher.Hash("clave123");
            var h2 = PasswordHasher.Hash("clave123");

            Assert.NotEqual(h1, h2);
            Assert.Contains(":", h1);
        }

        [Fact]
        public void Verify_ClaveCorrecta_DevuelveTrue()
        {
            var hash = PasswordHasher.Hash("clave123");
            Assert.True(PasswordHasher.Verify("clave123", hash));
        }

        [Fact]
        public void Verify_ClaveIncorrecta_DevuelveFalse()
        {
            var hash = PasswordHasher.Hash("clave123");
            Assert.False(PasswordHasher.Verify("otraClave", hash));
        }

        [Theory]
        [InlineData("")]
        [InlineData("textoPlano")]
        [InlineData("noesbase64:tampoco")]
        public void Verify_HashMalFormado_DevuelveFalse(string hashGuardado)
        {
            Assert.False(PasswordHasher.Verify("clave123", hashGuardado));
        }

        // Hashes cargados en el seed de TurnoMolarDbContext: deben validar las claves de prueba documentadas en el README.
        [Theory]
        [InlineData("admin123", "NPkpeBTo0wkB7eYFk4zbEw==:wVTuP29U7cxd5EwL3XjiD7yrS+cYH6ITXhRNQKz+9co=")]
        [InlineData("recepcion123", "V5CM2JRusBY1Znz61ZofcA==:w3oRRcVTZp8xsZ5MHAvSRSZqso/TIar5wdECOT0ipZg=")]
        [InlineData("doc123", "i+G4S+SVZsrbJ2V+LNZCXA==:8nPTqwt1p3/mryU4eWyeopK3eP1vZFIGUwFqbBnz/TI=")]
        [InlineData("doc123", "MrFW8TT/b9p3nggRcvNuKA==:AXCxyJQo+QI6XAhzErdOXHF+B3ivgkT3P+9WaDxLSEg=")]
        [InlineData("paciente123", "6NGdkrFvvvtVJXHGkxf/tg==:Q1ApExO/Ylk7A2dOMQFTNPlalbZyHv/LUt4fxtPuGFk=")]
        public void Verify_HashesDelSeed_CorrespondenALasClavesDePrueba(string clave, string hashSeed)
        {
            Assert.True(PasswordHasher.Verify(clave, hashSeed));
        }
    }
}
