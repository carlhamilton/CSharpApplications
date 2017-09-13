using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace LinkedListTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var presidents = new LinkedList<string>();
            presidents.AddLast("JFK");
            presidents.AddLast("Lyndon B Johnson");
            presidents.AddLast("Richard Nixon");
            presidents.AddLast("Jimmy Carter");

            LinkedListNode<string> Nixon = presidents.Find("Richard Nixon"); // Not efficient if the element is very large and only finds the first occurance
            presidents.AddAfter(Nixon, "Gerald Ford"); //adds to the list after specified point.

            presidents.RemoveFirst(); // remove first element
            presidents.AddFirst("John F Kennedy"); //adds new choice at first element point.

            foreach (string president in presidents)
            {
                Console.WriteLine(president);
            }
            Console.ReadKey();
        }
    }
}
