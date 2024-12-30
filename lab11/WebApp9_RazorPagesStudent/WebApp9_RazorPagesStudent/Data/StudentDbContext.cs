using Microsoft.EntityFrameworkCore;
using WebApp9_RazorPagesStudent.Models;

namespace WebApp9_RazorPagesStudent.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
