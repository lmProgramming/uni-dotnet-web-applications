using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp8EF_UnivDirect.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(40)]
        public string? LastName { get; set; }

        public ICollection<CourseStudent>? CourseStudents { get; set; }        // for many-to-many relaction

        public int? FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public Faculty? Faculty { get; set; } // for one-to-many relaction
    }

}
