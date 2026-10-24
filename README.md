# Turno Molar

Aplicación web de gestión integral y turnos para Clínica Odontológica
Trabajo Práctico — UTN FRRo, Ingeniería en Sistemas de Información

---

## Descripción

Turno Molar digitaliza la administración, la gestión de turnos y el seguimiento de historias clínicas de una clínica odontológica, reemplazando el registro manual en papel o planillas descentralizadas por una plataforma unificada. Permite organizar las agendas de los odontólogos, registrar atenciones y tratamientos, gestionar la información de los pacientes y optimizar la comunicación entre la recepción, los profesionales y los pacientes.

---

## Objetivo

Optimizar la gestión operativa y clínica del consultorio mediante:
- La asignación, reprogramación y cancelación centralizada de turnos.
- La organización de las agendas y horarios de disponibilidad de cada profesional.
- El registro digital estructurado de la historia clínica y los tratamientos realizados a cada paciente.
- La gestión de obras sociales, coberturas y aranceles de las prestaciones.
- La generación de reportes administrativos y de atenciones para la clínica.

---

## Roles de usuario

| Rol | Permisos principales |
| :--- | :--- |
| **Administración / Recepción** | Gestiona el registro de pacientes, agenda turnos, asigna horarios a profesionales, administra obras sociales/aranceles y visualiza reportes generales de la clínica. |
| **Odontólogo / Profesional** | Consulta su agenda diaria/semanal, registra la evolución en la historia clínica de los pacientes atendidos y detalla los tratamientos realizados. |
| **Paciente** | Consulta sus turnos asignados, solicita o cancela turnos disponibles y visualiza su historial básico de citas. |

---

## Funcionalidades principales

- **Gestión de usuarios y accesos:** Registro, autenticación y control de permisos diferenciados según el rol del usuario (JWT).
- **Gestión de turnos y agendas:** Asignación de citas considerando la especialidad, la disponibilidad horaria del odontólogo y los consultorios/sillones disponibles.
- **Historia clínica digital:** Registro unificado de antecedentes médicos, diagnósticos, evolución por consulta y detalle de prestaciones realizadas.
- **Administración de obras sociales y aranceles:** Catálogo de coberturas, planes médicos y registro de pagos o copagos de las prestaciones odontológicas.
- **Panel de control y reportes:** Visualización del flujo de pacientes, tasa de ausentismo a turnos, tratamientos más frecuentes y métricas administrativas de la clínica.

---

## Arquitectura y stack tecnológico

