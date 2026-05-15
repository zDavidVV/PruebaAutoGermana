using Autogermana.Application.Interfaces;
using Autogermana.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Autogermana.Application.services
{
    public class ErrorService : IErrorService
    {
        private readonly ILogger<ErrorService> _logger;

        public ErrorService(ILogger<ErrorService> logger)
        {
            _logger = logger;
        }

        public ErrorResponse HandleError(Exception ex)
        {
            var exception = ex.GetBaseException();

            switch (exception)
            {
                case ArgumentNullException argNullEx:
                    _logger.LogError(argNullEx, "Se produjo un error de argumento nulo: {Message}", argNullEx.Message);
                    return (new ErrorResponse { statusCode = 400, message = $"Se produjo un error de argumento nulo: {argNullEx.Message}" });

                case InvalidOperationException invalidOpEx:
                    _logger.LogError(invalidOpEx, "Se produjo un error de operación no válida: {Message}", invalidOpEx.Message);
                    return (new ErrorResponse { statusCode = 400, message = $"Se produjo un error de operación no válida: {invalidOpEx.Message}" });

                case KeyNotFoundException keyNotFoundEx:
                    _logger.LogError(keyNotFoundEx, "Se produjo un error de clave no encontrada: {Message}", keyNotFoundEx.Message);
                    return (new ErrorResponse { statusCode = 404, message = $"Se produjo un error de clave no encontrada: {keyNotFoundEx.Message}" });

                case UnauthorizedAccessException unauthorizedEx:
                    _logger.LogError(unauthorizedEx, "Se produjo un error de acceso no autorizado: {Message}", unauthorizedEx.Message);
                    return (new ErrorResponse { statusCode = 401, message = $"Se produjo un error de acceso no autorizado: {unauthorizedEx.Message}" });

                case FormatException formatEx:
                    _logger.LogError(formatEx, "Se produjo un error de formato: {Message}", formatEx.Message);
                    return (new ErrorResponse { statusCode = 400, message = $"Se produjo un error de formato: {formatEx.Message}" });

                case TimeoutException timeoutEx:
                    _logger.LogError(timeoutEx, "Se produjo un error de tiempo de espera: {Message}", timeoutEx.Message);
                    return (new ErrorResponse { statusCode = 408, message = $"Se produjo un error de tiempo de espera: {timeoutEx.Message}" });

                case NotImplementedException notImplEx:
                    _logger.LogError(notImplEx, "Se produjo un error de funcionalidad no implementada: {Message}", notImplEx.Message);
                    return (new ErrorResponse { statusCode = 501, message = $"Se produjo un error de funcionalidad no implementada: {notImplEx.Message}" });

                case HttpRequestException httpRequestEx:
                    _logger.LogError(httpRequestEx, "Se produjo un error de solicitud HTTP: {Message}", httpRequestEx.Message);
                    return (new ErrorResponse { statusCode = 503, message = $"Se produjo un error de solicitud HTTP: {httpRequestEx.Message}" });

                default:
                    _logger.LogError(exception, "Se produjo un error inesperado: {Message}", exception.Message);
                    return (new ErrorResponse { statusCode = 500, message = $"Se produjo un error inesperado: {exception.Message}" });
            }
        }
    }
}
