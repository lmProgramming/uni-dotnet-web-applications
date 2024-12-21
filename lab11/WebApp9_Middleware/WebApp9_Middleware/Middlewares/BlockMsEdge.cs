namespace WebApp9_Middleware.Middlewares
{
    public class BlockMsEdge
    {
        private RequestDelegate nextDelegate;

        public BlockMsEdge(RequestDelegate next)
                  => nextDelegate = next;

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Items["EdgeBrowser"] as bool? == true)
            {
                httpContext.Response.StatusCode = 403; // do NOT call nextDelegate.Invoke()
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }

    }
}
