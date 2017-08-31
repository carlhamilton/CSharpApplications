using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetEquals
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new HashSet<string>
                {"New York", "Manchester", "Sheffield", "Paris"};

            var citiesInUK = new HashSet<string>
                {"Sheffield", "Ripon", "Truro", "Manchester"};

            var bigCitiesArr = new string[]
                {"New York", "Manchester", "Sheffield", "Paris"};

            bool areEqual = bigCities.SetEquals(bigCitiesArr); //Compares for equality
            Console.WriteLine("bigCities = bigCitiesArr? " + areEqual);

            bool areEqualUK = citiesInUK.SetEquals(bigCitiesArr);
            Console.WriteLine("citiesInUk = bigCitiesArr? " +areEqualUK);

            Console.ReadKey();
        }
    }
}
