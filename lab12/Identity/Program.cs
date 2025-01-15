using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Identity.Data;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });

        builder.Services.AddDbContextPool<ArticleDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyDb"))
        );

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ArticleDbContext>();

        builder.Services.AddAuthorizationBuilder()
        .AddPolicy("RequireRoleForEditing", policy =>
            policy.RequireRole("Admin"));

        builder.Services.AddAuthorizationBuilder()
            .AddPolicy("RequireRoleForViewStore", policy =>
                policy.RequireAssertion(context =>
                    !context.User.IsInRole("Admin")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseCors();
        app.UseAuthorization();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            await MyIdentityDataInitializer.SeedData(userManager, roleManager);
        }

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages();
        app.MapControllers();

        app.Run();
    }
}