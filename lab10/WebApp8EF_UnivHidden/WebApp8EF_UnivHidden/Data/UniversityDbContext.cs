using Microsoft.EntityFrameworkCore;
using WebApp8EF_UnivHidden.Models;

namespace WebApp8EF_UnivHidden.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Course> Courses { get; set; }

        //public DbSet<CourseStudent> CourseStudent { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CourseStudent>()
        //                .HasKey(t => new { t.CourseId, t.StudentId });

        //    modelBuilder.Entity<CourseStudent>()
        //                .HasOne(cs => cs.Course)
        //                .WithMany(p => p.CourseStudents)
        //                .HasForeignKey(cs => cs.CourseId);

        //    modelBuilder.Entity<CourseStudent>()
        //                .HasOne(cs => cs.Student)
        //                .WithMany(s => s.CourseStudents)
        //                .HasForeignKey(cs => cs.StudentId);
        //}
    }

}
