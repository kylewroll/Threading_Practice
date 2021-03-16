using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread_Practice
{
    class FindPiThread
    {
        int darts;
        int darts_inside;
        Random rand;

        public FindPiThread(int darts)
        {
            this.darts = darts;
            darts_inside = 0;
            rand = new Random();
        }

        public int getDartsInside()
        {
            return darts_inside;
        }

        public void throwDarts ()
        {
            double x;
            double y;
            double hyp;


            for (int ctr = 0;  ctr < darts; ctr ++)
            {
                x = rand.NextDouble();
                y = rand.NextDouble();

                hyp = Math.Sqrt((x * x) + (y * y));

                if (hyp <= 1)
                {
                    darts_inside++;
                }
            }
        }
    }
}
