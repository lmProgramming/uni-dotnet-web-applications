using System.Text;

namespace WebApp9_Middleware.Middlewares
{
    public class ErrorPageMiddleware
    {
        private RequestDelegate nextDelegate;

        public ErrorPageMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext); // forward without changes

            // on return path modify response
            if (httpContext.Response.StatusCode == 403 &&
                (httpContext.Items["EdgeBrowser"] as bool? == true)) // one condition is enough
            {
                await httpContext.Response
                        .WriteAsync("The Microsoft Edge web browser is unsupported.", Encoding.UTF8);
            }
            else if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response
                        .WriteAsync("No content.", Encoding.UTF8);
            }
        }
    }
}
