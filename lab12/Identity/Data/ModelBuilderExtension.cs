using Microsoft.EntityFrameworkCore;
using RazorCookies.Models;

namespace RazorCookies.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Bakery" },
                new Category { Id = 2, Name = "Dairy" }
            );

            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Name = "Bread",
                    Price = 1.2m,
                    CategoryId = 1,
                    Quantity = 20,
                    ExpirationDate = new DateTime(2024, 12, 31)
                },
                new Article
                {
                    Id = 2,
                    Name = "Milk",
                    Price = 0.8m,
                    CategoryId = 2,
                    Quantity = 10,
                    ExpirationDate = new DateTime(2024, 12, 31)
                }
            );
        }
    }
}
