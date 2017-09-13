using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] squares = {1, 4, 9, 16};

            int[] copy = new int[4];// We can use instale int[] copy = squares.ToArray(); which would do the same thing without having to specify squares.CopyTo
            squares.CopyTo(copy, 0);//

            foreach (int value in copy)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine(String.Format(
                "squares == copy? {0}", squares == copy));
            Console.ReadKey();
        }
    }
}
