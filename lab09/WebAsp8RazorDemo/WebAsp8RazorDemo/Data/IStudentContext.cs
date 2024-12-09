using WebAsp8RazorDemo.Models.ViewModels;

namespace WebAsp8RazorDemo.Data
{
    public interface IStudentContext
    {
        List<StudentViewModel> GetStudents();
        StudentViewModel? GetStudent(int id);
        void AddStudent(StudentViewModel person);
        void RemoveStudent(int id);
        void UpdateStudent(StudentViewModel person);
    }
}
