using Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Application.Services.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task TestLoginQuery()
        {
            var options = new DbContextOptionsBuilder<TurnoMolarDbContext>()
                .UseSqlServer("Server=localhost;Database=ClinicaOdontologicaDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;")
                .Options;

            using var context = new TurnoMolarDbContext(options);
            try
            {
                var user = await context.Usuarios.FirstOrDefaultAsync(u => u.Username.ToLower() == "admin");
                _output.WriteLine($"USER FOUND: {user?.Username}, Rol: {user?.Rol}");
                Assert.NotNull(user);
            }
            catch (Exception ex)
            {
                _output.WriteLine($"EXCEPTION TYPE: {ex.GetType().FullName}");
                _output.WriteLine($"EXCEPTION MESSAGE: {ex.Message}");
                _output.WriteLine($"STACK TRACE: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    _output.WriteLine($"INNER EXCEPTION: {ex.InnerException.Message}");
                }
                throw;
            }
        }
    }
}
