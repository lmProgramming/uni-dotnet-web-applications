using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebAsp8RazorDemo.Models.ViewModels
{
    public enum Gender { Female, Male }

    public class StudentViewModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{1,6}$")]
        public int Index { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "To short name")]
        [Display(Name = "Last Name")]
        [MaxLength(20, ErrorMessage = " To long name, do not exceed {1}")]
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        public StudentViewModel()
        {

        }

        public StudentViewModel(int id, int index, string name, Gender gender, bool active, int departmentID, DateTime birthDate)
        {
            this.Id = id;
            this.Index = index;
            this.Name = name;
            this.Gender = gender;
            this.Active = active;
            this.DepartmentId = departmentID;
            this.BirthDate = birthDate;
        }
    }
}
