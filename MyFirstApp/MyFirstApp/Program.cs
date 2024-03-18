using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*app.Run(async(HttpContext context) =>{
    string path = context.Request.Path;
    //await context.Response.WriteAsync("Hello");
    //await context.Response.WriteAsync($"<p>{path}</p>");
    //context.Request.Headers["Content-type"] = "text/html";

    *//*if (context.Request.Headers.ContainsKey("AuthorizationKey"))
    {
        string Agent = context.Request.Headers["AuthorizationKey"];
        await context.Response.WriteAsync(Agent);
    }*/

/*StreamReader reader = new StreamReader(context.Request.Body);
string QueryStr = await reader.ReadToEndAsync();
Dictionary<string, StringValues> QueryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(QueryStr);
if (QueryDict.ContainsKey("Name"))
{
    string Name = QueryDict["Name"][0];
    await context.Response.WriteAsync(Name);
}*//*
});*/

   app.Run();
