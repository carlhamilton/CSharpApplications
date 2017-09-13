using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            float[][] temspsGrid = new float[4][];
            Console.WriteLine("The rank is: " + temspsGrid.Rank);
            Console.WriteLine("The length is: " + temspsGrid.Length);

            for (int x = 0; x < 4; x++)
            {
                temspsGrid[x] = new float[3];
                for (int y = 0; y < 3; y++)
                {
                    temspsGrid[x][y] = x + 10 * y;

                }
                
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Console.Write(temspsGrid[x][y] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
