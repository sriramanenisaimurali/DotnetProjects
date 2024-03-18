using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Net.Http;
using System.Threading.Tasks;

namespace LoginApplication.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        private string _username = "sai@gmail.com";
        private string _password = "1234";

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            StreamReader reader = new StreamReader(httpContext.Request.Body);
            string Querystr = await reader.ReadToEndAsync();
            Dictionary<string, StringValues> QueryValues = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(Querystr);
            if (QueryValues.ContainsKey("username") && QueryValues.ContainsKey("password") && (httpContext.Request.Method == "POST"))
            {
                string username = QueryValues["username"][0];
                string password = QueryValues["password"][0];
                if (username.Equals(_username) && password.Equals(_password))
                {
                    await httpContext.Response.WriteAsync("Login Successfull!!!");
                }
                else
                {
                    await httpContext.Response.WriteAsync("Username or Password INCORRECT \n Please Enter Valid Username and Password");
                }
            }
            else if(!(QueryValues.ContainsKey("username") && QueryValues.ContainsKey("password")))
            {
                await httpContext.Response.WriteAsync("Invalid Username\nInvalid password");
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
