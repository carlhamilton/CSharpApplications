using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> tasks = new Queue<string>();

            tasks.Enqueue("Do the washing up");
            tasks.Enqueue("Finish the C# Collections Pluralsight course");
            tasks.Enqueue("Buy some chocolate");
            tasks.Enqueue("Buy some more chocolate");

            Console.WriteLine("\r\nAll Tasks\r\n");

            foreach (string title in tasks)
            {
                Console.WriteLine(title);
            }
            string nextTask = tasks.Dequeue(); //removes a task from the queue use tasks.Peek(); to not remove an item from the list

            Console.WriteLine("\r\nNext Task is " + nextTask + "\r\n");

            Console.WriteLine("\r\nAll Tasks");
            foreach (string title in tasks)
            {
                Console.WriteLine(title);
            }

            Console.ReadKey();
        }
    }
}
