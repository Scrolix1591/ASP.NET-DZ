using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Middlewares
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        public Middleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext ctx)
        {
            Console.WriteLine($"My class middleware: {ctx.Request.Host.Host} : {ctx.Request.Host.Port}");
            await _next.Invoke(ctx);
        }
    }
}
