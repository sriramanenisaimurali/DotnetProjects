var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();//add controller classes as services
var app = builder.Build();

app.MapControllers();

app.Run();
