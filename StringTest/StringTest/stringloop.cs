using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace StringTest
{
    class stringloop
    {
        static void Main(string[] args)
        {
            string str = "Hello, World";
            //loop runs through the string
            for (int i = 0; i < str.Length; i++)
            {

                Console.WriteLine(str[i] + " Index is at: " + str.IndexOf(str[i]));




            }

            //counts the total number of elements used on a string
            int count = str.Count();
            //outputs the answer
            Console.WriteLine("There are {0} Letters in the string", count-1);
            Console.ReadKey();
        }
    }
}
