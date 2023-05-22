using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace web_api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomAuthentication
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint?.Metadata.GetMetadata<CustomAuthenticationAttribute>() is CustomAuthenticationAttribute attribute &&
                attribute.MetadataProperty == "metadata-value")
            {
                if (!context.Request.Headers.ContainsKey("Authorization"))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }

                string authorizationHeader = context.Request.Headers["Authorization"];

                string encodedCredentials = authorizationHeader.Substring("Basic ".Length).Trim();
                string credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
                string[] uidpwd = credentials.Split(':');

                var uid = uidpwd[0];
                var upass = uidpwd[1];

                if (uid == "Hasnain" && upass == "pass")
                {
                    await next(context);
                }
                else
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }
            }
            else
            {
                await next(context);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomAuthenticationExtensions
    {
        public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomAuthentication>();
        }
    }
}
