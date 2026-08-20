-- ============================================================================
-- SCRIPT DE CREACIÓN Y POBLADO DE BASE DE DATOS
-- Sistema: Clínica Odontológica (Gestión Integral)
-- Motor: Microsoft SQL Server 2022 / SQL Server Express
-- Base de Datos: ClinicaOdontologicaDb (Esquema 100% compatible con EF Core)
-- ============================================================================

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'ClinicaOdontologicaDb')
BEGIN
    CREATE DATABASE ClinicaOdontologicaDb;
END
GO

USE ClinicaOdontologicaDb;
GO

-- 1. Eliminar tablas previas si existen
IF OBJECT_ID('dbo.ItemsFactura', 'U') IS NOT NULL DROP TABLE dbo.ItemsFactura;
IF OBJECT_ID('dbo.Facturas', 'U') IS NOT NULL DROP TABLE dbo.Facturas;
IF OBJECT_ID('dbo.Consultas', 'U') IS NOT NULL DROP TABLE dbo.Consultas;
IF OBJECT_ID('dbo.Turnos', 'U') IS NOT NULL DROP TABLE dbo.Turnos;
IF OBJECT_ID('dbo.HistoriasClinicas', 'U') IS NOT NULL DROP TABLE dbo.HistoriasClinicas;
IF OBJECT_ID('dbo.Multas', 'U') IS NOT NULL DROP TABLE dbo.Multas;
IF OBJECT_ID('dbo.Pacientes', 'U') IS NOT NULL DROP TABLE dbo.Pacientes;
IF OBJECT_ID('dbo.HorariosOdont', 'U') IS NOT NULL DROP TABLE dbo.HorariosOdont;
IF OBJECT_ID('dbo.Consultorios', 'U') IS NOT NULL DROP TABLE dbo.Consultorios;
IF OBJECT_ID('dbo.Odontologos', 'U') IS NOT NULL DROP TABLE dbo.Odontologos;
IF OBJECT_ID('dbo.Especialidades', 'U') IS NOT NULL DROP TABLE dbo.Especialidades;
IF OBJECT_ID('dbo.Insumos', 'U') IS NOT NULL DROP TABLE dbo.Insumos;
IF OBJECT_ID('dbo.ObrasSociales', 'U') IS NOT NULL DROP TABLE dbo.ObrasSociales;
IF OBJECT_ID('dbo.Usuarios', 'U') IS NOT NULL DROP TABLE dbo.Usuarios;
GO

-- 2. Creación de Tablas Principales

CREATE TABLE dbo.Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    Rol NVARCHAR(30) NOT NULL,
    NombreCompleto NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(MAX) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    EntidadId INT NULL
);
GO

CREATE TABLE dbo.ObrasSociales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(MAX) NOT NULL,
    Descripcion NVARCHAR(MAX) NOT NULL,
    PorcentajeCobertura DECIMAL(5,2) NOT NULL DEFAULT 0.00
);
GO

CREATE TABLE dbo.Especialidades (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(MAX) NOT NULL,
    Descripcion NVARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE dbo.Odontologos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NumMatricula INT NOT NULL,
    EspecialidadId INT NOT NULL,
    Nombre NVARCHAR(MAX) NOT NULL,
    Apellido NVARCHAR(MAX) NOT NULL,
    Dni INT NOT NULL,
    Telefono NVARCHAR(MAX) NOT NULL,
    Mail NVARCHAR(MAX) NOT NULL,
    Domicilio NVARCHAR(MAX) NOT NULL,
    CONSTRAINT FK_Odontologos_Especialidades FOREIGN KEY (EspecialidadId) 
        REFERENCES dbo.Especialidades(Id)
);
GO

CREATE TABLE dbo.Pacientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EstadoHabilitado BIT NOT NULL DEFAULT 1,
    ObraSocialId INT NULL,
    NumeroAfiliado NVARCHAR(MAX) NULL,
    Nombre NVARCHAR(MAX) NOT NULL,
    Apellido NVARCHAR(MAX) NOT NULL,
    Dni INT NOT NULL,
    Telefono NVARCHAR(MAX) NOT NULL,
    Mail NVARCHAR(MAX) NOT NULL,
    Domicilio NVARCHAR(MAX) NOT NULL,
    CONSTRAINT FK_Pacientes_ObrasSociales FOREIGN KEY (ObraSocialId) 
        REFERENCES dbo.ObrasSociales(Id) ON DELETE SET NULL
);
GO

