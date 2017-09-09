using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics2
{
    /// <summary>
    /// Generics stating a web response small example code
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public class APIWebResponse<TResponse>
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public TResponse Response { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Get number of friends
            var response = new APIWebResponse<int> { Success = true, Response = 1 };
            //Get my username
            var response2 = new APIWebResponse<string> { Success = true, Response = "Bobby" };

            var number = (response.Response);

            Console.ReadLine();

        }
    }
}
