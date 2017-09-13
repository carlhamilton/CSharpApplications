using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _8Ball
{
    /// <summary>
    /// Entry Point for Magic 8 Ball
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Preserve current console text colour
            ConsoleColor oldColor = Console.ForegroundColor;

            TellPeopleWhatProgramThisIS();

            //create a radomizer object
            Random randomObject = new Random();


            while (true)
            {
                string questionString = GetQuestionFromUser();

                int numberOfSecondsToSleep = randomObject.Next(5) + 1;
                Console.WriteLine("Thinking about your answer, standby...");
                Thread.Sleep(numberOfSecondsToSleep * 1000);
               
                
                if (questionString.Length == 0)
                {
                    Console.WriteLine("You need to type a question!");
                    continue;

                }

                if (questionString.ToLower() == "quit")
                {
                    break;

                }



                //get random number
                int randNumber = randomObject.Next(4);

                //use randNumber to determine response
                switch(randNumber)
                {
                    case 0:
                        {
                            Console.WriteLine("Yes!");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("No!");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Hell No!");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("OMG Yes!");
                            break;
                        }
                }
            }




            //cleanup
            Console.ForegroundColor = oldColor;

        }
        /// <summary>
        /// Designed to show who made the program.
        /// </summary>
        static void TellPeopleWhatProgramThisIS()
        {
            //change console text colour
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Magic 8 Ball (by: Carl Hamilton)");

        }

        static string GetQuestionFromUser()
        {
            //This will ask the user a question
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ask a question? Or type quit to stop: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string questionString = Console.ReadLine();

            return questionString;
        }
    }
}
