using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
{
    public class ArticleDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public ArticleDbContext(DbContextOptions<ArticleDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Article)
                .WithMany()
                .HasForeignKey(oi => oi.ArticleId);

            modelBuilder.Entity<Article>()
                .Property(a => a.Price)
                .HasPrecision(18, 2);

            modelBuilder.Seed();
        }
    }
}