CREATE TABLE dbo.Insumos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(MAX) NOT NULL,
    Descripcion NVARCHAR(MAX) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    Stock INT NOT NULL DEFAULT 0
);
GO

CREATE TABLE dbo.Turnos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME2 NOT NULL,
    HorarioTurno TIME NOT NULL,
    EstadoTurno INT NOT NULL DEFAULT 0,
    MotivoCancelacion NVARCHAR(MAX) NULL,
    PacienteId INT NOT NULL,
    OdontologoId INT NOT NULL,
    EspecialidadId INT NOT NULL,
    MontoEstimado DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_Turnos_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id),
    CONSTRAINT FK_Turnos_Odontologos FOREIGN KEY (OdontologoId) REFERENCES dbo.Odontologos(Id),
    CONSTRAINT FK_Turnos_Especialidades FOREIGN KEY (EspecialidadId) REFERENCES dbo.Especialidades(Id)
);
GO

CREATE TABLE dbo.Consultas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TurnoId INT NOT NULL,
    Observaciones NVARCHAR(MAX) NOT NULL,
    Diagnostico NVARCHAR(MAX) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,
    Tratamiento NVARCHAR(MAX) NOT NULL,
    AnestesiaLocal BIT NOT NULL DEFAULT 0,
    Radiografias BIT NOT NULL DEFAULT 0,
    Valoracion NVARCHAR(MAX) NULL,
    CalificacionEstrellas INT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Consultas_Turnos FOREIGN KEY (TurnoId) REFERENCES dbo.Turnos(Id)
);
GO

CREATE TABLE dbo.HistoriasClinicas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NumeroHistoriaClinica INT NOT NULL,
    PacienteId INT NOT NULL,
    FechaAlta DATETIME2 NOT NULL DEFAULT GETDATE(),
    AntecedentesMedicos NVARCHAR(MAX) NOT NULL,
    Alergias NVARCHAR(MAX) NOT NULL,
    ObservacionesGenerales NVARCHAR(MAX) NOT NULL,
    CONSTRAINT FK_HC_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id)
);
GO

CREATE TABLE dbo.Multas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PacienteId INT NOT NULL,
    Monto DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    EstadoPago BIT NOT NULL DEFAULT 0,
    FechaEmision DATETIME2 NOT NULL DEFAULT GETDATE(),
    FechaPago DATETIME2 NULL,
    Motivo NVARCHAR(MAX) NOT NULL,
    CONSTRAINT FK_Multas_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id)
);
GO

CREATE TABLE dbo.Facturas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TurnoId INT NULL,
    PacienteId INT NOT NULL,
    Descripcion NVARCHAR(MAX) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    DescuentoObraSocial DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    Total DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    MontoAPagarPaciente DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    EstadoPago BIT NOT NULL DEFAULT 0,
    MetodoPago NVARCHAR(MAX) NOT NULL,
    FechaEmision DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Facturas_Turnos FOREIGN KEY (TurnoId) REFERENCES dbo.Turnos(Id),
    CONSTRAINT FK_Facturas_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id)
);
GO

CREATE TABLE dbo.ItemsFactura (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FacturaId INT NOT NULL,
    InsumoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    Subtotal DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_ItemsFactura_Facturas FOREIGN KEY (FacturaId) REFERENCES dbo.Facturas(Id) ON DELETE CASCADE,
    CONSTRAINT FK_ItemsFactura_Insumos FOREIGN KEY (InsumoId) REFERENCES dbo.Insumos(Id)
);
GO

