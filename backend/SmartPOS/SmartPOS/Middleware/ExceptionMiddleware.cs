using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartPOS.API.Middleware
{
    public class ExceptionMiddleware 
    { 
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) 
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
                _logger.LogError(ex,
                    "Unhandled exception occurred");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    StatusCode = 500,
                    Message = "Internal Server Error"
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response));
            } 
        }
    }
}
