using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitWiseOperators
{
    public enum SomeValues
    {
        Red = 1,
        Blue = 2,
        Green = 4,
        Black = 8,
        White = 16,
        Orange = 32,
        Yellow = 64,
        Pink = 128,
    }
    class Program
    {
        static void Main(string[] args)
        {
            //
            //  Binary
            //
            //


            var a = 25;
            var b = 7;

            var result = a & b;

            Console.WriteLine($"Result = {Convert.ToString(a, 2).PadLeft(8,'0')}");
            Console.WriteLine($"Result = {Convert.ToString(b, 2).PadLeft(8, '0')}");
            Console.WriteLine($"Result = {Convert.ToString(result, 2).PadLeft(8, '0')}"); // compares the bits where they are the same and then gives the answer as in this case the only occurance is when both a and b is 1.

            Console.WriteLine($"-------");






            //
            // Bitwise operators
            //
            // And  & (Both)
            // Or  | (Either)
            // Xor  ^ (Exclusive or, different)
            // Not  ~ (Invert)
            //
            //
            // Bitwise Shifting
            //
            // Left   <<
            // Right  >>
            //

            byte c = 25;
            var cResult = (byte)(c << 1);
            Console.WriteLine($"Result = {Convert.ToString(c, 2).PadLeft(8, '0')}");
            Console.WriteLine($"-------");
            Console.WriteLine($"Result = {Convert.ToString(cResult, 2).PadLeft(8, '0')}");
            Console.WriteLine($"-------");


            //
            // Usage
            //
            // Toggling boolean
            // Enum flags
            // Masking
            //
            var d = true;

            d ^= true;

            //Enum flag
            var someVals = (byte)(SomeValues.Blue | SomeValues.White);
            Console.WriteLine($" {Convert.ToString((byte)someVals, 2).PadLeft(8, '0')}");

            if ((someVals & (byte)SomeValues.Blue) == (byte)SomeValues.Blue)
                Console.WriteLine("Blue was included");
            if ((someVals & (byte)SomeValues.White) == (byte)SomeValues.White)
                Console.WriteLine("White was included");

            Console.WriteLine($"-------");

            //Masking
            // ------0- Input
            // 00000010 < important bit
            // Clear everything except what is in the mask of what you need
            // Pass value you expect 
            // result of this would be 00000000

            var input = (byte)SomeValues.White | (byte)SomeValues.Blue;
            var mask = (byte)SomeValues.Blue;
            var r = input & mask;
            Console.WriteLine($"Result is: {Convert.ToString(r, 2).PadLeft(8, '0')}"); 






            Console.ReadLine();

        }
    }
}
