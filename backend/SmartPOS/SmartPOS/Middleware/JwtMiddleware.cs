using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.API.Middleware
{
    public class JwtMiddleware 
    { 
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        { 
            _next = next;
        } 
        public async Task InvokeAsync(HttpContext context) 
        { 
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrWhiteSpace(token)) { } await _next(context); 
        }
    }
}
