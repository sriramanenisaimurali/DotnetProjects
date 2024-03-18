namespace MiddlewareExample.CustomMiddleware
{
    public class CustomMiddlewareExample : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom Middleware - Starts \n");
            await next(context);
            await context.Response.WriteAsync("Custom Middleware - Ends \n");
        }
    }
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddlewareExample(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddlewareExample>();
        }
    }
}
