using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApp8EF_UnivDirect.Models;

namespace WebApp8EF_UnivDirect.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseStudent> CourseStudent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>()
                        .HasKey(t => new { t.CourseId, t.StudentId });

            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { FacultyId = 1, FacultyName = "Science" },
                new Faculty { FacultyId = 2, FacultyName = "Arts" }
            );

            //    modelBuilder.Entity<CourseStudent>()
            //                .HasOne(cs => cs.Course)
            //                .WithMany(p => p.CourseStudents)
            //                .HasForeignKey(cs => cs.CourseId);

            //    modelBuilder.Entity<CourseStudent>()
            //                .HasOne(cs => cs.Student)
            //                .WithMany(s => s.CourseStudents)
            //                .HasForeignKey(cs => cs.StudentId);
        }
    }

}
