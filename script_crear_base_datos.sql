-- =====================================================================
-- Trabajo Practico Integrador - Clinica Odontologica (TurnoMolar)
-- Script de Creacion de Base de Datos y Datos Iniciales
-- Motor: Microsoft SQL Server
-- =====================================================================

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ClinicaOdontologicaDb')
BEGIN
    CREATE DATABASE ClinicaOdontologicaDb;
END
GO

USE ClinicaOdontologicaDb;
GO

-- =====================================================================
-- 1. TABLAS PRINCIPALES
-- =====================================================================

IF OBJECT_ID('dbo.ItemsFactura', 'U') IS NOT NULL DROP TABLE dbo.ItemsFactura;
IF OBJECT_ID('dbo.Facturas', 'U') IS NOT NULL DROP TABLE dbo.Facturas;
IF OBJECT_ID('dbo.Multas', 'U') IS NOT NULL DROP TABLE dbo.Multas;
IF OBJECT_ID('dbo.HistoriasClinicas', 'U') IS NOT NULL DROP TABLE dbo.HistoriasClinicas;
IF OBJECT_ID('dbo.Consultas', 'U') IS NOT NULL DROP TABLE dbo.Consultas;
IF OBJECT_ID('dbo.Turnos', 'U') IS NOT NULL DROP TABLE dbo.Turnos;
IF OBJECT_ID('dbo.HorariosOdont', 'U') IS NOT NULL DROP TABLE dbo.HorariosOdont;
IF OBJECT_ID('dbo.Consultorios', 'U') IS NOT NULL DROP TABLE dbo.Consultorios;
IF OBJECT_ID('dbo.Insumos', 'U') IS NOT NULL DROP TABLE dbo.Insumos;
IF OBJECT_ID('dbo.Odontologos', 'U') IS NOT NULL DROP TABLE dbo.Odontologos;
IF OBJECT_ID('dbo.Especialidades', 'U') IS NOT NULL DROP TABLE dbo.Especialidades;
IF OBJECT_ID('dbo.Pacientes', 'U') IS NOT NULL DROP TABLE dbo.Pacientes;
IF OBJECT_ID('dbo.Usuarios', 'U') IS NOT NULL DROP TABLE dbo.Usuarios;
IF OBJECT_ID('dbo.ObrasSociales', 'U') IS NOT NULL DROP TABLE dbo.ObrasSociales;
GO

-- 1.1 Obras Sociales
CREATE TABLE dbo.ObrasSociales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    [Plan] NVARCHAR(100) NOT NULL,
    PorcentajeCobertura DECIMAL(5,2) NOT NULL DEFAULT 0.50
);

-- 1.2 Usuarios del Sistema
CREATE TABLE dbo.Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Rol NVARCHAR(30) NOT NULL,
    NombreCompleto NVARCHAR(150) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    EntidadId INT NULL
);

-- 1.3 Pacientes
CREATE TABLE dbo.Pacientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Dni INT NOT NULL UNIQUE,
    Telefono NVARCHAR(50) NULL,
    Mail NVARCHAR(150) NOT NULL,
    Domicilio NVARCHAR(200) NULL,
    EstadoHabilitado BIT NOT NULL DEFAULT 1,
    ObraSocialId INT NULL,
    NumeroAfiliado NVARCHAR(50) NULL,
    CONSTRAINT FK_Pacientes_ObrasSociales FOREIGN KEY (ObraSocialId) REFERENCES dbo.ObrasSociales(Id) ON DELETE SET NULL
);

-- 1.4 Especialidades
CREATE TABLE dbo.Especialidades (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(250) NULL
);

-- 1.5 Odontólogos
CREATE TABLE dbo.Odontologos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Dni INT NOT NULL UNIQUE,
    Telefono NVARCHAR(50) NULL,
    Mail NVARCHAR(150) NOT NULL,
    Domicilio NVARCHAR(200) NULL,
    Matricula NVARCHAR(50) NOT NULL,
    EspecialidadId INT NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Odontologos_Especialidades FOREIGN KEY (EspecialidadId) REFERENCES dbo.Especialidades(Id)
);

