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

        /*
         line station is a bus stop, but specifically in relation to the lines that come from it.
         */
        //distance from the previous station
        public double distance;

        //Travel time from the previous station
        public TimeSpan time;

        public double getdistance()
        {
            return distance;
        }

        public override void fillfields() // filling the fields in a convenient way
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
            this.adress = str;
            Console.WriteLine("enter distance from previous station");
            double temp;
            bool parse_success;
            parse_success = double.TryParse(Console.ReadLine(), out temp);
            this.distance = temp;
            Console.WriteLine("enter a number of seconds from previous station");
            parse_success = int.TryParse(Console.ReadLine(), out x);
           this.time = this.Convert_to_time((double)x);
        }


        public double gettime() // returns the time in seconds.
        {
            return time.TotalSeconds;
        }

        internal LineStation() //ctor
        {
            distance = -1;
            time = new TimeSpan(0, 0, 0);
        }

        internal LineStation(int i1, double f1, double f2, string str) // ctor
        {
            BusStationKey = i1;
            Latitude = f1;
            Longitude = f2;
            adress = str;
        }
        internal LineStation(double d, double x, int i1, double f1, double f2, string str)// ctor
        {
            distance = d;
            time = Convert_to_time(x);
            this.BusStationKey = i1;
            this.adress = str;
            this.Latitude = f1;
            this.Longitude = f2;
        }

        private TimeSpan Convert_to_time(double x) // taking a double and turning it into an int. used to deal with adding time.
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
