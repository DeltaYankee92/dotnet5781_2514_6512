
using DalApi.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class AllData
    { // there is no list of bus stops.
        public static List<BusLine> List_BusLine;
        public static List<Bus> List_Bus;
        public static List<LineStation> List_LineStation;
        public static List<LineCycle> List_LineCycle;
        public static List<Moving_bus> List_Moving_bus;
        public static List<Twostops> List_Twostops;
        static AllData()
        {
            start();
        }

         static void start() 
        {
            List_Bus = new List<Bus>();
        }
    }
}
