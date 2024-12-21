using WebApp9_Middleware.Middlewares;
using WebApp9_Middleware.Services;

namespace WebApp9_Middleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<UptimeService>();

            var app = builder.Build();

            #region my middlewares
            app.UseMiddleware<ErrorPageMiddleware>();
            app.UseMiddleware<BrowserTypeMiddleware>();
            app.UseMiddleware<BlockMsEdge>();
            app.UseMiddleware<CatchMiddleware>();
            #endregion
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
 
        }
    }
}
