using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{


    /*
     a class that acts as a single bus stop, regardless of its' lines.
     */
    class BusStop
    {
        public int BusStationKey;
        public double Latitude;
        public double Longitude;
        public string adress;

        internal int getkey() // return the key value.
        {
            return this.BusStationKey;
        }

        public double getlatitute()// return the Latitude value.
        {
            return this.Latitude;
        }
        public double getlongitude()// return the Longitude value.
        {
            return this.Latitude;
        }
        public string getadress()// return the adress value.
        {
            return this.adress;
        }
        internal BusStop() // ctor
        {
            BusStationKey = -1;
            adress = "";
            Latitude = -1;
            Longitude = -1;
        }

        internal BusStop(int i1, float f1, float f2, string str) //ctor
        {
            this.BusStationKey = i1;
            this.adress = str;
            this.Latitude = f1;
            this.Longitude = f2;
        }
        internal static int inputKey() // adding a key in a nice way
        {
            Console.WriteLine("enter the key of a bus stop: ");
            int temp;
            bool parse_success;
            parse_success = int.TryParse(Console.ReadLine(), out temp);
            if (temp >= 0 && temp <= 999999)
                return temp;
            else
                throw new ArgumentException("key not valid. a key must be 6 digits");
        }

        internal static double inputLatitude()// adding coordinates in a nice way
        {
            Console.WriteLine("enter the Latitude of a bus stop: ");
            double temp;
            bool parse_success;
            parse_success = double.TryParse(Console.ReadLine(), out temp);

            if (parse_success == true)
                parse_success = check_range(90,temp);
            else
                throw new ArgumentException("Latitude not valid. must be a number between -90 and 90");
            return -1;
        }

        internal static double inputLongitude()// adding coordinates in a nice way
        {
            Console.WriteLine("enter the Longitude of a bus stop: ");
            double temp;
            bool parse_success;
            parse_success = double.TryParse(Console.ReadLine(), out temp);

            if (parse_success == true)
                parse_success = check_range(180, temp);
            else
                throw new ArgumentException("Longitude not valid. must be a number between -180 and 180");

            return -1;
        }
        private static bool check_range(int v , double d) // temporary function for input checking.
        {
            if (d == 0)
                return true;
            if (d < 0)
                d = d * (-1);
            if (v > d)
                return true;
            else
                return false;
        }
        public virtual void fillfields() // filling the fields in a convenient way
        {
            int x = inputKey();
            this.BusStationKey = x;
            double y = inputLatitude();
            this.Latitude = y;
            y = inputLongitude();
            this.Longitude = y;
            Console.WriteLine("enter the adress");
            string str = Console.ReadLine();
            this.adress = str;
        }
        public override string ToString() // derisa of tostring.
        {
            return $"Bus Station Code: {this.BusStationKey}, {this.Latitude}°N, {this.Longitude}°E";
        }

   
    }
}
