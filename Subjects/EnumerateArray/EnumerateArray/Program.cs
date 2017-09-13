using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var daysOfWeek = new List<string>
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"

            };

            foreach (string day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
            Console.ReadKey();
        }
    }
}
