using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Student s = (Student)obj;
                return s.Name.Equals(Name) && s.Gender.Equals(Gender) && s.Jmbag.Equals(Jmbag);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }

        public static bool operator == (Student s1, Student s2)
        {
            object obj1 = (object) s1;
            object obj2 = (object) s2;
            if (obj1 != null) return s1.Equals(s2);
            if (obj2 == null) return true;
            return false;
        } 
        public static bool operator != (Student s1, Student s2)
        {
            object obj1 = (object)s1;
            object obj2 = (object)s2;
            if (obj1 != null) return !s1.Equals(s2);
            if (obj2 == null) return false;
            return true;
        }
    }
    public enum Gender
    {
        Male, Female
    }
}
