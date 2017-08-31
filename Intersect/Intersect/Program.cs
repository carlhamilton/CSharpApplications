using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersect
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new HashSet<string>
            {
                "New York",
                "Manchester",
                "Sheffield",
                "Paris"
            };

            string[] citiesInUk =
            {
                "Sheffield", "Ripon", "Truro", "Manchester"
            };

            //bigCities.UnionWith(citiesInUk);
           // bigCities.SymmetricExceptWith(citiesInUk);
           bigCities.ExceptWith(citiesInUk);

            foreach (string city in bigCities)
            {
                Console.WriteLine(city);
            }
            Console.ReadKey();
        }
    }
}
