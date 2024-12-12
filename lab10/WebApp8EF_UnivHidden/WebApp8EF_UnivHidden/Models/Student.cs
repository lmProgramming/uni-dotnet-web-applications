using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp8EF_UnivHidden.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        [MaxLength(40)]
        public string? StudentName { get; set; }

        public ICollection<Course>? Courses { get; set; } // for many-to-many relaction
        public Faculty? Faculty { get; set; } // for one-to-many relaction

    }
}
