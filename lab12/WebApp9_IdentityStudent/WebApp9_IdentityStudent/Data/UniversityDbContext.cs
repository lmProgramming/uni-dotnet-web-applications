using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp9_IdentityStudent.Models;

namespace WebApp9_IdentityStudent.Data
{
    public class UniversityDbContext : IdentityDbContext
    {

        public DbSet<Student> Student { get; set; }

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
            : base(options)        {        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // create tables for Identity
            modelBuilder.Seed();
        }
    }
}
