using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new HashSet<string>
            (StringComparer.InvariantCultureIgnoreCase)
            {
                "New York",
                "Manchester",
                "Sheffield",
                "Paris"
            };
            bigCities.Add("SHeffield");
            bigCities.Add("Beijing");

            foreach (string city in bigCities)
            {
                Console.WriteLine(city);
            }

            string[] citiesInUK =
                {"Sheffield", "Ripon", "Harrogate", "Manchester"}; //compares which cities are in both collections and then uses those to print out.

            bigCities.IntersectWith(citiesInUK);

            foreach (string city in bigCities)
            {
                Console.WriteLine(city);
            }

            var newCities = bigCities.Intersect(citiesInUK); // LINQ method which creates a new collection can be slower

            foreach (string city in newCities)
            {
                Console.WriteLine(city);
            }
            Console.ReadKey();

        }
    }
}