CREATE TABLE dbo.Consultorios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(MAX) NOT NULL,
    Piso INT NOT NULL DEFAULT 1,
    Activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE dbo.HorariosOdont (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OdontologoId INT NOT NULL,
    DiaSemana INT NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    ConsultorioId INT NULL,
    CONSTRAINT FK_HorariosOdont_Odontologos FOREIGN KEY (OdontologoId) REFERENCES dbo.Odontologos(Id)
);
GO

-- 3. POBLADO DE DATOS SEMILLA (SEED DATA)

SET IDENTITY_INSERT dbo.ObrasSociales ON;
INSERT INTO dbo.ObrasSociales (Id, Nombre, Descripcion, PorcentajeCobertura) VALUES
(1, N'OSDE', N'Plan 210 / 310 / 410', 0.70),
(2, N'Swiss Medical', N'Black / Gold / Classic', 0.65),
(3, N'IOMA', N'Afiliados Obligatorios', 0.50),
(4, N'Particular', N'Sin cobertura (100% particular)', 0.00);
SET IDENTITY_INSERT dbo.ObrasSociales OFF;
GO

SET IDENTITY_INSERT dbo.Especialidades ON;
INSERT INTO dbo.Especialidades (Id, Nombre, Descripcion) VALUES
(1, N'Odontología General', N'Atención primaria, limpiezas y controles preventivos'),
(2, N'Endodoncia', N'Tratamiento de conducto y pulpa dental'),
(3, N'Ortodoncia', N'Alineación de piezas dentales y brackets'),
(4, N'Cirugía e Implantes', N'Extracciones complejas y colocación de implantes'),
(5, N'Odontopediatría', N'Atención odontológica integral infantil');
SET IDENTITY_INSERT dbo.Especialidades OFF;
GO

SET IDENTITY_INSERT dbo.Odontologos ON;
INSERT INTO dbo.Odontologos (Id, NumMatricula, EspecialidadId, Nombre, Apellido, Dni, Telefono, Mail, Domicilio) VALUES
(1, 10234, 1, N'Martín', N'Gómez', 28345678, N'11-4567-8901', N'mgomez@turnomolar.com', N'Av. Santa Fe 1234, CABA'),
(2, 10456, 2, N'Laura', N'Rossi', 31456789, N'11-5678-9012', N'lrossi@turnomolar.com', N'Corrientes 2450, CABA'),
(3, 10789, 3, N'Esteban', N'Díaz', 29876543, N'11-6789-0123', N'ediaz@turnomolar.com', N'Callao 890, CABA');
SET IDENTITY_INSERT dbo.Odontologos OFF;
GO

SET IDENTITY_INSERT dbo.Pacientes ON;
INSERT INTO dbo.Pacientes (Id, Nombre, Apellido, Dni, Telefono, Mail, Domicilio, EstadoHabilitado, ObraSocialId, NumeroAfiliado) VALUES
(1, N'Juan', N'Pérez', 35123456, N'11-2345-6789', N'juan.perez@gmail.com', N'Belgrano 450, Quilmes', 1, 1, N'OSDE-987654'),
(2, N'Ana', N'Martínez', 38765432, N'11-3456-7890', N'ana.martinez@hotmail.com', N'Mitre 780, Avellaneda', 1, 2, N'SM-543210'),
(3, N'Carlos', N'Sánchez', 27987654, N'11-4567-8901', N'csanchez@yahoo.com', N'Rivadavia 1200, Lanús', 1, 4, NULL),
(4, N'Sofía', N'Rodríguez', 40123987, N'11-5678-1234', N'sofia.rodriguez@gmail.com', N'San Martín 320, Bernal', 0, 3, N'IOMA-334455');
SET IDENTITY_INSERT dbo.Pacientes OFF;
GO

