using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;

namespace Jarvis
{
    class Program
    {
        private static SpeechSynthesizer synth = new SpeechSynthesizer();
        static void Main(string[] args)
        {
            List<string> cpuMaxOutMessages = new List<string>();
            cpuMaxOutMessages.Add("Warning your CPU will catch fire!");
            cpuMaxOutMessages.Add("oh my god you should not run your CPU that hard");
            cpuMaxOutMessages.Add("stop downloading porn it is maxing me out");
            cpuMaxOutMessages.Add("I am dying save me");

            Random rand = new Random();
            //Greats the user in the default voice

            synth.Speak("Welcome to Jarvis one point o");

            //This will pull the current CPU load in %
            PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            perfCpuCount.NextValue();
            //This will pull the current available memory in Megabytes
            PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");
            perfMemCount.NextValue();

            //How long system has been online as seconds
            PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time");
            perfUptimeCount.NextValue();
            TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUptimeCount.NextValue());

            string systemUptimeMessage = string.Format("The current system up time is {0} days {1} hours {2} minutes {3} seconds",
               (int)uptimeSpan.TotalDays,
               (int)uptimeSpan.Hours,
               (int)uptimeSpan.Minutes,
               (int)uptimeSpan.Seconds);

            synth.Speak(systemUptimeMessage);
            bool isChromeOpenAlready = false;

            while (true)
            {

               int currentCpuPercentage = (int)perfCpuCount.NextValue();
               int currentAvailableMemory = (int)perfMemCount.NextValue();
                //Every 1 second show CPU load in percentage.

                Console.WriteLine("CPU Load: {0}%", currentCpuPercentage);
                Console.WriteLine("Available Memory: {0}MB",
                    currentAvailableMemory);
                //  Console.WriteLine("Available Memory: {0}MB", perfUptimeCount.NextValue());

                
               
                if (currentCpuPercentage > 80)
                {
                    if ( currentCpuPercentage ==100)
                    {
                        //Speak to user to advise of current values.


                        string cpuLoadVocalMessage = cpuMaxOutMessages[rand.Next(4)];

                        
                        if (isChromeOpenAlready == false)
                        {
                            OpenWebsite("https://www.youtube.com/watch?v=oHg5SJYRHA0");
                            isChromeOpenAlready = true;

                        }
                        Speak(cpuLoadVocalMessage, VoiceGender.Female, 1);
                    }
                    else
                    {
                        //Speak to user to advise of current values.
                        string cpuLoadVocalMessage = string.Format("The current CPU load is {0} percent", currentCpuPercentage);

                        Speak(cpuLoadVocalMessage, VoiceGender.Male, 7);
                    }
                    
          
                }
                //Only tell if memory is below 1GB
                if (currentAvailableMemory <1024)
                {
                   string memAvailableVocalMessage = string.Format("You currently have {0} megabytes of available memory", currentAvailableMemory);
                    Speak(memAvailableVocalMessage, VoiceGender.Male);

                }
                

                Thread.Sleep(1000);
                //Sleeps at the end

            }
        }
        public static void Speak(string message, VoiceGender voiceGender)
        {
            synth.SelectVoiceByHints(voiceGender);
            synth.Speak(message);

        }
        public static void Speak(string message, VoiceGender voiceGender, int rate)
        {
            synth.Rate = rate;
            Speak(message, voiceGender);

        }
        public static void OpenWebsite(string URL)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = "chrome.exe";
            p1.StartInfo.Arguments = URL;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            p1.Start();
        }
    }
}