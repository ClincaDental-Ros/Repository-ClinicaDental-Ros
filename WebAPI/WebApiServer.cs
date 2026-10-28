using System.Text;
using Application.Services;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace WebAPI
{
    public static class WebApiServer
    {
        public static WebApplication CreateApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // La cadena de conexión (base en la nube) no se versiona: se toma de
            // appsettings.Development.json, user-secrets o la variable ConnectionStrings__DefaultConnection.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException(
                    "Falta la cadena de conexión 'DefaultConnection'. Configurala en WebAPI/appsettings.Development.json, " +
                    "con dotnet user-secrets o con la variable de entorno ConnectionStrings__DefaultConnection (ver README).");

            builder.Services.AddDbContext<TurnoMolarDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null);
                });
            });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // ─── JWT Authentication ───────────────────────────────────────
            // La clave de firma tampoco se versiona: igual que la cadena de conexión, se toma de
            // appsettings.Development.json, user-secrets o la variable JwtSettings__SecretKey. Sin clave, la API no arranca.
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            if (string.IsNullOrWhiteSpace(secretKey) || Encoding.UTF8.GetByteCount(secretKey) < 32)
                throw new InvalidOperationException(
                    "Falta la clave JWT 'JwtSettings:SecretKey' (mínimo 32 caracteres). Configurala en WebAPI/appsettings.Development.json, " +
                    "con dotnet user-secrets o con la variable de entorno JwtSettings__SecretKey (ver README).");
            var issuer = jwtSettings["Issuer"] ?? "TurnoMolarAPI";
            var audience = jwtSettings["Audience"] ?? "TurnoMolarClients";

            var key = Encoding.UTF8.GetBytes(secretKey);
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ClockSkew = TimeSpan.Zero
                };
            });

            // ─── Authorization Policies por Rol ──────────────────────────
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireRole("Admin"));

                options.AddPolicy("AdminOrRecepcionista", policy =>
                    policy.RequireRole("Admin", "Recepcionista"));

                options.AddPolicy("AdminOrOdontologo", policy =>
                    policy.RequireRole("Admin", "Odontologo"));

                options.AddPolicy("StaffOnly", policy =>
                    policy.RequireRole("Admin", "Recepcionista", "Odontologo"));

                options.AddPolicy("Authenticated", policy =>
                    policy.RequireAuthenticatedUser());
            });


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TurnoMolar API",
                    Version = "v1",
                    Description = "API REST de Gestión Odontológica y Turnos - Sistema TurnoMolar"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Ejemplo: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });


            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
            builder.Services.AddScoped<IOdontologoRepository, OdontologoRepository>();
            builder.Services.AddScoped<IEspecialidadRepository, EspecialidadRepository>();
            builder.Services.AddScoped<IInsumoRepository, InsumoRepository>();
            builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();
            builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
            builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
            builder.Services.AddScoped<IMultaRepository, MultaRepository>();
            builder.Services.AddScoped<IObraSocialRepository, ObraSocialRepository>();
            builder.Services.AddScoped<IHistoriaClinicaRepository, HistoriaClinicaRepository>();
            builder.Services.AddScoped<ITransactionManager, TransactionManager>();


            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IPacienteService, PacienteService>();
            builder.Services.AddScoped<IOdontologoService, OdontologoService>();
            builder.Services.AddScoped<IEspecialidadService, EspecialidadService>();
            builder.Services.AddScoped<IInsumoService, InsumoService>();
            builder.Services.AddScoped<ITurnoOdontologicoService, TurnoOdontologicoService>();
            builder.Services.AddScoped<IConsultaService, ConsultaService>();
            builder.Services.AddScoped<IFacturaService, FacturaService>();
            builder.Services.AddScoped<IMultaService, MultaService>();
            builder.Services.AddScoped<IReportesService, ReportesService>();
            builder.Services.AddScoped<IObraSocialService, ObraSocialService>();

            builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
            builder.Services.AddProblemDetails();

            var app = builder.Build();

            app.UseExceptionHandler();

            // Si la base no se puede crear o no responde, la API no arranca: es mejor fallar acá
            // con un mensaje claro que recién en el primer login.
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TurnoMolarDbContext>();
                try
                {
                    var created = context.Database.EnsureCreated();
                    Console.WriteLine(created
                        ? "Base de datos creada y cargada con datos de prueba."
                        : "Conexión establecida con la base de datos existente.");
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        "No se pudo conectar ni crear la base de datos. Revisá la cadena 'DefaultConnection' y que el servidor SQL esté disponible.", ex);
                }
            }

            app.UseCors("AllowAll");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TurnoMolar API v1");
                    c.RoutePrefix = "swagger";
                });
                app.MapGet("/", () => Results.Redirect("/swagger"));
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapAuthEndpoints();
            app.MapPacienteEndpoints();
            app.MapOdontologoEndpoints();
            app.MapEspecialidadEndpoints();
            app.MapInsumoEndpoints();
            app.MapTurnoOdontologicoEndpoints();
            app.MapConsultaEndpoints();
            app.MapFacturaEndpoints();
            app.MapMultaEndpoints();
            app.MapReportesEndpoints();
            app.MapObraSocialEndpoints();

            return app;
        }
    }
}
