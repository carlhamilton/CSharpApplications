using System;
using System.Linq;

namespace BinarySearch
{
    //Checks midpoint element to see if higher or lower than required element.
    class Program
    {
        static void Main(string[] args)
        {
            string[] sortedDays =
            {
                "Friday",
                "Monday",
                "Saturday",
                "Sunday",
                "Thursday",
                "Tuesday",
                "Wednesday"
            };

            int IndexOfSum = Array.BinarySearch(sortedDays, "Sunday");
            // int indexOfSum = Array.IndexOf(sortedDays, "Sunday");
            Console.WriteLine("Index is " + IndexOfSum);
            Console.ReadKey();
        }
        
    }
}
