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
- El control de la agenda de cada profesional (un turno por horario y por odontólogo).
- El registro digital estructurado de la historia clínica y los tratamientos realizados a cada paciente.
- La facturación de las atenciones con el descuento de la obra social de cada paciente.
- La generación de reportes administrativos y de atenciones para la clínica.

---

## Roles de usuario

| Rol | Permisos principales |
| :--- | :--- |
| **Administrador** | Todo lo de recepción, más el ABM de odontólogos, especialidades e insumos y la baja de pacientes. |
| **Recepcionista** | Alta y edición de pacientes, reserva y reprogramación de turnos, admisión (presencia / ausencia), facturación, cobro de facturas y multas, y reportes. |
| **Odontólogo** | Consulta turnos y pacientes, confirma la presencia en sala de espera y registra la atención clínica (diagnóstico, tratamiento e insumos usados). |
| **Paciente** | Desde su portal: ve y reserva sus turnos, cancela los propios, consulta su historia clínica, facturas y multas, paga sus multas y valora las atenciones. |

---

## Funcionalidades principales

- **Usuarios y accesos:** inicio de sesión con JWT y permisos por rol. Al dar de alta un paciente se crea su usuario del portal.
- **Turnos:** la reserva valida que el paciente esté habilitado y sin multas impagas, que no tenga otro turno ese día, que el horario del odontólogo esté libre y que la fecha sea futura. Estados: Pendiente → Presente → Atendido, o Cancelado / NoAsistido. Registrar una ausencia genera una multa e inhabilita al paciente.
- **Atención clínica:** se registra la consulta (diagnóstico, tratamiento, observaciones, anestesia, radiografías), se descuenta el stock de los insumos usados y se genera la factura, todo en una misma transacción.
- **Facturación y cobro:** factura maestro/detalle (ítems de insumos) con descuento según el porcentaje de cobertura de la obra social; registro del pago y cobro de multas.
- **Historia clínica:** antecedentes, alergias, observaciones generales y las consultas previas del paciente.
- **Reportes:** turnos del día por estado, ausentismo por período (porcentaje y multas) y facturación por período (cobrado a pacientes y liquidado a obras sociales).

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

Entidades del proyecto `Domain.Model`:
- **Persona (clase abstracta):** nombre, apellido, DNI, teléfono, mail y domicilio. La heredan **Paciente** (habilitación, obra social y número de afiliado) y **Odontologo** (matrícula y especialidad).
- **Usuario:** credenciales del sistema (usuario, contraseña con hash y rol: Admin, Recepcionista, Odontologo o Paciente). No hereda de Persona: se vincula con su paciente u odontólogo mediante `EntidadId`.
- **Especialidad:** área de atención de cada odontólogo.
- **ObraSocial:** nombre, plan y porcentaje de cobertura.
- **TurnoOdontologico:** fecha, horario, paciente, odontólogo, especialidad, monto estimado y estado (Pendiente, Presente, Atendido, Cancelado, NoAsistido), con las reglas de transición entre estados.
- **Consulta:** la atención de un turno (diagnóstico, tratamiento, observaciones y la valoración del paciente).
- **HistoriaClinica:** antecedentes médicos, alergias y observaciones generales del paciente.
- **Factura e ItemFactura:** factura maestro/detalle con sus insumos y el cálculo de montos con descuento de obra social.
- **Insumo:** materiales con precio y stock.
- **Multa:** cargo por inasistencia; mientras esté impaga, el paciente no puede reservar turnos.
- **Consultorio y HorarioOdont:** están modeladas y tienen su tabla, pero la asignación de consultorios y la gestión de horarios de los odontólogos quedaron fuera del alcance acordado (no tienen servicio ni pantallas).

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

### 1. Configurar la base de datos y la clave JWT

La cadena de conexión y la clave para firmar los tokens JWT **no están en el repositorio**. Hay que configurarlas una vez en cada PC con una de estas opciones:

```bash
# Opción A: user-secrets (queda fuera del repositorio)
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<cadena de conexión>" --project WebAPI
dotnet user-secrets set "JwtSettings:SecretKey" "<clave aleatoria de al menos 32 caracteres>" --project WebAPI

# Opción B: variables de entorno (PowerShell)
$env:ConnectionStrings__DefaultConnection = "<cadena de conexión>"
$env:JwtSettings__SecretKey = "<clave aleatoria de al menos 32 caracteres>"
```

También se puede copiar `WebAPI/appsettings.Development.example.json` como `WebAPI/appsettings.Development.json` (está en `.gitignore`) y completar los valores.

Si falta la clave JWT, o si la API no puede conectarse ni crear la base, la API no arranca y muestra el motivo. Si la base está vacía, la API crea las tablas y los datos de prueba al iniciar (`EnsureCreated`); no hace falta ningún script SQL. Los datos de prueba incluyen turnos, consultas, facturas y multas de los últimos tres meses, para que los reportes por período muestren meses distintos.

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

El proyecto `Application.Services.Tests` (xUnit) forma parte de la solución:

```bash
dotnet test DentalClinic.sln
```

### 5. Generar el .zip del código

Para entregar el código sin `.git`, `.vs`, `bin`, `obj`, archivos `*.user` ni `appsettings.Development.json`, se genera desde git (solo incluye los archivos versionados):

```bash
git archive --format=zip -o TurnoMolar.zip HEAD
```

---

## Documentación

La especificación funcional completa y las minutas de reunión se encuentran en la carpeta de documentación del proyecto.
