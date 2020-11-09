using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{
    class LineStation : BusStop
    {
        BusStop Stop;
        //distance from the previous station
        public double Distance { get; set; }

        //Travel time from the previous station
        public TimeSpan TravelTime { get; set; }

        internal LineStation()
        {
            Distance = -1;
            TravelTime = new TimeSpan(0, 0, 0);
        }

        internal LineStation(BusStop s, double d, TimeSpan t )
        {
            Stop = s;
            Distance = d;
            TravelTime = t;
        }

    }
}
