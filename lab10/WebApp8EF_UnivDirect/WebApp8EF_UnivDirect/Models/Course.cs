using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp8EF_UnivDirect.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(40)]
        public string? CourseName { get; set; }

        public ICollection<CourseStudent>? CourseStudents { get; set; }        // for many-to-many relaction
    }
}
