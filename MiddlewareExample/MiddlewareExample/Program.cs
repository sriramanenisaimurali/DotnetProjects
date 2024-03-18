using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddlewareExample>();
var app = builder.Build();

//Middleware1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware1 \n");
    await next(context);
	await context.Response.WriteAsync("Middleware1 ended \n");
});

//Middleware2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware2 \n");
    await next(context);
});

//Middleware3
//app.UseMiddleware<CustomMiddlewareExample>();
app.UseCustomMiddlewareExample();
app.UseNameMiddleware();

//Middleware4
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Middleware3 \n");
});

app.Run();
