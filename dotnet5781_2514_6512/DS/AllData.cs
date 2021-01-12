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
            #region Bus Database Initialization
            BusList = new List<Bus>();
            Bus b1 = new Bus(new DateTime(2020, 01, 01), new int[] { 4, 1, 2, 5, 9, 7, 4, 1 }, 10000, 0, 10000, 2000);
            Bus b2 = new Bus(new DateTime(2020, 01, 01), new int[] { 5, 2, 2, 5, 9, 7, 4, 2 }, 10000, 0, 10000, 2000);
            Bus b3 = new Bus(new DateTime(2020, 01, 01), new int[] { 6, 3, 2, 5, 9, 7, 4, 3 }, 10000, 0, 10000, 2000);
            Bus b4 = new Bus(new DateTime(2020, 01, 01), new int[] { 7, 4, 2, 5, 9, 7, 4, 4 }, 10000, 0, 10000, 2000);
            Bus b5 = new Bus(new DateTime(2020, 02, 01), new int[] { 8, 5, 2, 5, 0, 7, 4, 5 }, 10000, 0, 10000, 2000);
            Bus b6 = new Bus(new DateTime(2020, 02, 15), new int[] { 9, 6, 2, 5, 1, 7, 4, 6 }, 10000, 0, 10000, 2000);
            Bus b7 = new Bus(new DateTime(2020, 02, 15), new int[] { 0, 7, 2, 5, 2, 7, 4, 7 }, 10000, 0, 10000, 2000);
            Bus b8 = new Bus(new DateTime(2020, 02, 23), new int[] { 1, 8, 2, 5, 3, 7, 4, 8 }, 10000, 0, 10000, 2000);
            Bus b9 = new Bus(new DateTime(2020, 01, 23), new int[] { 2, 9, 2, 5, 4, 7, 4, 9 }, 10000, 0, 10000, 2000);
            Bus b10 = new Bus(new DateTime(2020, 04, 10), new int[] { 3, 0, 2, 5, 5, 7, 4, 1 }, 10000, 0, 10000, 2000);
            Bus b11 = new Bus(new DateTime(2020, 04, 10), new int[] { 4, 1, 2, 5, 6, 7, 4, 2 }, 10000, 0, 10000, 2000);
            Bus b12 = new Bus(new DateTime(2020, 04, 10), new int[] { 5, 2, 2, 5, 7, 7, 4, 3 }, 10000, 0, 10000, 2000);
            Bus b13 = new Bus(new DateTime(2020, 04, 10), new int[] { 6, 3, 2, 5, 8, 7, 4, 4 }, 10000, 0, 10000, 2000);
            Bus b14 = new Bus(new DateTime(2020, 04, 10), new int[] { 7, 4, 2, 5, 9, 7, 4, 5 }, 10000, 0, 10000, 2000);
            Bus b15 = new Bus(new DateTime(2020, 04, 10), new int[] { 8, 5, 2, 5, 0, 7, 4, 6 }, 10000, 0, 10000, 2000);
            Bus b16 = new Bus(new DateTime(2020, 09, 01), new int[] { 9, 6, 2, 5, 1, 7, 4, 7 }, 10000, 0, 10000, 2000);
            Bus b17 = new Bus(new DateTime(2020, 09, 01), new int[] { 0, 7, 2, 5, 2, 7, 4, 8 }, 10000, 0, 10000, 2000);
            Bus b18 = new Bus(new DateTime(2020, 09, 01), new int[] { 1, 8, 2, 5, 3, 7, 4, 9 }, 10000, 0, 10000, 2000);
            Bus b19 = new Bus(new DateTime(2020, 09, 01), new int[] { 2, 9, 2, 5, 4, 7, 4, 0 }, 10000, 0, 10000, 2000);
            Bus b20 = new Bus(new DateTime(2020, 09, 01), new int[] { 3, 10, 2, 5, 5, 7, 4, 1 }, 10000, 0, 10000, 2000);
            BusList.Add(b1);
            BusList.Add(b2);
            BusList.Add(b3);
            BusList.Add(b4);
            BusList.Add(b5);
            BusList.Add(b6);
            BusList.Add(b7);
            BusList.Add(b8);
            BusList.Add(b9);
            BusList.Add(b10);
            BusList.Add(b11);
            BusList.Add(b12);
            BusList.Add(b13);
            BusList.Add(b14);
            BusList.Add(b15);
            BusList.Add(b16);
            BusList.Add(b17);
            BusList.Add(b18);
            BusList.Add(b19);
            BusList.Add(b20);
            #endregion

            BusLineList = new List<BusLine>();
            BusStopList = new List<BusStop>();
            LineStationList = new List<LineStation>();
             
        }
    }
}