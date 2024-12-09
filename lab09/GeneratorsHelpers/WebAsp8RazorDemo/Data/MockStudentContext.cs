using WebAsp8RazorDemo.Models.ViewModels;

namespace WebAsp8RazorDemo.Data
{
    public class MockStudentContext : IStudentContext
    {
        List<ArticleViewModel> stud = new List<ArticleViewModel>() {
            new ArticleViewModel(0,123456,"Kowal",Gender.Male,true,2,DateTime.Now),
            new ArticleViewModel(1,123457,"Newman",Gender.Female,false,1,new DateTime(2000,3,22))
  };
        public void AddStudent(ArticleViewModel student)
        {
            int nextNumber = stud.Max(s => s.Id) + 1;
            student.Id = nextNumber;
            stud.Add(student);
        }
        public ArticleViewModel? GetStudent(int id)
        {
            return stud.FirstOrDefault(s => s.Id == id);
        }
        public List<ArticleViewModel> GetStudents()
        {
            return stud;
        }
        public void RemoveStudent(int id)
        {
            ArticleViewModel? studToRemove = stud.FirstOrDefault(s => s.Id == id);
            if (studToRemove != null)
                stud.Remove(studToRemove);
        }
        public void UpdateStudent(ArticleViewModel person)
        {
            ArticleViewModel? studToUpdate = stud.FirstOrDefault(s => s.Id == person.Id);
            stud = stud.Select(s => (s.Id == person.Id) ? person : s).ToList();
        }

    }
}
