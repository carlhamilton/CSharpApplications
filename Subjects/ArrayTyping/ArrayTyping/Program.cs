using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;


namespace ArrayTyping
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] objArray = new object[3]
            {
                "Hello World",
                4,
                new Button {Text = "Click me!"}//bug to solve launching Button
            };
            foreach (object item in objArray)
                Console.WriteLine(item);
            {
                
            }
        }
    }
}
