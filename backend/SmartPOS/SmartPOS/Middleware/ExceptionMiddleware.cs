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
        public ExceptionMiddleware(RequestDelegate next) { _next = next; }
        public async Task InvokeAsync(HttpContext context) 
        { 
            try 
            { 
                await _next(context);
            } 
            catch (Exception ex) 
            { 
                context.Response.ContentType = "application/json"; 
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = new { message = ex.Message };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            } 
        }
    }
}
