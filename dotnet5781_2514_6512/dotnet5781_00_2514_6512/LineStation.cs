using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{
    class LineStation : BusStop
    {
        BusStop Stop;
        //distance from the previous station
        public double distance;

        //Travel time from the previous station
        public TimeSpan time;

        public double getdistance()
        {
            return distance;
        }

        public TimeSpan gettime()
        {
            return time;
        }

        internal LineStation()
        {
            distance = -1;
            time = new TimeSpan(0, 0, 0);
        }

        internal LineStation(BusStop s, double d, TimeSpan t )
        {
            Stop = s;
            distance = d;
            time = t;
        }

    }
}
