using LoginApplication.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (Context, next) =>
{
    await next();
});
app.UseLoginMiddleware();

app.Run();
