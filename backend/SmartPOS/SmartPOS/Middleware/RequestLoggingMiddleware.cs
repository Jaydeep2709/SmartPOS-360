using System.Net;
using System.Text.Json;

namespace SmartPOS.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next; 
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        public RequestLoggingMiddleware
            (
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger
            ) 
        { 
            _next = next; 
            _logger = logger;
        } 
        public async Task InvokeAsync(HttpContext context)
        { 
            _logger.LogInformation("{method} {url}", 
                context.Request.Method,
                context.Request.Path); 
            await _next(context);
        } 
    }
}
