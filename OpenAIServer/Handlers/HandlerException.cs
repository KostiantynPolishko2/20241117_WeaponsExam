using OpenAIServer.Infrastructures;
using OpenAIServer.Interfaces;
using System.Net;
using System.Text.Json;

namespace OpenAIServer.Handlers
{
    public class HandlerException : IHandlerException
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HandlerException> _logger;

        public HandlerException(RequestDelegate next, ILogger<HandlerException> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An error occurred while processing the request.");

            var (statusCode, message) = exception switch
            {
                HttpRequestException => (HttpStatusCode.ServiceUnavailable, "request is failed due network, DNS, or server sertificate"),
                TaskCanceledException => (HttpStatusCode.RequestTimeout, "requested time is finished"),
                ImageAIException => (HttpStatusCode.BadRequest, "request is failed due to responce from out azure server"),
                _ => (HttpStatusCode.InternalServerError, "An unexpected error occurred.")
            };

            var response = new
            {
                StatusCode = (int)statusCode,
                Message = message,
                Details = exception.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
