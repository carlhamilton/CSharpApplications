using PrimeMinisters;
using System;
using System.Collections.Generic;

namespace SortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var primeMinisters = new SortedList<string, PrimeMinister> //SortedList will sort by the key and then the value. Only use if keys can be ordered.
                (StringComparer.InvariantCultureIgnoreCase)
            {
                {"JC", new PrimeMinister("James Callaghan", 1974)},
                {"MT", new PrimeMinister("Margaret Thatcher", 1979)},
                {"TB", new PrimeMinister("Tony Blair", 1997)}
            };
            primeMinisters.Add(
                "JM", new PrimeMinister("John Major", 1990));

            foreach (var pm in primeMinisters)
            {
                Console.WriteLine(pm);

            }
            Console.WriteLine("Tony is " + primeMinisters["tb"]);

            Console.ReadKey();
        }
    }
}