-- 1.6 Consultorios
CREATE TABLE dbo.Consultorios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(200) NULL
);

-- 1.7 Horarios de Atención
CREATE TABLE dbo.HorariosOdont (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OdontologoId INT NOT NULL,
    DiaSemana INT NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    CONSTRAINT FK_Horarios_Odontologos FOREIGN KEY (OdontologoId) REFERENCES dbo.Odontologos(Id) ON DELETE CASCADE
);

-- 1.8 Insumos Odontológicos
CREATE TABLE dbo.Insumos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    StockMinimo INT NOT NULL DEFAULT 5,
    PrecioUnitario DECIMAL(18,2) NOT NULL DEFAULT 0
);

-- 1.9 Turnos
CREATE TABLE dbo.Turnos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME2 NOT NULL,
    Hora TIME NOT NULL,
    EstadoTurno NVARCHAR(50) NOT NULL DEFAULT 'Pendiente',
    MotivoConsulta NVARCHAR(250) NULL,
    OdontologoId INT NOT NULL,
    PacienteId INT NOT NULL,
    ConsultorioId INT NOT NULL,
    MontoEstimado DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_Turnos_Odontologos FOREIGN KEY (OdontologoId) REFERENCES dbo.Odontologos(Id),
    CONSTRAINT FK_Turnos_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id),
    CONSTRAINT FK_Turnos_Consultorios FOREIGN KEY (ConsultorioId) REFERENCES dbo.Consultorios(Id)
);

-- 1.10 Consultas Médicas
CREATE TABLE dbo.Consultas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TurnoId INT NOT NULL,
    Diagnostico NVARCHAR(500) NOT NULL,
    TratamientoRealizado NVARCHAR(500) NOT NULL,
    Observaciones NVARCHAR(500) NULL,
    FechaAtencion DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Consultas_Turnos FOREIGN KEY (TurnoId) REFERENCES dbo.Turnos(Id)
);

-- 1.11 Historias Clínicas
CREATE TABLE dbo.HistoriasClinicas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PacienteId INT NOT NULL,
    NumeroFicha INT NOT NULL,
    NumeroAfiliado INT NULL,
    FechaAlta DATETIME2 NOT NULL DEFAULT GETDATE(),
    Alergias NVARCHAR(300) NULL,
    MedicacionActual NVARCHAR(300) NULL,
    AntecedentesMedicos NVARCHAR(500) NULL,
    CONSTRAINT FK_HistoriasClinicas_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id) ON DELETE CASCADE
);

-- 1.12 Multas por Inasistencia
CREATE TABLE dbo.Multas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PacienteId INT NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    EstadoPago BIT NOT NULL DEFAULT 0,
    FechaPago DATETIME2 NULL,
    Motivo NVARCHAR(250) NOT NULL,
    CONSTRAINT FK_Multas_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id) ON DELETE CASCADE
);

-- 1.13 Facturas
CREATE TABLE dbo.Facturas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TurnoId INT NULL,
    PacienteId INT NOT NULL,
    MontoTotal DECIMAL(18,2) NOT NULL,
    FechaEmision DATETIME2 NOT NULL DEFAULT GETDATE(),
    EstadoPago NVARCHAR(50) NOT NULL DEFAULT 'Pendiente',
    MetodoPago NVARCHAR(50) NULL,
    CONSTRAINT FK_Facturas_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id)
);

-- 1.14 Items de Factura
CREATE TABLE dbo.ItemsFactura (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FacturaId INT NOT NULL,
    Descripcion NVARCHAR(200) NOT NULL,
    Cantidad INT NOT NULL DEFAULT 1,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_ItemsFactura_Facturas FOREIGN KEY (FacturaId) REFERENCES dbo.Facturas(Id) ON DELETE CASCADE
);
GO

-- =====================================================================
-- 2. DATOS INICIALES (SEED DATA)
-- =====================================================================

SET IDENTITY_INSERT dbo.ObrasSociales ON;
INSERT INTO dbo.ObrasSociales (Id, Nombre, [Plan], PorcentajeCobertura) VALUES
(1, 'Particular', 'Sin Cobertura', 0.00),
(2, 'OSDE', 'Plan 210 / 310 / 410', 0.80),
(3, 'Swiss Medical', 'Plan SMG20', 0.75),
(4, 'IOMA', 'Afiliados Obligatorios', 0.50);
SET IDENTITY_INSERT dbo.ObrasSociales OFF;

