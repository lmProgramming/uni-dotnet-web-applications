using Microsoft.AspNetCore.Identity;

namespace Identity.Data
{
    public class IdentityDataInitializer
    {
        public static async Task SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var adminUser = await userManager.FindByEmailAsync("admin@shop.com");
            if (adminUser == null)
            {
                adminUser = new IdentityUser { UserName = "admin@shop.com", Email = "admin@shop.com" };
                await userManager.CreateAsync(adminUser, "Admin123!");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

    }
}
