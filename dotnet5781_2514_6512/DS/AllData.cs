

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
            start_busLine();
            start_busStop();
            start_LineCycle();
            start_LineStation();
            start_Moving_bus();
            start_TwoStops();
        }

         static void start_bus() 
        {


            #region Bus Database Initialization
            List_Bus = new List<Bus>();
            Bus b1 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 },0,0,0,0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01),"ready");
            Bus b2 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b3 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b4 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b5 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b6 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b7 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b8 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b9 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b10 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b11= new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b12 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b13 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b14 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b15 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b16 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b17 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b18 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b19 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
            Bus b20 = new Bus(new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 0, 0, 0, 0, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), "ready");
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
            #endregion

        }

        internal static void start_busStop()
        {

        }
        internal static void start_busLine()
        {

        }
        internal static void start_LineStation()
        {

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
