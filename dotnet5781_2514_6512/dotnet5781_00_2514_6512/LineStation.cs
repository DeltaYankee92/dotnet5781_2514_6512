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
        //distance from the previous station
        public double distance;

        //Travel time from the previous station
        public TimeSpan time;

        public double getdistance()
        {
            return distance;
        }

        public double gettime()
        {
            return time.TotalSeconds;
        }

        internal LineStation()
        {
            distance = -1;
            time = new TimeSpan(0, 0, 0);
        }

        internal LineStation(int i1, float f1, float f2, string str)
        {
            BusStationKey = i1;
            Latitude = f1;
            Longitude = f2;
            adress = str;
        }
        internal LineStation(double d, double x, int i1, double f1, double f2, string str)
        {
            distance = d;
            time = Convert_to_time(x);
            this.BusStationKey = i1;
            this.adress = str;
            this.Latitude = f1;
            this.Longitude = f2;
        }

        private TimeSpan Convert_to_time(double x)
        {
            int y = (int)x;
            int Hour, Minute, Second;
            Second = y % 60;
            y = y - Second;
            Minute = y % 60;
            y = y - Minute*60;
            Hour = y % 24;

            return new TimeSpan(Second,Minute,Hour);
        }
    }
}
