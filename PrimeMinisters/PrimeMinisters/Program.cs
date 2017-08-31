using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeMinisters
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeMinisters = new Dictionary<string, PrimeMinister>//Using dictionary we must define a key such as initials as below.
            (StringComparer.InvariantCultureIgnoreCase)
            {
                {"JC", new PrimeMinister("James Callaghan", 1976)},
                {"MT", new PrimeMinister("Margaret Thatcher", 1979)},
                {"TB", new PrimeMinister("Tony Blair", 1997)}

            };

            foreach (var pms in primeMinisters)
            {
                Console.WriteLine(pms);
               // Console.WriteLine(pm.Key + ",     " + pm.Value);
            }
            PrimeMinister pm = primeMinisters["TB"];
            Console.WriteLine("Value is: " + pm.ToString() + "\r\n");

            primeMinisters["JC"] = new PrimeMinister("Jim Callaghan", 1976);
            primeMinisters["JM"] = new PrimeMinister("John Major", 1990);
            primeMinisters["DC"] = new PrimeMinister("David Cameron", 2010);
            primeMinisters.Add("GB", new PrimeMinister("Gordon Brown", 2007));

            foreach (var pms in primeMinisters)
            {
                Console.WriteLine(pms);
                // Console.WriteLine(pm.Key + ",     " + pm.Value);
            }


            PrimeMinister newpm;
            bool found = primeMinisters.TryGetValue("DC", out newpm);
            if ((found))
                Console.WriteLine("Value is: " + newpm.ToString() + "\r\n");
            else
            {
                Console.WriteLine("Value was not in the dictionary");
            }

            var pmsReadObly = new ReadOnlyDictionary<string, PrimeMinister>(primeMinisters);

            foreach (var pme in pmsReadObly)
            {
                Console.WriteLine(pme.Value);
            }
            Console.ReadKey();
        }

    }
}
