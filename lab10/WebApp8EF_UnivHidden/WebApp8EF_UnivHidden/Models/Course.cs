using System.ComponentModel.DataAnnotations;

namespace WebApp8EF_UnivHidden.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        [MaxLength(40)]
        public string? CourseName { get; set; }

        public ICollection<Student>? Students { get; set; }  // for many-to-many relaction
    }
}