SET IDENTITY_INSERT dbo.Especialidades ON;
INSERT INTO dbo.Especialidades (Id, Nombre, Descripcion) VALUES
(1, 'Odontologia General', 'Revisiones periodicas, limpiezas y operatoria basica'),
(2, 'Ortodoncia', 'Correccion de posicion dental y oclusion con brackets y alineadores'),
(3, 'Endodoncia', 'Tratamientos de conducto y patologias pulpares'),
(4, 'Cirugia Maxilofacial', 'Extracciones de terceros molares e implantes oseointegrados');
SET IDENTITY_INSERT dbo.Especialidades OFF;

SET IDENTITY_INSERT dbo.Consultorios ON;
INSERT INTO dbo.Consultorios (Id, Nombre, Descripcion) VALUES
(1, 'Consultorio 1 - General', 'Sillon odontologico principal con equipo radiografico'),
(2, 'Consultorio 2 - Ortodoncia', 'Equipado para ortodoncia y escaneo intraoral'),
(3, 'Consultorio 3 - Cirugia', 'Quirófano ambulatorio para cirugias menores');
SET IDENTITY_INSERT dbo.Consultorios OFF;

SET IDENTITY_INSERT dbo.Odontologos ON;
INSERT INTO dbo.Odontologos (Id, Nombre, Apellido, Dni, Telefono, Mail, Domicilio, Matricula, EspecialidadId, Activo) VALUES
(1, 'Martin', 'Gomez', 28123456, '341-4567890', 'dr.gomez@turnomolar.com', 'Bv. Oroño 1234, Rosario', 'MN-45892', 1, 1),
(2, 'Laura', 'Rossi', 30987654, '341-4567891', 'dra.rossi@turnomolar.com', 'Cordoba 1850, Rosario', 'MN-52341', 2, 1),
(3, 'Karina', 'Gonzalez', 32456789, '341-4567892', 'dra.gonzalez@turnomolar.com', 'Pellegrini 2200, Rosario', 'MN-61209', 3, 1);
SET IDENTITY_INSERT dbo.Odontologos OFF;

SET IDENTITY_INSERT dbo.Pacientes ON;
INSERT INTO dbo.Pacientes (Id, Nombre, Apellido, Dni, Telefono, Mail, Domicilio, EstadoHabilitado, ObraSocialId, NumeroAfiliado) VALUES
(1, 'Juan', 'Perez', 34567890, '341-5551234', 'juan.perez@email.com', 'Av. Pellegrini 1234, Rosario', 1, 2, 'OS-987456'),
(2, 'Manuel', 'Fernandez', 47073395, '341-2150442', 'manuto200@gmail.com', 'Corvalan 566, Rosario', 1, 1, '21124141'),
(3, 'Carlos', 'Lopez', 36789012, '341-5555678', 'carlos.lopez@email.com', 'Mitre 540, Rosario', 1, 3, 'SM-45211'),
(4, 'Ana', 'Martinez', 38901234, '341-5559012', 'ana.martinez@email.com', 'Santa Fe 2100, Rosario', 0, 4, 'IO-10293');
SET IDENTITY_INSERT dbo.Pacientes OFF;

SET IDENTITY_INSERT dbo.Usuarios ON;
INSERT INTO dbo.Usuarios (Id, Username, PasswordHash, Rol, NombreCompleto, Email, Activo, EntidadId) VALUES
(1, 'admin', 'admin123', 'Admin', 'Administrador Principal', 'admin@turnomolar.com', 1, NULL),
(2, 'doctor1', 'doc123', 'Odontologo', 'Dr. Martin Gomez', 'dr.gomez@turnomolar.com', 1, 1),
(3, 'doctor2', 'doc123', 'Odontologo', 'Dra. Laura Rossi', 'dra.rossi@turnomolar.com', 1, 2),
(4, 'karina', 'doc123', 'Odontologo', 'Dra. Karina Gonzalez', 'dra.gonzalez@turnomolar.com', 1, 3),
(5, 'paciente1', 'paciente123', 'Paciente', 'Juan Perez', 'juan.perez@email.com', 1, 1),
(6, 'manuel', 'paciente123', 'Paciente', 'Manuel Fernandez', 'manuto200@gmail.com', 1, 2),
(7, 'recepcion', 'recepcion123', 'Recepcionista', 'Maria Lopez', 'recepcion@turnomolar.com', 1, NULL);
SET IDENTITY_INSERT dbo.Usuarios OFF;

