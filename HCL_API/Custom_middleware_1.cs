using System;

namespace HCL_API
{
    public class Custom_middleware_1 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\nCUSTOM MIDDLEWARE CALLED");
            await next(context);
        }
    }
}

