using System.Collections.Generic;

namespace Covariance
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello, World!";
            object obj = str;

            var strList = new List<string> {"Monday", "Tuesday"};
            //List<object> objList = strList;
            IEnumerable<object> objEnum = strList; //covariance safe as it is unable to break the collection as it is read only.

            //var strList = new string[] { "Monday", "Tuesday" };
            // object[] objList = strList; // array covariance but is a bad idea to use and can be broken when setting values due to type of variable that is not a string.

        }
    }
}
