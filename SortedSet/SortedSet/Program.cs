using System;
using System.Collections.Generic;

namespace SortedSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new SortedSet<string>
            (StringComparer.InvariantCultureIgnoreCase)
                {"New York", "Manchester", "Sheffield", "Paris"};

            bigCities.Add("Sheffield");
            bigCities.Add("Beijing");

            foreach (string city in bigCities)
            {
                Console.WriteLine(city);
            }
            Console.ReadKey();
        }
    }
}
