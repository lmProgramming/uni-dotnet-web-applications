using System.ComponentModel.DataAnnotations;

namespace WebApp8EF_Student.Models
{
    public class StudentCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{1,6}$", ErrorMessage = "Write from 1 to 6 digits")]
        public int Index { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "To short name")]
        [Display(Name = "Last Name")]
        [MaxLength(20, ErrorMessage = " To long name, do not exceed {0}")]
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }
        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }
        [Required]
        [Range(1, 12)]
        public int Month { get; set; }
        [Required]
        [Range(1, 31)]
        public int Day { get; set; }
    }

}
