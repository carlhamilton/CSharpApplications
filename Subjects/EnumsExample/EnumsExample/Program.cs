using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsExample
{

    /// <summary>
    ///  Enum is used to store values - consider like a variable.
    /// </summary>

    public enum myEnums
    {

        // We set constant list of values this is an enum
        Unknown = 0,
        MyValue1 = 1,
        MyValue2 = 2,
        MyValue3 = 3
    }

    public enum AnimationDirection
    {
        Unknown = 0,
        Left = 1,
        Right = 2,
        Up = 3,
        Down = 4
    }
    [Flags]
    public enum userPermissions
    {
        ReadBlogs = 0x1,
        WriteBlogs =0x2,
        DeleteBlogs = 0x4,
        CreateUsers = 0x8,
        A = 0x10,
        B = 0x20,
        C = 0x40,

    }
    class Program
    {
        static void Main(string[] args)
        {
            // What are enums?
            int i = default(int);
            var a = myEnums.MyValue1;
            var L = AnimationDirection.Left;
            // Different Base Types
            var myInt = (int)myEnums.MyValue2;
            var myDInt = (int)AnimationDirection.Up;

            // Where to use them?

            Animate(AnimationDirection.Right);

            // Casting to/from int / type

            var LAsInt = (int)L;
            var LBackAsItSelf = (AnimationDirection)LAsInt;

            var directCreate = (AnimationDirection)4;

            // Parsing from string name
            var enumAsName = L.ToString();


            if (Enum.TryParse<AnimationDirection>(enumAsName, out AnimationDirection enumFromString))
            {
                Console.WriteLine($"Successfully converted to {enumFromString}");
            }
            else
                Console.WriteLine($"Failed to convert {enumAsName}");





            // Enumerating the enum

            foreach (var val in Enum.GetValues(typeof(AnimationDirection)))
                 Console.WriteLine(val);
            foreach (var val in Enum.GetNames(typeof(AnimationDirection)))
                Console.WriteLine(val);
            var name1 = Enum.GetName(typeof(AnimationDirection), L);

            // Flags

            var permissions = userPermissions.ReadBlogs | userPermissions.CreateUsers;

            var nextPermission = (userPermissions)37;

            if((permissions & userPermissions.DeleteBlogs) == userPermissions.DeleteBlogs)
            {
                // use case if they have permission to delete blogs.
            }

            Console.Write(permissions);
            Console.WriteLine($"\n---------");
            Console.Write(nextPermission);



            Console.Read();
        }
        public static void Animate(AnimationDirection direction
            )
        {
            switch (direction)
            {
                case AnimationDirection.Left:
                    Console.WriteLine("Animating Left...");
                    break;
                case AnimationDirection.Right:
                    Console.WriteLine("Animating Right...");
                    break;
                case AnimationDirection.Up:
                    Console.WriteLine("Animating Up...");
                    break;
                case AnimationDirection.Down:
                    Console.WriteLine("Animating Down...");
                    break;
                default:
                    Console.WriteLine("I don't know what to do");
                    break;

            }
        }
    }
}
