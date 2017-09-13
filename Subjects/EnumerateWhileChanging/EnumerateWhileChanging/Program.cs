using System;
using System.Collections.Generic;

namespace EnumerateWhileChanging
{
    class Program
    {
        static void Main(string[] args)
        {
            var days = new List<string>// new string[] would work with days[1]
            {
                "Monday",
                "Tuesday",
                "Wednesday"
            };

            foreach (string day in days)
            {
                days[1] = "2nd day"; // we are unable to do this due to using the enumerator as the collection has changed so we are unable to move through the list.
                //comment out to run.
                Console.WriteLine(day);
            }
            Console.ReadKey();
        }
    }
}
