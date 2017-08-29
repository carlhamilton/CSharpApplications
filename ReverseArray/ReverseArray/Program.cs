using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArray
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
           // var reversed = daysOfWeek.Reverse(); (.ToArray can be used to return the answer back to an array) We can use this but we would need to replace daysOfWeek with reversed in the foreach loop.
            Array.Reverse(daysOfWeek); //Reverses the array contents so when printed they will show from the last index first.
            //Linq creates new objects rather than changing the old values.

            foreach (string day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
            Console.ReadKey();
        }
    }
}
