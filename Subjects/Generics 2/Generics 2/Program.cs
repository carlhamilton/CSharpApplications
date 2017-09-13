using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_2
{
    // list example of generics
    

    public class MyList<T>
    {
        private List<T> mNumbers = new List<T>();


        public void AddNumber(T number)
        {
            mNumbers.Add(number);
        }
        public T GetNumber(int i)
        {
            return mNumbers[i];
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            var list = new MyList<int>();
            list.AddNumber(10);
            list.AddNumber(20);
            list.AddNumber(30);
            list.AddNumber(40);
            list.AddNumber(50);
            Console.WriteLine(list.GetNumber(3));


            var strings = new MyList<string>();
            strings.AddNumber("A");
            strings.AddNumber("B");
            strings.AddNumber("C");
            strings.AddNumber("D");
            strings.AddNumber("E");


            Console.WriteLine(strings.GetNumber(3));
            Console.ReadLine();
        }
    }
}
