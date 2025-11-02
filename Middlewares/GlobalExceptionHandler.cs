
using System.Net;
using System.Text.Json;
using DigitalizeFabricationBussiness.Utilities.Exceptions;

namespace DigitalizedFabricationBusiness.Middlewares;


    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred.");

            context.Response.ContentType = "application/json";

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string type = "ServerError";
            string message = "An unexpected error occurred.";

            if (ex is CustomException customEx)
            {
                statusCode = customEx.StatusCode;
                type = customEx.Code;
                message = customEx.Message;
            }
            else if (ex is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                type = "Unauthorized";
                message = ex.Message;
            }

            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                success = false,
                error = new
                {
                    message,
                    statusCode,
                    type,
                    timestamp = DateTime.UtcNow
                }
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

    // Extension method to register middleware
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }

