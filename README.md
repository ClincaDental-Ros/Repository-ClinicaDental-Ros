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

El proyecto se desarrolla bajo arquitectura MVC.

| Capa | Tecnología |
| :--- | :--- |
| **Backend** | C# sobre .NET |
| **ORM / Acceso a Datos** | Entity Framework |
| **Frontend** | Windows Forms |
| **Base de datos** | SQL Server Express 2022 |


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

Próximamente.

---

## Documentación

La especificación funcional completa y las minutas de reunión se encuentran en la carpeta de documentación del proyecto.
