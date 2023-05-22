using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace web_api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Security
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("UnAuthorized");

                return;
            }
            var header = context.Request.Headers["Authorization"].ToString();
            var encodedCre = header.Substring(6);
            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCre));
            string[] uidpwd = creds.Split(':');

            var uid = uidpwd[0];
            var upass = uidpwd[1];

            if (uid == "Hasnain" && upass == "pass")
            {
                await next(context);
            }
            else
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("UnAuthorized");
                return;
            }


        }
    }
        
        // Extension method used to add the middleware to the HTTP request pipeline.
        public static class SecurityExtensions
    {
        public static IApplicationBuilder UseSecurity(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Security>();
        }
    }
}
