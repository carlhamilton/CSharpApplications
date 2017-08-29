using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            var comparer = new StringLengthComparer();
            Array.Sort(daysOfWeek, comparer); // Arranges the string to an alphabetical order list. we also compare to show the shortest by comparing two lengths through a created class.

            foreach (string day in daysOfWeek) //Goes through an array
            {
                Console.WriteLine(day);
            }
            Console.ReadKey();
        }

        class StringLengthComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return x.Length.CompareTo(y.Length);
            }
        }
    }
}
