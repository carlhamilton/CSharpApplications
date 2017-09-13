using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isReadOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            ICollection<string> collection =
                (ICollection<string>) daysOfWeek;
           // (collection as string[])[5] = "SlaveDay";
            if (!collection.IsReadOnly)
            {
                collection.Add("SlaveDay");
            }
            else
            {
                Console.WriteLine("Collection is read-only");
            }

            foreach (string day in collection)
            {
                Console.WriteLine(day);
            }
            Console.ReadKey();
        }
    }
}
