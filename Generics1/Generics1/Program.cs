using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics1
{

    // List without generics

    public class MyIntList
    {
        private List<int> mNumbers = new List<int>();


        public void AddNumber (int number)
        {
            mNumbers.Add(number);
        }
        public int GetNumber(int i)
        {
            return mNumbers[i];
        }
    }

    public class MyStringList
    {
        private List<string> mStrings = new List<string>();


        public void AddString(string number)
        {
            mStrings.Add(number);
        }
        public string GetString(int i)
        {
            return mStrings[i];
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var numbers = new MyIntList();
            numbers.AddNumber(10);
            numbers.AddNumber(20);
            numbers.AddNumber(30);
            numbers.AddNumber(40);
            numbers.AddNumber(50);
            Console.WriteLine(numbers.GetNumber(3));


            var strings = new MyStringList();
            strings.AddString("A");
            strings.AddString("B");
            strings.AddString("C");
            strings.AddString("D");
            strings.AddString("E");


            Console.WriteLine(strings.GetString(3));
            Console.ReadLine();
        }
    }
}
