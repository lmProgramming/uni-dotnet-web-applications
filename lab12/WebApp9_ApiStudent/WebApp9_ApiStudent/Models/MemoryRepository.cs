using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp9_ApiStudent.Models
{
    public class MemoryRepository : IRepository
    {
        private readonly Dictionary<int, Student> items; // po co musi być readonly?!
        public MemoryRepository()
        {
            items = new Dictionary<int, Student>();
            new List<Student>
            {
                new Student{ Index=11111, Name="Smith"},
                new Student{ Index=22222, Name="Kowal"},
                new Student{ Index=33333, Name="Schneider"}

            }.ForEach(s => AddStudent(s));
        }
        public Student? this[int id] => items.ContainsKey(id)?items[id]:null;

        public IEnumerable<Student> Students => items.Values;

        public Student AddStudent(Student student)
        {
            if (student.Id == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                student.Id = key;
            }
            items[student.Id] = student;
            return student;
        }

        public void DeleteStudent(int id)=>items.Remove(id);

        public Student UpdateStudent(Student student) => AddStudent(student);

        public Student? GetNextStudent(int id)
        {
            return items
                .Select(s => s.Value)
                .Where(s => s.Id > id)
                .OrderBy(s => s.Id)
                .FirstOrDefault();
        }

        public Student? GetPreviousStudent(int id)
        {
            return items
                .Select(s => s.Value)
                .Where(s => s.Id < id)
                .OrderByDescending(s => s.Id)
                .FirstOrDefault();
        }
    }
}
