using System;
using System.Collections;
using System.Collections.Generic;

namespace ImplemenetEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            AllDaysOfWeek allDays = new AllDaysOfWeek();
            foreach (string day in allDays)
            {
                Console.WriteLine(day);
            }
            Console.ReadKey();
        }
    }

    public class AllDaysOfWeek : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Monday";
            yield return "Tuesday";
            yield return "Wednesday";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
