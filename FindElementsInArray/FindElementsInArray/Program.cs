using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindElementsInArray
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
/*
            int indexOfTues = Array.IndexOf(daysOfWeek, "Tuesday");

            Console.WriteLine(indexOfTues);
            */
            var indexOfW = Array.FindIndex(daysOfWeek, x => x[0] == 'W' );

            string[] allWith6Chars = Array.FindAll(
                daysOfWeek, x => x.Length == 6);
            foreach (string item in allWith6Chars)
            {
                Console.WriteLine(item);
            }
               

            Console.WriteLine(indexOfW);
            Console.WriteLine(daysOfWeek[indexOfW]);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
