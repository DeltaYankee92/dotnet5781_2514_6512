﻿
using DalApi.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class AllData
    {
        public static List<BusLine> List_BusLine;
        public static List<Bus> List_Bus;
        public static List<BusStop> List_BusStop;
        public static List<LineStation> List_LineStation;
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
