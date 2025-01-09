using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp9_ApiStudent.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return "" + Id + ") " + Index + ", " + Name;
        }
    }
}