Solución `DentalClinic.sln` (.NET 8, C#) organizada en capas:

| Proyecto | Responsabilidad |
| :--- | :--- |
| `Domain.Model` | Entidades y reglas de negocio (validaciones, cálculo de facturas). |
| `Data` | `TurnoMolarDbContext` (Entity Framework Core 8 + SQL Server), repositorios y datos de prueba (seed). La búsqueda de pacientes por criterio usa ADO.NET. |
| `DTOs` | Objetos de transferencia entre la API y los clientes. |
| `Application.Services` | Servicios de aplicación (pacientes, turnos, consultas, facturación, reportes, autenticación JWT). |
| `WebAPI` | API REST (Minimal API) con autenticación JWT, autorización por rol y Swagger en desarrollo. |
| `API.Clients` | Clientes HTTP compartidos por las dos interfaces. |
| `API.Auth.WindowsForms` | Manejo de la sesión en la aplicación de escritorio. |
| `API.Auth.Blazor.Server` | Manejo de la sesión y de los permisos por rol en la aplicación web. |
| `WindowsForms` | Interfaz de escritorio (MDI) para el personal de la clínica y el portal del paciente. |
| `Blazor.Server` | Interfaz web (Blazor Server) con las mismas funcionalidades: `Pages/` (pantallas), `Shared/` (diseño y menú) y `Components/` (modales y componentes reutilizables). |
| `Application.Services.Tests` | Pruebas unitarias (xUnit) del dominio y de los servicios. |

Base de datos: SQL Server en la nube del equipo (MonsterASP, base `db65098`). Si la base está vacía, la API crea las tablas y los datos de prueba al iniciar (`EnsureCreated`).

---

## Modelo de dominio (resumen)

Entidades principales del sistema:
- **Usuario (superclase):** Administrador, Odontólogo, Recepcionista, Paciente.
- **Paciente:** Datos personales, contacto, antecedentes y cobertura médica.
- **Turno:** Registro de la cita médica (fecha, hora, estado: pendiente, confirmado, cancelado, atendido).
- **HistoriaClinica y Evolucion:** Registro cronológico de atenciones, diagnósticos y observaciones médicas.
- **Tratamiento / Prestación:** Catálogo de servicios odontológicos ofrecidos y sus aranceles.
- **ObraSocial y Plan:** Coberturas médicas asociadas a los pacientes.
- **DisponibilidadHoraria:** Días y franjas horarias de atención de cada odontólogo.

El modelo completo, con atributos y multiplicidades, se documenta por separado como parte del análisis de diseño del proyecto.

---

## Metodología de trabajo

El proyecto sigue un enfoque en cascada, con documentación formal versionada en cada etapa (minutas de reunión, especificación de requerimientos, modelo de dominio). Cada entregable queda registrado con su fecha, versión y autor para mantener trazabilidad de los cambios.

---

## Integrantes

| Nombre |
| :--- |
| Fernández González, Manuel |
| Oertlin Merini, María Victoria |
| Perroud, Juan Ignacio |

---

## Instalación y uso

Requisitos: .NET 8 SDK, Visual Studio 2022 (para la aplicación de escritorio) y acceso a un SQL Server.

### 1. Configurar la base de datos

La API usa la base en la nube. La cadena de conexión **no está en el repositorio** (tiene la contraseña), así que hay que configurarla una vez en cada PC con una de estas opciones:

```bash
# Opción A: user-secrets (queda fuera del repositorio)
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<cadena de conexión>" --project WebAPI

# Opción B: variable de entorno (PowerShell)
$env:ConnectionStrings__DefaultConnection = "<cadena de conexión>"
```

También se puede crear `WebAPI/appsettings.Development.json`, que está en `.gitignore`.

### 2. Ejecutar

1. **WebAPI** (debe iniciarse primero): `dotnet run --project WebAPI` → `http://localhost:5263` (Swagger en `/swagger`).
2. **Web (Blazor)**: `dotnet run --project Blazor.Server` → `http://localhost:5278`.
3. **Escritorio (WindowsForms)**: ejecutar el proyecto `WindowsForms` desde Visual Studio.

La URL de la API se configura en `ApiSettings:BaseUrl` de `Blazor.Server/appsettings.json` y de `WindowsForms/appsettings.json`.
En Visual Studio, elegí en la barra de herramientas el perfil de inicio **"API + Web + Escritorio"** (o "API + Web" / "API + Escritorio"), definido en `DentalClinic.slnLaunch`, para levantar la API junto con las interfaces. Si se inicia solo Blazor.Server o WindowsForms, el login muestra "Error de conexión" porque la API no está corriendo.

### 3. Usuarios de prueba

| Usuario | Clave | Rol |
| :--- | :--- | :--- |
| `admin` | `admin123` | Admin |
| `recepcion` | `recepcion123` | Recepcionista |
| `doctor1` / `doctor2` | `doc123` | Odontólogo |
| `paciente1` / `paciente2` | `paciente123` | Paciente |

Las claves se guardan con hash (HMAC-SHA256 con salt). Al dar de alta un paciente, su usuario del portal se crea con la clave inicial `paciente123`.

### 4. Pruebas

```bash
dotnet test Application.Services.Tests
```

---

## Documentación

La especificación funcional completa y las minutas de reunión se encuentran en la carpeta de documentación del proyecto.
