using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    /// <summary>
    /// Traduce las excepciones de validación del dominio y de los servicios a respuestas HTTP claras:
    /// ArgumentException / InvalidOperationException → 400 con el mensaje; conflictos de base → 409; el resto → 500 sin detalle interno.
    /// </summary>
    public class ValidationExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ValidationExceptionHandler> _logger;

        public ValidationExceptionHandler(ILogger<ValidationExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            int statusCode;
            string message;

            switch (exception)
            {
                case ArgumentException or InvalidOperationException:
                    statusCode = StatusCodes.Status400BadRequest;
                    message = exception.Message;
                    break;
                case DbUpdateException:
                    statusCode = StatusCodes.Status409Conflict;
                    message = "No se puede eliminar ni modificar el registro porque otros datos lo usan (por ejemplo turnos, facturas u odontólogos).";
                    break;
                case BadHttpRequestException:
                    statusCode = StatusCodes.Status400BadRequest;
                    message = "La solicitud tiene un formato inválido.";
                    break;
                default:
                    _logger.LogError(exception, "Error no controlado en {Path}", httpContext.Request.Path);
                    statusCode = StatusCodes.Status500InternalServerError;
                    message = "Ocurrió un error interno al procesar la solicitud.";
                    break;
            }

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(new { message }, cancellationToken);
            return true;
        }
    }
}
