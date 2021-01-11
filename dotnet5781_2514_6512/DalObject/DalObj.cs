using DalApi.DO;
using DLAPI;
using DS;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DalObject
{
    sealed class DalObject : IDL // implamenting the interface
    {
        #region singleton
        static readonly DalObject instance = new DalObject();
        DalObject() { } //  ctor
        public static DalObject Idal { get => instance; } // connect via the singleton.
        #endregion

        #region static helpers
        static bool comparearr(int[] arr1, int[] arr2) // takes two arrays and compares thier value.
        {
            if (arr1.Length != arr2.Length)
                return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }
            return true;
        }

        #endregion

        #region bus_func

        // Crud
        public void addBus(Bus bus) // adding a Bus to the Line of Buses
        {
            Bus in_system = AllData.List_Bus.Find(bus2 => comparearr(bus2.licensePlateArray, bus.licensePlateArray)); // lambda with bus2 as the function
            if (in_system != null)
                throw new InsystemException("bus already in system");
            AllData.List_Bus.Add(bus.Clone()); // add the clone of the bus from the entry. not sure if this is needed however.
        }
        // cRud
        public Bus GetBus(int[] plate) // get the bus with the current plate. exceptions: if bus is in the system
        {
            Bus in_system = AllData.List_Bus.Find(bus => comparearr(bus.licensePlateArray, plate));
            if (in_system == null)
                throw new NotFoundException("No bus already in system");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("bus is not active");
            return in_system; // the Bus that was found in 'alldata'
        }
        public IEnumerable<Bus> GetAllBuses() // get all of the clones. Ienumerable<T> is easy
        {
            return from bus in AllData.List_Bus
                   where (bus!=null && bus.isactive == true)
                   select bus.Clone();
        }
        // crUd
        public void Details(Bus bus) // details changes the details
        {
            Bus in_system = AllData.List_Bus.Find(bus1 => comparearr(bus1.licensePlateArray, bus.licensePlateArray));
            if (in_system == null)
                throw new NotFoundException("No bus already in system");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("bus is not active");
            AllData.List_Bus.Remove(in_system);
            AllData.List_Bus.Add(bus.Clone()); // remove the one in the system, add the clone.

        }
        public void Fuel(int[] plate) // along with 2 actions
        {
            Bus in_system = AllData.List_Bus.Find(bus1 => comparearr(bus1.licensePlateArray, plate));
            if (in_system == null)
                throw new NotFoundException("No bus already in system");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("bus is not active");
            AllData.List_Bus.Remove(in_system);
            in_system.fuel_up();
            AllData.List_Bus.Add(in_system.Clone()); // remove the one in the system, add the clone.
        }
        public void Maintain(int[] plate)
        {
            Bus in_system = AllData.List_Bus.Find(bus1 => comparearr(bus1.licensePlateArray, plate));
            if (in_system == null)
                throw new NotFoundException("No bus already in system");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("bus is not active");
            AllData.List_Bus.Remove(in_system);
            in_system.fix();
            AllData.List_Bus.Add(in_system.Clone()); // remove the one in the system, add the clone.
        }
        // crUd
        public void removeBus(int[] plate) 
        {
            Bus in_system = AllData.List_Bus.Find(bus => comparearr(bus.licensePlateArray, plate));
            if (in_system == null)
                throw new NotFoundException("No bus already in system");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("bus is not active");
            AllData.List_Bus.Remove(in_system); // remove the bus found. no need to clone, as we are removing

            in_system.Word_activity("inactive");
            AllData.List_Bus.Add(in_system.Clone()); // remove the one in the system, add the clone.
        }
        #endregion

        #region Line_func
        // Crud
        public void AddBusLine(BusLine line)
        {
            BusLine in_system = AllData.List_BusLine.Find(line1 => line.BusNumber == line1.BusNumber);
            if (in_system != null)
                throw new InsystemException("Can't add line. already in system");
            AllData.List_BusLine.Add(line.Clone());
        }
        //cRud
        public IEnumerable<BusLine> GetAllBusLines() // the function for all buslines
        {
            return from line in AllData.List_BusLine
                   where (line != null && line.isactive == true)
                   select line.Clone();
        }
        public BusLine GetBusLine(int linenum) // the num here is a number, and not an array.
        { // Crud
            BusLine in_system = AllData.List_BusLine.Find(line1 => linenum == line1.BusNumber);
            if (in_system == null)
                throw new NotFoundException("No line to get");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("line is not active");
            return in_system.Clone();
        }

        public void Details_Line(BusLine line) // crUd
        {
            BusLine in_system = AllData.List_BusLine.Find(line1 => line.BusNumber == line1.BusNumber);
            if (in_system == null)
                throw new NotFoundException("No line to update details");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("line is not active");
            AllData.List_BusLine.Remove(in_system.Clone());
            AllData.List_BusLine.Add(line.Clone());
        }
        public void RemoveBusLine(int linenum) // cruD
        {
            BusLine in_system = AllData.List_BusLine.Find(line1 => linenum == line1.BusNumber);
            if (in_system == null)
                throw new NotFoundException("No line to remove");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("line is not active");

            AllData.List_BusLine.Remove(in_system);
            in_system.Word_activity("inactive");
            AllData.List_BusLine.Add(in_system);
        }
        #endregion

        #region LineStation_func
        public void addStation(LineStation line)
        {
            LineStation in_system = AllData.List_LineStation.Find(line1 => line.BusStationKey == line1.BusStationKey);
            if (in_system != null)
                throw new InsystemException("Line in the system");
            AllData.List_LineStation.Add(line.Clone());
        }
        public IEnumerable<LineStation> GetLines()
        {
            return from lines in AllData.List_LineStation
                   where (lines != null && lines.isactive == true)
                   select lines.Clone();
        }
        public LineStation GetLineStation(int linenum) // get the line station with the i.d there.
        {
            LineStation in_system = AllData.List_LineStation.Find(bus1 => bus1.BusStationKey == linenum);
            if (in_system == null)
                throw new NotFoundException("No line to get");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("stops are not active");
            return in_system;
        }

        public void Details_LineStation(LineStation line) // crUd
        {
            LineStation in_system = AllData.List_LineStation.Find(bus1 => bus1.BusStationKey == line.BusStationKey);
            if (in_system == null)
                throw new NotFoundException("No stops to remove");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("stops are not active");
            AllData.List_LineStation.Remove(in_system);
            AllData.List_LineStation.Add(line.Clone()); // remove the one in the system, add the clone.
        }
        public void removeLineStation(int linenum) // cruD
        {
            LineStation in_system = AllData.List_LineStation.Find(line1 => linenum == line1.BusStationKey);
            if (in_system == null)
                throw new NotFoundException("No stops to remove");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("stops are not active");
            AllData.List_LineStation.Remove(in_system);

            in_system.Word_activity("inactive");
            AllData.List_LineStation.Add(in_system);
        }

        #endregion
    }
}
