using System.Text;
using WebApp9_Middleware.Services;

namespace WebApp9_Middleware.Middlewares
{
    public class CatchMiddleware
    {
        private RequestDelegate nextDelegate;
        private UptimeService uptime;

        public CatchMiddleware(RequestDelegate next, UptimeService up)
        {
            nextDelegate = next;
            uptime = up;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync(
                  " This message is from middleware: " + $"(uptime: {uptime.Uptime}ms)", Encoding.UTF8);
                // do NOT call nextDelegate.Invoke
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}

