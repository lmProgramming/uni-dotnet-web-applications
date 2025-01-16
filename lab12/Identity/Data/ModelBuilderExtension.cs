using Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
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

            for (int i = 10; i < 500; i++)
            {
                modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = i,
                    Name = $"Item {i}",
                    Price = 1.2m,
                    CategoryId = 2,
                    Quantity = 20,
                    ExpirationDate = new DateTime(2024, 12, 31)
                });
            }
        }
    }
}
