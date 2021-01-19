

using DLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class AllData
    {
        public static List<BusStop> List_BusStop;
        public static List<BusLine> List_BusLine;
        public static List<Bus> List_Bus;
        public static List<LineStation> List_LineStation;
        public static List<LineCycle> List_LineCycle;
        public static List<Moving_bus> List_Moving_bus;
        public static List<Twostops> List_Twostops;
        static AllData()
        {
            start_bus();

            start_busStop();
            start_LineCycle();
            start_LineStation();
            start_Moving_bus();
            start_TwoStops();
            start_busLine();
        }

        #region Bus Database Initialization
        static void start_bus()
        {
            Bus b1 = new Bus(new int[] { 1, 4, 2, 7, 9, 7, 4, 0 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b2 = new Bus(new int[] { 2, 5, 3, 8, 9, 7, 4, 1 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b3 = new Bus(new int[] { 3, 6, 4, 9, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b4 = new Bus(new int[] { 4, 7, 5, 0, 9, 7, 4, 3 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b5 = new Bus(new int[] { 5, 8, 6, 1, 9, 7, 4, 4 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b6 = new Bus(new int[] { 6, 9, 7, 2, 9, 7, 4, 5 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b7 = new Bus(new int[] { 7, 0, 8, 3, 9, 7, 4, 6 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b8 = new Bus(new int[] { 8, 1, 9, 4, 9, 7, 4, 7 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b9 = new Bus(new int[] { 9, 2, 0, 5, 9, 7, 4, 8 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b10 = new Bus(new int[] { 0, 3, 1, 6, 9, 7, 4, 9 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b11 = new Bus(new int[] { 1, 4, 2, 7, 9, 7, 4, 0 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b12 = new Bus(new int[] { 2, 5, 3, 8, 9, 7, 4, 1 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b13 = new Bus(new int[] { 3, 6, 4, 9, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b14 = new Bus(new int[] { 4, 7, 5, 0, 9, 7, 4, 3 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b15 = new Bus(new int[] { 5, 8, 6, 1, 9, 7, 4, 4 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b16 = new Bus(new int[] { 6, 9, 7, 2, 9, 7, 4, 5 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b17 = new Bus(new int[] { 7, 0, 8, 3, 9, 7, 4, 6 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b18 = new Bus(new int[] { 8, 1, 9, 4, 9, 7, 4, 7 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b19 = new Bus(new int[] { 9, 2, 0, 5, 9, 7, 4, 8 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b20 = new Bus(new int[] { 0, 3, 1, 6, 9, 7, 4, 9 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            List_Bus = new List<Bus>();
            List_Bus.Add(b1);
            List_Bus.Add(b2);
            List_Bus.Add(b3);
            List_Bus.Add(b4);
            List_Bus.Add(b5);
            List_Bus.Add(b6);
            List_Bus.Add(b7);
            List_Bus.Add(b8);
            List_Bus.Add(b9);
            List_Bus.Add(b10);
            List_Bus.Add(b11);
            List_Bus.Add(b12);
            List_Bus.Add(b13);
            List_Bus.Add(b14);
            List_Bus.Add(b15);
            List_Bus.Add(b16);
            List_Bus.Add(b17);
            List_Bus.Add(b18);
            List_Bus.Add(b19);
            List_Bus.Add(b20);
        }
        #endregion

        #region BusStop Database Initialization

        internal static void start_busStop()
        {
            BusStop s1 = new BusStop(2595, 31.76003, 35.18315, "Kadish Luz 8-16, Jerusalem");
            BusStop s2 = new BusStop(2592, 31.75837, 35.18602, "Perets Bernstein 19-1, Jerusalem");
            BusStop s3 = new BusStop(2783, 31.75919, 35.18730, "David P Merets St 22, Jerusalem");
            BusStop s4 = new BusStop(1518, 31.75913, 35.18918, "Peretz Bernstein/Nezer David, Jerusalem");
            BusStop s5 = new BusStop(6273, 31.76228, 35.19157, "Barukh Duvdevani St 40, Jerusalem");
            List_BusStop.Add(s1);
            List_BusStop.Add(s2);
            List_BusStop.Add(s3);
            List_BusStop.Add(s4);
            List_BusStop.Add(s5);
        }
        #endregion

        internal static void start_busLine()
        {
            BusLine Line1 = new BusLine(List_BusStop[0], List_BusStop[4], 21, "Ramat Sharet");
        }
        internal static void start_LineStation()   
        {
            LineStation ls1 = new LineStation(List_BusStop[0], 400, TimeSpan.FromMinutes(2));
            LineStation ls2 = new LineStation(List_BusStop[1], 500, TimeSpan.FromMinutes(4));
            LineStation ls3 = new LineStation(List_BusStop[2], 350, TimeSpan.FromMinutes(2));
            LineStation ls4 = new LineStation(List_BusStop[3], 600, TimeSpan.FromMinutes(3));
            LineStation ls5 = new LineStation(List_BusStop[4], 200, TimeSpan.FromMinutes(6));
        }
        internal static void start_LineCycle()
        {

        }
        internal static void start_Moving_bus()
        {

        }
        internal static void start_TwoStops()
        {

        }

    }
}
