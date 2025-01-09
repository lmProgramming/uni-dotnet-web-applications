using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp9_ApiStudent.Models
{
    public interface IRepository
    {

        IEnumerable<Student> Students { get; }
        Student? this[int id] { get; }
        Student AddStudent(Student student);
        Student UpdateStudent(Student student);
        void DeleteStudent(int id);
        Student? GetNextStudent(int id);
        Student? GetPreviousStudent(int id);
    }
}
