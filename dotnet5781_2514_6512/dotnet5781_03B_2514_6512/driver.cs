using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet5781_03B_2514_6512
{
    class Driver
    {
        readonly int time_driving = 16;
        int time_total;

        public Driver()
        {
            time_total=0;
        }
       public int drive(int time)
        {
            int rest = time / 3; // if the time is above 3, we need to rest 15 mins per time

            if (rest == 0 && time_total + time < time_driving)
            {
                time_total += time;
                return time;
            }
            else if (time_total + time + rest * 15 < time_driving)
            {
                time_total += time + rest * 15;
                return time + rest * 15;
            }
            else
                throw new ArgumentException("can't make the drive");
        }
       public void night()
        {
            time_total = 0;
        }
    }
}
