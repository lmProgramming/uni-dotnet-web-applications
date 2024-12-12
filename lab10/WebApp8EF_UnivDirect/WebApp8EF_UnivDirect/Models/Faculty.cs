using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp8EF_UnivDirect.Models
{
    [Table("Faculty")]
    public class Faculty
    {
        public int FacultyId { get; set; }
        [Required]
        [MaxLength(40)]
        public string? FacultyName { get; set; } // can be Name

        public ICollection<Student>? Students { get; set; } // for one-to-many relaction
    }

}
