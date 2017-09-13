using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Media;



// Application Name: Drunk PC
//Description: Application that generates erratic mouse and keyboard movements and input, generates system sounds and fake dialogs to confuse the user.
//Topics:
//1.) Threads
//2.) System.Windows.Forms namespaces & assembly
//3.) Hidden Application
//


namespace DrunkPC
{
    class Program
    {
        public static Random _random = new Random();

        public static int _startupDelaySeconds = 10;
        public static int _totalDuationSeconds = 30;

        /// <summary>
        /// Entry point for prank application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("DrunkPC prank application by Carl Hamilton");
            //check for command line arguments and assign new values 
            if( args.Length >= 2 )
            {
                _startupDelaySeconds = Convert.ToInt32(args[0]);
                _totalDuationSeconds = Convert.ToInt32(args[1]);
            }

            //All threads that manipulates input and outputs
            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouseThread));
            Thread drunkKeyboardThread = new Thread(new ThreadStart(DrunkKeyboardThread));
            Thread drunkSoundThread = new Thread(new ThreadStart(DrunkSoundThread));
            Thread drunkPopupThread = new Thread(new ThreadStart(DrunKPopupThread));


            DateTime future = DateTime.Now.AddSeconds(_startupDelaySeconds);

            while (future > DateTime.Now)
            {
            Thread.Sleep(1000);
             }
            //Start the created threads
            drunkMouseThread.Start();
            drunkKeyboardThread.Start();
            drunkSoundThread.Start();
            drunkPopupThread.Start();

            //Await user input
          future = DateTime.Now.AddSeconds(_totalDuationSeconds);
           while (future > DateTime.Now)
                {
                     Thread.Sleep(1000);
            }

            //Kill Threads following user selection
            drunkMouseThread.Abort();
            drunkKeyboardThread.Abort();
            drunkSoundThread.Abort();
            drunkPopupThread.Abort();
                                                                                                                                                                                                                 
        }
        #region Thread Functions

        /// <summary>
        /// This thread will affect mouse movemenets to trick the end user
        /// </summary>
        public static void DrunkMouseThread()
        {
            Console.WriteLine("DrunkMouseThread Started");

            int moveX = 0;
            int moveY = 0;

            while (true)
            {
                //Console.WriteLine(Cursor.Position.ToString());

               moveX= _random.Next(20) - 10;
               moveY = _random.Next(20) - 10;
              
               
                //Change muse position to new random coordinates
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X + moveX, Cursor.Position.Y + moveY);

                Thread.Sleep(50);

            }

        }
        /// <summary>
        /// This will generate random keyboard output to trick the end user
        /// </summary>
        public static void DrunkKeyboardThread()
        {
            Console.WriteLine("DrunkKeyboardThread Started");

            while (true)
            {
                char key = (char)(_random.Next(25)+65);

                SendKeys.SendWait(key.ToString());
                Thread.Sleep(_random.Next(500));

            }
        }
        /// <summary>
        /// Play system sounds to upset the user
        /// </summary>
        public static void DrunkSoundThread()
        {
            Console.WriteLine("DrunkSoundThread Started");
            while (true)
            {
                if(_random.Next(100) > 80)
                {
                    switch(_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;


                    }
                }
            
                Thread.Sleep(100);

            }

        }

        public static void DrunKPopupThread()
        {
            Console.WriteLine("DrunkPopupThread Started");
            while (true)
            {
                //every 10 seconds roll the dice
                if (_random.Next(100) > 90)
                {
                    switch(_random.Next(2))
                    {
                        case 0:
                            MessageBox.Show("Internet Explorer has stopped working",
                   "Internet Explorer",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                            break;
                        case 1:
                            MessageBox.Show("Your system is running low on resources",
                   "Microsoft Windows",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                            break;
                       

                        
                    }
                    Thread.Sleep(5000);
                   
                }

                

            }

        }
        #endregion
    }
}
