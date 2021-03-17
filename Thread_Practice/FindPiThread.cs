/* Author: Kyle Rolland
 * Date: 3/16/2021
 * File: FindPiThread.cs
 * Description: Creates FindPiThread class, which contains the thread function that is used by the threads in Program.cs, and can return the amount of darts that have landed inside the circle
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread_Practice
{
    class FindPiThread
    {
        //total darts to be thrown
        int darts;

        //number of darts that land inside circle
        int dartsInside;

        //random variable for generating x and y coordinate values
        Random rand;

        //parameterized constructor, sets darts to user's input, dartsInside to 0, and generates new random variable
        public FindPiThread(int darts)
        {
            this.darts = darts;
            dartsInside = 0;
            rand = new Random();
        }

        //accessor used in threads to calculate pi value
        public int getDartsInside()
        {
            return dartsInside;
        }

        //function used by threads to throw darts and determine whether they have landed in the circle or not
        public void throwDarts ()
        {
            //x-coordinate
            double x;

            //y-coordinate
            double y;

            //hypotenuse between x and y coordinates
            double hyp;

            //loops over all darts to be thrown, generating x and y coordinates, then finds hypotenuse, if 1 or less, increments dartsInside
            for (int ctr = 0;  ctr < darts; ctr++)
            {
                //randomly generates x value between 0 and 1
                x = rand.NextDouble();

                //randomly generates y value between 0 and 1
                y = rand.NextDouble();

                //squares x and y, adds them together, then takes the square root
                hyp = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

                //determines whether or not to increment dartsInside
                if (hyp <= 1)
                {
                    dartsInside++;
                }
            }
        }
    }
}
