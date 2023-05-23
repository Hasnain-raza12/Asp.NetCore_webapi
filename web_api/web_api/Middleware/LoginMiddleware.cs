using System.Text;

namespace web_api.Middleware
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint?.Metadata.GetMetadata<LoginRequiredAttribute>() is LoginRequiredAttribute attribute &&
                attribute.MetadataProperty == "metadata-value")
            {
                // Your custom authentication logic here

                if (!context.Request.Headers.ContainsKey("Authorization"))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized");
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
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("UnAuthorized");
                    return;
                }
            }

           
            
        }
    }
}