SET IDENTITY_INSERT dbo.Insumos ON;
INSERT INTO dbo.Insumos (Id, Nombre, Stock, StockMinimo, PrecioUnitario) VALUES
(1, 'Anestesia Tubos Cartucho', 150, 30, 850.00),
(2, 'Agujas Descartables Cortas', 200, 50, 150.00),
(3, 'Resina Compuesta Fotocurable', 45, 10, 12500.00),
(4, 'Guantes de Latex Caja x100', 80, 20, 4200.00),
(5, 'Baberos Descartables Rollo', 30, 10, 3100.00);
SET IDENTITY_INSERT dbo.Insumos OFF;

SET IDENTITY_INSERT dbo.Turnos ON;
INSERT INTO dbo.Turnos (Id, Fecha, Hora, EstadoTurno, MotivoConsulta, OdontologoId, PacienteId, ConsultorioId, MontoEstimado) VALUES
(1, '2026-09-02 09:00:00', '09:00:00', 'Atendido', 'Limpieza y control general', 1, 1, 1, 15000.00),
(2, '2026-09-02 10:30:00', '10:30:00', 'Presente', 'Ajuste de ortodoncia mensual', 2, 2, 2, 22000.00),
(3, '2026-09-03 14:00:00', '14:00:00', 'Pendiente', 'Evaluacion conducto molar', 3, 3, 1, 35000.00),
(4, '2026-09-04 16:00:00', '16:00:00', 'Pendiente', 'Revision periodica semestral', 1, 1, 1, 18000.00);
SET IDENTITY_INSERT dbo.Turnos OFF;

SET IDENTITY_INSERT dbo.Consultas ON;
INSERT INTO dbo.Consultas (Id, TurnoId, Diagnostico, TratamientoRealizado, Observaciones, FechaAtencion) VALUES
(1, 1, 'Gingivitis marginal leve en sector anterior', 'Detartraje supragingival con ultrasonido y profilaxis con pasta abrasiva', 'Buena respuesta del paciente. Se indica colutorio con clorhexidina 0.12% por 7 dias.', '2026-09-02 09:30:00');
SET IDENTITY_INSERT dbo.Consultas OFF;

SET IDENTITY_INSERT dbo.Facturas ON;
INSERT INTO dbo.Facturas (Id, TurnoId, PacienteId, MontoTotal, FechaEmision, EstadoPago, MetodoPago) VALUES
(1, 1, 1, 15000.00, '2026-09-02 09:45:00', 'Cobrada', 'Transferencia Bancaria'),
(2, 2, 2, 22000.00, '2026-09-02 10:50:00', 'Pendiente', NULL);
SET IDENTITY_INSERT dbo.Facturas OFF;

SET IDENTITY_INSERT dbo.ItemsFactura ON;
INSERT INTO dbo.ItemsFactura (Id, FacturaId, Descripcion, Cantidad, PrecioUnitario, Subtotal) VALUES
(1, 1, 'Consulta y Limpieza General', 1, 15000.00, 15000.00),
(2, 2, 'Sesion Mensual de Ortodoncia', 1, 22000.00, 22000.00);
SET IDENTITY_INSERT dbo.ItemsFactura OFF;

SET IDENTITY_INSERT dbo.Multas ON;
INSERT INTO dbo.Multas (Id, PacienteId, Monto, EstadoPago, FechaPago, Motivo) VALUES
(1, 4, 3500.00, 0, NULL, 'Ausencia no justificada a turno programado el 10/08/2026');
SET IDENTITY_INSERT dbo.Multas OFF;
GO