SET IDENTITY_INSERT dbo.Usuarios ON;
INSERT INTO dbo.Usuarios (Id, Username, PasswordHash, Rol, NombreCompleto, Email, Activo, EntidadId) VALUES
(1, N'admin', N'admin123', N'Admin', N'Administrador Principal', N'admin@turnomolar.com', 1, NULL),
(2, N'recepcion', N'recepcion123', N'Recepcionista', N'María López', N'recepcion@turnomolar.com', 1, NULL),
(3, N'doctor1', N'doc123', N'Odontologo', N'Dr. Martín Gómez', N'mgomez@turnomolar.com', 1, 1),
(4, N'doctor2', N'doc123', N'Odontologo', N'Dra. Laura Rossi', N'lrossi@turnomolar.com', 1, 2),
(5, N'paciente1', N'paciente123', N'Paciente', N'Juan Pérez', N'juan.perez@gmail.com', 1, 1);
SET IDENTITY_INSERT dbo.Usuarios OFF;
GO

SET IDENTITY_INSERT dbo.Insumos ON;
INSERT INTO dbo.Insumos (Id, Nombre, Descripcion, Precio, Stock) VALUES
(1, N'Kit de Anestesia Local (Mepivacaína)', N'Anestesia cartucho dental x 1.8ml', 2500.00, 120),
(2, N'Resina Compuesta Fotocurable', N'Material de restauración estética', 6800.00, 45),
(3, N'Película Radiográfica Periapical', N'Radiografía periapical digitalizada', 1500.00, 200),
(4, N'Guantes de Látex Descartables (Par)', N'Bioseguridad descartable', 400.00, 500),
(5, N'Babero y Eyetor Descartable', N'Kit de aislamiento para paciente', 300.00, 350),
(6, N'Pasta para Profilaxis Dental', N'Pasta abrasiva para limpieza profunda', 1200.00, 60),
(7, N'Conos de Gutapercha Endodoncia', N'Obturación de conductos radiculares', 4500.00, 30);
SET IDENTITY_INSERT dbo.Insumos OFF;
GO

SET IDENTITY_INSERT dbo.Multas ON;
INSERT INTO dbo.Multas (Id, PacienteId, Monto, EstadoPago, FechaPago, Motivo) VALUES
(1, 4, 3500.00, 0, NULL, N'Ausencia no justificada a turno programado el 10/08/2026');
SET IDENTITY_INSERT dbo.Multas OFF;
GO

SET IDENTITY_INSERT dbo.HistoriasClinicas ON;
INSERT INTO dbo.HistoriasClinicas (Id, NumeroHistoriaClinica, PacienteId, FechaAlta, AntecedentesMedicos, Alergias, ObservacionesGenerales) VALUES
(1, 1001, 1, '2025-01-15', N'Hipertensión leve controlada', N'Penicilina', N'Paciente con buena salud bucal previa'),
(2, 1002, 2, '2025-03-20', N'Ninguno', N'Ninguna', N'Tratamiento de ortodoncia en curso'),
(3, 1003, 3, '2025-05-10', N'Diabetes Tipo 2', N'Aspirina', N'Higiene regular'),
(4, 1004, 4, '2025-06-01', N'Ninguno', N'Ninguna', N'Inhabilitado por inasistencia sin aviso');
SET IDENTITY_INSERT dbo.HistoriasClinicas OFF;
GO

SET IDENTITY_INSERT dbo.Turnos ON;
INSERT INTO dbo.Turnos (Id, Fecha, HorarioTurno, EstadoTurno, MotivoCancelacion, PacienteId, OdontologoId, EspecialidadId, MontoEstimado) VALUES
(1, DATEADD(hour, 9, CAST(CAST(GETDATE() AS DATE) AS DATETIME2)), '09:00:00', 0, NULL, 1, 1, 1, 12000.00),
(2, DATEADD(hour, 10, CAST(CAST(GETDATE() AS DATE) AS DATETIME2)), '10:00:00', 2, NULL, 2, 2, 2, 25000.00),
(3, DATEADD(hour, 11, CAST(CAST(GETDATE() AS DATE) AS DATETIME2)), '11:00:00', 3, NULL, 3, 1, 1, 15000.00),
(4, DATEADD(day, 1, DATEADD(hour, 14, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), '14:00:00', 0, NULL, 1, 3, 3, 18000.00);
SET IDENTITY_INSERT dbo.Turnos OFF;
GO

PRINT '🎉 Base de datos [ClinicaOdontologicaDb] recreada con esquema 100% compatible con EF Core.';
GO
