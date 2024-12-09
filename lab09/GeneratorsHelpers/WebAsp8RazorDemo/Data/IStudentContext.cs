using WebAsp8RazorDemo.Models.ViewModels;

namespace WebAsp8RazorDemo.Data
{
    public interface IStudentContext
    {
        List<ArticleViewModel> GetStudents();
        ArticleViewModel? GetStudent(int id);
        void AddStudent(ArticleViewModel person);
        void RemoveStudent(int id);
        void UpdateStudent(ArticleViewModel person);
    }
}
