using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp8EF_UnivDirect.Models
{
    [Table("CourseStudent")]
    public class CourseStudent
    {
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }

}
