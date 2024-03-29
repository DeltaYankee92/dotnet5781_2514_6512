﻿using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL.BO
{
    public class LineStation : BusStop
    {

        #region fields, get
        //distance from the previous station
        public double distance { get; set; }

        //Travel time from the previous station
        public TimeSpan time { get; set; }

        public double getdistance()
        {
            return distance;
        }

        public override void fillfields()
        {
            Console.WriteLine(@"we are now filling fields.
            for entering a key, please enter a number. note, that the key '0' leads to a function of the print function.
");
            int x = inputKey();
            if (x == 0)
            {
                this.BusStationKey = x;
                return;
            }
            double y = inputLatitude();
            this.Latitude = y;
            y = inputLongitude();
            this.Longitude = y;
            Console.WriteLine("enter the adress");
            string str = Console.ReadLine();
            this.Adress = str;
            Console.WriteLine("enter distance from previous station");
            double temp;
            bool parse_success;
            parse_success = double.TryParse(Console.ReadLine(), out temp);
            this.distance = temp;
            Console.WriteLine("enter a number of seconds from previous station");
            parse_success = int.TryParse(Console.ReadLine(), out x);
            this.time = this.Convert_to_time((double)x);
        }


        public double gettime()
        {
            return time.TotalSeconds;
        }
        #endregion

        #region ctor
        public LineStation()
        {
            this.distance = -1;
            this.time = new TimeSpan(0, 0, 0);
        }

        internal LineStation(int i1, double f1, double f2, string str)
        {
            BusStationKey = i1;
            Latitude = f1;
            Longitude = f2;
            Adress = str;
        }
        internal LineStation(double d, double x, int i1, double f1, double f2, string str)
        {
            distance = d;
            time = Convert_to_time(x);
            this.BusStationKey = i1;
            this.Adress = str;
            this.Latitude = f1;
            this.Longitude = f2;
        }
        #endregion

        #region conversions
        private TimeSpan Convert_to_time(double x)
        {
            int y = (int)x;
            int Hour, Minute, Second;
            Second = y % 60;
            y = y - Second;
            Minute = y % 60;
            y = y - Minute * 60;
            Hour = y % 24;

            return new TimeSpan(Second, Minute, Hour);
        }

        #endregion
    }
}
