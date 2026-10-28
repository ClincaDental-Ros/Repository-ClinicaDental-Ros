using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TurnoMolarDbContext : DbContext
    {
        public TurnoMolarDbContext(DbContextOptions<TurnoMolarDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Paciente> Pacientes => Set<Paciente>();
        public DbSet<Odontologo> Odontologos => Set<Odontologo>();
        public DbSet<Especialidad> Especialidades => Set<Especialidad>();
        public DbSet<Insumo> Insumos => Set<Insumo>();
        public DbSet<TurnoOdontologico> Turnos => Set<TurnoOdontologico>();
        public DbSet<Consulta> Consultas => Set<Consulta>();
        public DbSet<Factura> Facturas => Set<Factura>();
        public DbSet<ItemFactura> ItemsFactura => Set<ItemFactura>();
        public DbSet<Multa> Multas => Set<Multa>();
        public DbSet<ObraSocial> ObrasSociales => Set<ObraSocial>();
        public DbSet<HistoriaClinica> HistoriasClinicas => Set<HistoriaClinica>();
        public DbSet<Consultorio> Consultorios => Set<Consultorio>();
        public DbSet<HorarioOdont> HorariosOdont => Set<HorarioOdont>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Rol).IsRequired().HasMaxLength(30);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.ObraSocial)
                      .WithMany()
                      .HasForeignKey(e => e.ObraSocialId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Odontologo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Especialidad)
                      .WithMany()
                      .HasForeignKey(e => e.EspecialidadId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TurnoOdontologico>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Paciente)
                      .WithMany()
                      .HasForeignKey(e => e.PacienteId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Odontologo)
                      .WithMany()
                      .HasForeignKey(e => e.OdontologoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Especialidad)
                      .WithMany()
                      .HasForeignKey(e => e.EspecialidadId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.MontoEstimado).HasPrecision(18, 2);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Subtotal).HasPrecision(18, 2);
                entity.Property(e => e.DescuentoObraSocial).HasPrecision(18, 2);
                entity.Property(e => e.Total).HasPrecision(18, 2);
                entity.Property(e => e.MontoAPagarPaciente).HasPrecision(18, 2);
                entity.HasMany(e => e.Items)
                      .WithOne(e => e.Factura)
                      .HasForeignKey(e => e.FacturaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ItemFactura>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PrecioUnitario).HasPrecision(18, 2);
                entity.Property(e => e.Subtotal).HasPrecision(18, 2);
                entity.HasOne(e => e.Insumo)
                      .WithMany()
                      .HasForeignKey(e => e.InsumoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Insumo>(entity =>
            {
                entity.Property(e => e.Precio).HasPrecision(18, 2);
            });

            modelBuilder.Entity<Multa>(entity =>
            {
                entity.Property(e => e.Monto).HasPrecision(18, 2);
            });

            modelBuilder.Entity<ObraSocial>(entity =>
            {
                entity.Property(e => e.Plan).HasColumnName("Descripcion");
                entity.Property(e => e.PorcentajeCobertura).HasPrecision(5, 2);
            });

            SeedDatabase(modelBuilder);
        }

        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>().HasData(
                new Especialidad(1, "Odontología General", "Atención primaria, limpiezas y controles preventivos"),
                new Especialidad(2, "Endodoncia", "Tratamiento de conducto y pulpa dental"),
                new Especialidad(3, "Ortodoncia", "Alineación de piezas dentales y brackets"),
                new Especialidad(4, "Cirugía e Implantes", "Extracciones complejas y colocación de implantes"),
                new Especialidad(5, "Odontopediatría", "Atención odontológica integral infantil")
            );

            modelBuilder.Entity<ObraSocial>().HasData(
                new ObraSocial(1, "OSDE", "Plan 210 / 310", 0.70m),
                new ObraSocial(2, "Swiss Medical", "Black / Gold", 0.65m),
                new ObraSocial(3, "IOMA", "Afiliados Obligatorios", 0.50m),
                new ObraSocial(4, "Particular", "Sin cobertura (100% particular)", 0.00m)
            );

            modelBuilder.Entity<Insumo>().HasData(
                new Insumo(1, "Kit de Anestesia Local (Mepivacaína)", "Anestesia cartucho dental x 1.8ml", 2500m, 120),
                new Insumo(2, "Resina Compuesta Fotocurable", "Material de restauración estética", 6800m, 45),
                new Insumo(3, "Película Radiográfica Periapical", "Radiografía periapical digitalizada", 1500m, 200),
                new Insumo(4, "Guantes de Látex Descartables (Par)", "Bioseguridad descartable", 400m, 500),
                new Insumo(5, "Babero y Eyetor Descartable", "Kit de aislamiento para paciente", 300m, 350),
                new Insumo(6, "Pasta para Profilaxis Dental", "Pasta abrasiva para limpieza profunda", 1200m, 60),
                new Insumo(7, "Conos de Gutapercha Endodoncia", "Obturación de conductos radiculares", 4500m, 30)
            );

            // Contraseñas de prueba ya hasheadas (HMACSHA256 + salt, formato "salt:hash").
            // admin/admin123 · recepcion/recepcion123 · doctor1, doctor2/doc123 · paciente1, paciente2/paciente123
            const string hashPaciente = "6NGdkrFvvvtVJXHGkxf/tg==:Q1ApExO/Ylk7A2dOMQFTNPlalbZyHv/LUt4fxtPuGFk=";
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario(1, "admin", "NPkpeBTo0wkB7eYFk4zbEw==:wVTuP29U7cxd5EwL3XjiD7yrS+cYH6ITXhRNQKz+9co=", "Admin", "Administrador Principal", "admin@turnomolar.com", true),
                new Usuario(2, "recepcion", "V5CM2JRusBY1Znz61ZofcA==:w3oRRcVTZp8xsZ5MHAvSRSZqso/TIar5wdECOT0ipZg=", "Recepcionista", "María López", "recepcion@turnomolar.com", true),
                new Usuario(3, "doctor1", "i+G4S+SVZsrbJ2V+LNZCXA==:8nPTqwt1p3/mryU4eWyeopK3eP1vZFIGUwFqbBnz/TI=", "Odontologo", "Dr. Martín Gómez", "mgomez@turnomolar.com", true, 1),
                new Usuario(4, "doctor2", "MrFW8TT/b9p3nggRcvNuKA==:AXCxyJQo+QI6XAhzErdOXHF+B3ivgkT3P+9WaDxLSEg=", "Odontologo", "Dra. Laura Rossi", "lrossi@turnomolar.com", true, 2),
                new Usuario(5, "paciente1", hashPaciente, "Paciente", "Juan Pérez", "juan.perez@gmail.com", true, 1),
                new Usuario(6, "paciente2", hashPaciente, "Paciente", "Ana Martínez", "ana.martinez@hotmail.com", true, 2)
            );

            modelBuilder.Entity<Odontologo>().HasData(
                new Odontologo(1, 10234, "Martín", "Gómez", 28345678, "11-4567-8901", "mgomez@turnomolar.com", "Av. Santa Fe 1234, CABA", 1),
                new Odontologo(2, 10456, "Laura", "Rossi", 31456789, "11-5678-9012", "lrossi@turnomolar.com", "Corrientes 2450, CABA", 2),
                new Odontologo(3, 10789, "Esteban", "Díaz", 29876543, "11-6789-0123", "ediaz@turnomolar.com", "Callao 890, CABA", 3)
            );

            modelBuilder.Entity<Paciente>().HasData(
                new Paciente(1, "Juan", "Pérez", 35123456, "11-2345-6789", "juan.perez@gmail.com", "Belgrano 450, Quilmes", true, 1, "OSDE-987654"),
                new Paciente(2, "Ana", "Martínez", 38765432, "11-3456-7890", "ana.martinez@hotmail.com", "Mitre 780, Avellaneda", true, 2, "SM-543210"),
                new Paciente(3, "Carlos", "Sánchez", 27987654, "11-4567-8901", "csanchez@yahoo.com", "Rivadavia 1200, Lanús", true, 4, null),
                new Paciente(4, "Sofía", "Rodríguez", 40123987, "11-5678-1234", "sofia.rodriguez@gmail.com", "San Martín 320, Bernal", false, 3, "IOMA-334455"), // Inhabilitada por deuda/multa
                new Paciente(5, "Lucía", "Fernández", 42345678, "341-555-1020", "lucia.fernandez@gmail.com", "Córdoba 1550, Rosario", true, 4, null),
                new Paciente(6, "Martín", "Acosta", 33456123, "341-555-3344", "martin.acosta@outlook.com", "Pellegrini 980, Rosario", true, 1, "OSDE-112233")
            );

            var hoyMultas = DateTime.Today;
            modelBuilder.Entity<Multa>().HasData(
                ConMultaFecha(new Multa(1, 4, 3500m, false, null, "Inasistencia sin aviso a turno odontológico"), hoyMultas.AddDays(-3)),
                ConMultaFecha(new Multa(2, 5, 3500m, true, hoyMultas.AddDays(-10), "Inasistencia sin aviso a turno odontológico"), hoyMultas.AddDays(-12)),
                ConMultaFecha(new Multa(3, 3, 3500m, true, hoyMultas.AddDays(-55), "Inasistencia sin aviso a turno odontológico"), hoyMultas.AddDays(-62))
            );

            modelBuilder.Entity<HistoriaClinica>().HasData(
                new HistoriaClinica(1, 1001, 1, new DateTime(2025, 1, 15), "Hipertensión leve controlada", "Penicilina", "Paciente con buena salud bucal previa"),
                new HistoriaClinica(2, 1002, 2, new DateTime(2025, 3, 20), "Ninguno", "Ninguna", "Tratamiento de ortodoncia en curso"),
                new HistoriaClinica(3, 1003, 3, new DateTime(2025, 5, 10), "Diabetes Tipo 2", "Aspirina", "Higiene regular"),
                new HistoriaClinica(4, 1004, 4, new DateTime(2025, 6, 01), "Ninguno", "Ninguna", "Inhabilitado por inasistencia sin aviso"),
                new HistoriaClinica(5, 1005, 5, new DateTime(2025, 8, 12), "Ninguno", "Ibuprofeno", "Sensibilidad dental al frío"),
                new HistoriaClinica(6, 1006, 6, new DateTime(2025, 9, 3), "Asma leve", "Ninguna", "Control semestral")
            );

            var hoy = DateTime.Today;
            modelBuilder.Entity<TurnoOdontologico>().HasData(
                new TurnoOdontologico(1, hoy.AddHours(9), new TimeOnly(9, 0), TurnoOdontologico.EstadoTurnoEnum.Pendiente, null, 1, 1, 1, 12000m),
                new TurnoOdontologico(2, hoy.AddHours(10), new TimeOnly(10, 0), TurnoOdontologico.EstadoTurnoEnum.Presente, null, 2, 2, 2, 25000m),
                new TurnoOdontologico(3, hoy.AddHours(11), new TimeOnly(11, 0), TurnoOdontologico.EstadoTurnoEnum.Atendido, null, 3, 1, 1, 15000m),
                new TurnoOdontologico(4, hoy.AddDays(1).AddHours(14), new TimeOnly(14, 0), TurnoOdontologico.EstadoTurnoEnum.Pendiente, null, 1, 3, 3, 18000m),
                new TurnoOdontologico(5, hoy.AddDays(-7).AddHours(10), new TimeOnly(10, 0), TurnoOdontologico.EstadoTurnoEnum.Atendido, null, 1, 1, 1, 12000m),
                new TurnoOdontologico(6, hoy.AddDays(-5).AddHours(11), new TimeOnly(11, 0), TurnoOdontologico.EstadoTurnoEnum.Atendido, null, 2, 2, 2, 25000m),
                new TurnoOdontologico(7, hoy.AddDays(-3).AddHours(9).AddMinutes(30), new TimeOnly(9, 30), TurnoOdontologico.EstadoTurnoEnum.NoAsistido, "Ausencia registrada en recepción", 4, 1, 1, 12000m),
                new TurnoOdontologico(8, hoy.AddDays(-2).AddHours(15), new TimeOnly(15, 0), TurnoOdontologico.EstadoTurnoEnum.Cancelado, "Viaje laboral del paciente", 5, 3, 3, 18000m),
                new TurnoOdontologico(9, hoy.AddDays(-1).AddHours(16), new TimeOnly(16, 0), TurnoOdontologico.EstadoTurnoEnum.Atendido, null, 6, 3, 3, 18000m),
                new TurnoOdontologico(10, hoy.AddDays(2).AddHours(10).AddMinutes(30), new TimeOnly(10, 30), TurnoOdontologico.EstadoTurnoEnum.Pendiente, null, 2, 1, 1, 12000m),
                // Meses anteriores: para que los reportes por período muestren datos de distintos meses
                new TurnoOdontologico(11, hoy.AddDays(-95).AddHours(10), new TimeOnly(10, 0), TurnoOdontologico.EstadoTurnoEnum.Atendido, null, 2, 2, 2, 25000m),
                new TurnoOdontologico(12, hoy.AddDays(-80).AddHours(11), new TimeOnly(11, 0), TurnoOdontologico.EstadoTurnoEnum.Atendido, null, 6, 1, 1, 12000m),
                new TurnoOdontologico(13, hoy.AddDays(-62).AddHours(14), new TimeOnly(14, 0), TurnoOdontologico.EstadoTurnoEnum.NoAsistido, "Ausencia registrada en recepción", 3, 3, 3, 18000m),
                new TurnoOdontologico(14, hoy.AddDays(-48).AddHours(9), new TimeOnly(9, 0), TurnoOdontologico.EstadoTurnoEnum.Atendido, null, 5, 3, 3, 18000m),
                new TurnoOdontologico(15, hoy.AddDays(-33).AddHours(16), new TimeOnly(16, 0), TurnoOdontologico.EstadoTurnoEnum.Cancelado, "Reprogramado a pedido del paciente", 1, 1, 1, 12000m),
                new TurnoOdontologico(16, hoy.AddDays(-20).AddHours(10).AddMinutes(30), new TimeOnly(10, 30), TurnoOdontologico.EstadoTurnoEnum.Atendido, null, 1, 2, 2, 25000m)
            );

            modelBuilder.Entity<Consulta>().HasData(
                ConConsultaFecha(new Consulta(1, 5, "Caries superficial en pieza 36", "Restauración con resina", "Control en 6 meses", true, false, "Excelente atención", 5), hoy.AddDays(-7).AddHours(10)),
                ConConsultaFecha(new Consulta(2, 6, "Necrosis pulpar pieza 21", "Tratamiento de conducto", "Requiere corona posterior", true, true, "Muy profesional", 5), hoy.AddDays(-5).AddHours(11)),
                ConConsultaFecha(new Consulta(3, 3, "Pieza 46 con fractura parcial", "Reconstrucción con resina", "Evitar alimentos duros 48 h"), hoy.AddHours(11)),
                ConConsultaFecha(new Consulta(4, 9, "Apiñamiento dental leve", "Evaluación para ortodoncia", "Se solicitan radiografías", false, true, "Buena atención, algo de demora", 4), hoy.AddDays(-1).AddHours(16)),
                ConConsultaFecha(new Consulta(5, 11, "Pulpitis irreversible pieza 26", "Tratamiento de conducto", "Control en 15 días", true, true), hoy.AddDays(-95).AddHours(10)),
                ConConsultaFecha(new Consulta(6, 12, "Control semestral", "Limpieza y profilaxis", "Sin caries activas"), hoy.AddDays(-80).AddHours(11)),
                ConConsultaFecha(new Consulta(7, 14, "Diastema leve", "Restauración estética con resina", "Evaluar ortodoncia"), hoy.AddDays(-48).AddHours(9)),
                ConConsultaFecha(new Consulta(8, 16, "Caries profunda pieza 37", "Tratamiento de conducto", "Requiere corona", true, true), hoy.AddDays(-20).AddHours(10).AddMinutes(30))
            );

            modelBuilder.Entity<Factura>().HasData(
                ConFacturaFecha(new Factura(1, 5, 1, "Atención Odontológica - Restauración con resina", 15300m, 10710m, 15300m, 4590m, true, "Efectivo"), hoy.AddDays(-7).AddHours(10).AddMinutes(45)),
                ConFacturaFecha(new Factura(2, 6, 2, "Atención Odontológica - Tratamiento de conducto", 36500m, 23725m, 36500m, 12775m, true, "Tarjeta de Débito"), hoy.AddDays(-5).AddHours(12)),
                ConFacturaFecha(new Factura(3, 3, 3, "Atención Odontológica - Reconstrucción con resina", 21800m, 0m, 21800m, 21800m, false, "Pendiente de Pago"), hoy.AddHours(11).AddMinutes(40)),
                ConFacturaFecha(new Factura(4, 9, 6, "Atención Odontológica - Evaluación para ortodoncia", 21000m, 14700m, 21000m, 6300m, false, "Pendiente de Pago"), hoy.AddDays(-1).AddHours(16).AddMinutes(30)),
                // Honorarios del turno + insumos; descuento = cobertura de la obra social del paciente
                ConFacturaFecha(new Factura(5, 11, 2, "Atención Odontológica - Tratamiento de conducto", 32000m, 20800m, 32000m, 11200m, true, "Tarjeta de Crédito"), hoy.AddDays(-95).AddHours(11)),
                ConFacturaFecha(new Factura(6, 12, 6, "Atención Odontológica - Limpieza y profilaxis", 13200m, 9240m, 13200m, 3960m, true, "Efectivo"), hoy.AddDays(-80).AddHours(11).AddMinutes(30)),
                ConFacturaFecha(new Factura(7, 14, 5, "Atención Odontológica - Restauración estética con resina", 24800m, 0m, 24800m, 24800m, true, "Transferencia Bancaria / QR"), hoy.AddDays(-48).AddHours(9).AddMinutes(40)),
                ConFacturaFecha(new Factura(8, 16, 1, "Atención Odontológica - Tratamiento de conducto", 28000m, 19600m, 28000m, 8400m, true, "Tarjeta de Débito"), hoy.AddDays(-20).AddHours(11))
            );

            modelBuilder.Entity<ItemFactura>().HasData(
                new ItemFactura(1, 1, 1, 1, 2500m),
                new ItemFactura(2, 1, 4, 2, 400m),
                new ItemFactura(3, 2, 7, 2, 4500m),
                new ItemFactura(4, 2, 1, 1, 2500m),
                new ItemFactura(5, 3, 2, 1, 6800m),
                new ItemFactura(6, 4, 3, 2, 1500m),
                new ItemFactura(7, 5, 7, 1, 4500m),
                new ItemFactura(8, 5, 1, 1, 2500m),
                new ItemFactura(9, 6, 6, 1, 1200m),
                new ItemFactura(10, 7, 2, 1, 6800m),
                new ItemFactura(11, 8, 3, 2, 1500m)
            );
        }

        private static Consulta ConConsultaFecha(Consulta consulta, DateTime fecha)
        {
            consulta.SetFecha(fecha);
            return consulta;
        }

        private static Multa ConMultaFecha(Multa multa, DateTime fecha)
        {
            multa.SetFechaEmision(fecha);
            return multa;
        }

        private static Factura ConFacturaFecha(Factura factura, DateTime fecha)
        {
            factura.SetFechaEmision(fecha);
            return factura;
        }
    }
}
