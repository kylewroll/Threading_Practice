using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //number of darts inside circle, used at end of main
            int dartsInside = 0;

            //ask for how many darts to throw
            Console.WriteLine("Please enter how many darts to be thrown: ");
            int darts = Convert.ToInt32(Console.ReadLine());

            //ask for how many threads to be ran
            Console.WriteLine("Please enter how many threads to be ran: ");
            int numThreads = Convert.ToInt32(Console.ReadLine());

            //create list of threads based on number of threads
            List<Thread> threads = new List<Thread>(numThreads);

            //create list of FindPiThreads based on number of threads
            List<FindPiThread> piThreads = new List<FindPiThread>(numThreads);


            //loop that ties threads together and runs throwDarts
            for (int ctr = 0; ctr < numThreads; ctr++)
            {
                FindPiThread find = new FindPiThread(darts);

                piThreads.Add(find);

                Thread dartsThread = new Thread(new ThreadStart(find.throwDarts));

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

            Console.WriteLine("Value of Pi: " + (4 * (dartsInside / darts)));
        }
    }
}
