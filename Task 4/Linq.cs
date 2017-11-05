using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1;

namespace Task_4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.GroupBy(i => i).Select(t => $"Broj {t.Key} ponavlja se {t.Count()} puta").OrderBy(i => i).ToArray();
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(t => t.Students.Count(s => s.Gender.Equals(Gender.Male)).Equals(t.Students.Length)).ToArray();
        }
         
        public static University[] Linq2_2(University[] universityArray) =>
            universityArray.Where(t => t.Students.Length < universityArray.Average(s => s.Students.Length)).ToArray();

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(t => t.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(t => (t.Students.All(s => s.Gender == Gender.Male) || t.Students.All(s => s.Gender == Gender.Female))).SelectMany(t => t.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(t => t.Students).GroupBy(s => s).Where(a => a.Count() >= 2).Select(a => a.Key).Distinct().ToArray();
        }
    }
}
