namespace WebApp9_Middleware.Middlewares
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate nextDelegate;

        public BrowserTypeMiddleware(RequestDelegate next)
                  => nextDelegate = next;

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"] = httpContext.Request.Headers["User-Agent"].Any(v => v.ToLower().Contains("edg"));

            await nextDelegate.Invoke(httpContext);
        }
    }
}
