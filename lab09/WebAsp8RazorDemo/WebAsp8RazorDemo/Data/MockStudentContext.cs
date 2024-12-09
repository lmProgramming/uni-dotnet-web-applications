using WebAsp8RazorDemo.Models.ViewModels;

namespace WebAsp8RazorDemo.Data
{
    public class MockStudentContext : IStudentContext
    {
        List<StudentViewModel> stud = new List<StudentViewModel>() {
            new StudentViewModel(0,123456,"Kowal",Gender.Male,true,2,DateTime.Now),
            new StudentViewModel(1,123457,"Newman",Gender.Female,false,1,new DateTime(2000,3,22))
  };
        public void AddStudent(StudentViewModel student)
        {
            int nextNumber = stud.Max(s => s.Id) + 1;
            student.Id = nextNumber;
            stud.Add(student);
        }
        public StudentViewModel? GetStudent(int id)
        {
            return stud.FirstOrDefault(s => s.Id == id);
        }
        public List<StudentViewModel> GetStudents()
        {
            return stud;
        }
        public void RemoveStudent(int id)
        {
            StudentViewModel? studToRemove = stud.FirstOrDefault(s => s.Id == id);
            if (studToRemove != null)
                stud.Remove(studToRemove);
        }
        public void UpdateStudent(StudentViewModel person)
        {
            StudentViewModel? studToUpdate = stud.FirstOrDefault(s => s.Id == person.Id);
            stud = stud.Select(s => (s.Id == person.Id) ? person : s).ToList();
        }

    }
}
