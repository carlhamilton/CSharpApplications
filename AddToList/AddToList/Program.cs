using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddToList
{
    class Program
    {
        static void Main(string[] args)
        {
            var presidents = new List<string>
            {
                "Jimmy Carter",
                "Ronald Reagan",
                "George HW Bush",
                "Bill Clinton",
                "George W Bush"
            };

            Console.WriteLine("Before:");
            Console.WriteLine("Count = " + presidents.Count);
            Console.WriteLine("Capacity = " + presidents.Capacity + "\r\n");

            presidents.Add(("Barack Obama"));
            string[] copy = presidents.ToArray();//use for small list
           // var copy = presidents.AsReadOnly();

            Console.WriteLine("After: ");
            Console.WriteLine("Count = " + presidents.Count);
            Console.WriteLine("Capacity = " +presidents.Capacity + "\r\n");


           // BadCode(copy);
            foreach (string president in presidents)
            {
                Console.WriteLine(president);
            }
            Console.ReadKey();
        }

        static void BadCode(IList<string> lst)
        {
            lst.RemoveAt(2);
        }
    }
}
