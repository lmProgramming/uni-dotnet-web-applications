using Microsoft.EntityFrameworkCore;
using RazorCookies.Data;

namespace RazorCookies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSession();
            builder.Services.AddDbContextPool<ArticleDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDb"))
            );
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "shop_mvc",
                pattern: "MvcShop/{action=Index}/{id?}",
                defaults: new { controller = "Shop" }
            );

            app.MapGet("/", context => {
                context.Response.Redirect("/Index");
                return Task.CompletedTask;
            });

            app.Run();
        }
    }
}
