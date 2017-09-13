using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KeyedCollection
{
    class Program
    {
        static void Main(string[] args)
        {

            var primeMinisters = new PrimeMinistersByYearDictionary() 
                {
                    new PrimeMinister("James Callaghan", 1974),
                    new PrimeMinister("Margaret Thatcher", 1979),
                    new PrimeMinister("Tony Blair", 1997)
                };
            primeMinisters.Add(
                new PrimeMinister("John Major", 1990));

            foreach (var pm in primeMinisters)
            {
                Console.WriteLine(pm);

            }
            Console.WriteLine("Tony is " + primeMinisters[1997]);

            var list = (IList<PrimeMinister>) primeMinisters; //Allows you to place in an index so you can say what is in the paricular index

            Console.WriteLine("The first PM is:  " + list[0]);



            Console.ReadKey();
        }
    }

    class PrimeMinistersByYearDictionary :
        KeyedCollection<int, PrimeMinister>
    {
        protected override int GetKeyForItem(PrimeMinister item)
        {
            return item.YearElected;
        }
    }
}
