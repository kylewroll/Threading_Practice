/* Author: Kyle Rolland
 * Date: 3/16/2021
 * File: Program.cs
 * Description: Main driver for program, prompts user for darts throws and number of threads, makes and runs threads, then uses results to calculate estimate of pi
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Thread_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //number of darts inside circle, used at end of main
           double dartsInside = 0;

            //used for measuring execution time, usage of stopwatch taken from https://www.tutorialsteacher.com/articles/how-to-calculate-code-execution-time-in-csharp
            var watch = new System.Diagnostics.Stopwatch();

            //used for while loop
            int stop = 0;

            while (stop != 1)
            {
                //ask for how many darts to throw
                Console.WriteLine("Please enter how many darts to be thrown: ");
                int darts = Convert.ToInt32(Console.ReadLine());

                //ask for how many threads to be ran
                Console.WriteLine("Please enter how many threads to be ran: ");
                int numThreads = Convert.ToInt32(Console.ReadLine());

                //resets and starts stopwatch
                watch.Reset();
                watch.Start();

                //create list of threads based on number of threads
                List<Thread> threads = new List<Thread>();
                threads.Capacity = numThreads;

                //create list of FindPiThreads based on number of threads
                List<FindPiThread> piThreads = new List<FindPiThread>();
                piThreads.Capacity = numThreads;


                //loop that ties threads together and runs throwDarts
                for (int ctr = 0; ctr < numThreads; ctr++)
                {
                    FindPiThread piThread = new FindPiThread(darts);

                    piThreads.Add(piThread);

                    Thread dartsThread = new Thread(new ThreadStart(piThread.throwDarts));

                    threads.Add(dartsThread);

                    dartsThread.Start();

                    //pauses main, ensures random numbers are all random
                    Thread.Sleep(16);
                }


                //loops over every item in threads and joins them together, causes main to wait till all threads are done
                for (int ctr = 0; ctr < threads.Count; ctr++)
                {
                    threads[ctr].Join();
                }

                //loops over every item in piThreads and calls getDartsInside to get number of darts inside the circle
                for (int ctr = 0; ctr < piThreads.Count; ctr++)
                {
                    dartsInside = piThreads[ctr].getDartsInside();
                }

                //prints calculated value of pi
                Console.WriteLine("Value of Pi: " + (4 * (dartsInside / darts)));

                //ends stopwatch
                watch.Stop();

                //prints time elapsed for program
                Console.WriteLine("Runtime: " + watch.ElapsedMilliseconds + " ms");

                //lets user choose if they wish to stop program
                Console.WriteLine("If you would like to exit the program, enter 1. Otherwise, the program will run again.");
                stop = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
