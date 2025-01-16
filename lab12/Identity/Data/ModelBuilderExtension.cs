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
                new Category { Id = 2, Name = "Dairy" },
                new Category { Id = 3, Name = "Fruit" },
                new Category { Id = 4, Name = "Vegetable" },
                new Category { Id = 5, Name = "Meat" }
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
                },
                new Article
                {
                    Id = 3,
                    Name = "Apple",
                    Price = 0.5m,
                    CategoryId = 3,
                    Quantity = 30,
                    ExpirationDate = new DateTime(2024, 12, 31)
                },
                new Article
                {
                    Id = 4,
                    Name = "Carrot",
                    Price = 0.3m,
                    CategoryId = 4,
                    Quantity = 40,
                    ExpirationDate = new DateTime(2024, 12, 31)
                },
                new Article
                {
                    Id = 5,
                    Name = "Chicken",
                    Price = 2.5m,
                    CategoryId = 5,
                    Quantity = 10,
                    ExpirationDate = new DateTime(2024, 12, 31)
                }
            );

            var end = 500;
            for (int i = 10; i < end; i++)
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
            for (int i = end; i < end + 10; i++)
            {
                modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = i,
                    Name = $"Meat {i}",
                    Price = 12.2m,
                    CategoryId = 5,
                    Quantity = 200,
                    ExpirationDate = new DateTime(2025, 12, 31)
                });
            }
        }
    }
}
