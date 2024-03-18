using RoutingExample.CustomRouteConstraints;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
options.ConstraintMap.Add("salesMonths", typeof(MonthsCustomConstraint)));
var app = builder.Build();

//app.Map("/", () => "Hello World!");
/*app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if(endPoint != null)
    {
        await context.Response.WriteAsync(endPoint.DisplayName);
    }
    await next(context);
});*/
app.UseStaticFiles();
app.UseRouting();

/*app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync(endPoint.DisplayName);
    }
    await next(context);
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("map1", async (context) =>
    {
        await context.Response.WriteAsync("\nText from MAP1");
    });
    endpoints.MapPost("map2", async (context) =>
    {
        await context.Response.WriteAsync("Text from MAP2");
    });
});*/

app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"File Name is {filename}.{extension}");
    });
    endpoints.Map("employee/profile/{employeename}", async context =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
        await context.Response.WriteAsync($"Employee Name is {employeeName}");
    });

    endpoints.Map("products/details/{id:int?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"Product id={id}");
        }
        else
        {
            await context.Response.WriteAsync("Enter valid Product Id");
        }
    });
    endpoints.Map("sales-report/{year:min(1900):int?}/{month:salesMonths}", async context =>
    {
        int? yearValue = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? monthName = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"Sales-Report - Year {yearValue} Month {monthName}");
    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Route Url Not matched with {context.Request.Path}");
});
app.Run();
