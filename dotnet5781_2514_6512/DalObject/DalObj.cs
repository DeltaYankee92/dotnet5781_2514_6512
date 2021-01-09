using DalApi.DO;
using DLAPI;
using DS;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalObject
{
    sealed class DalObject : IDL // implamenting the interface
    {
        static readonly DalObject instance = new DalObject();

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
        public IEnumerable<Bus> GetAllBuses() // get all of the clones. Ienumerable<T> is easy
        {
            return from bus in AllData.List_Bus
                   select bus.Clone();
        }
        public Bus GetBus(int[] plate) // get the bus with the current plate. exceptions: if bus is in the system
        {
            Bus in_system = AllData.List_Bus.Find(bus => comparearr(bus.licensePlateArray, plate));
            if (in_system == null)
                throw new ArgumentException("No bus already in system");
            return in_system; // the Bus that was found in 'alldata'
        }
        public void addBus(Bus bus) // adding a Bus to the Line of Buses
        {
            Bus in_system = AllData.List_Bus.Find(bus2 => comparearr(bus2.licensePlateArray , bus.licensePlateArray)); // lambda with bus2 as the function
            if (in_system != null)
                throw new ArgumentException("Bus already in system");
            AllData.List_Bus.Add(bus.Clone()); // add the clone of the bus from the entry. not sure if this is needed however.
        }

        public void removeBus(int[] plate)
        {
            Bus in_system = AllData.List_Bus.Find(bus => comparearr(bus.licensePlateArray, plate));
            if (in_system == null)
                throw new ArgumentException("No bus already in system");
            AllData.List_Bus.Remove(in_system); // remove the bus found. no need to clone, as we are removing
        }
        public void Details(Bus bus) // details changes the details
        {
            Bus in_system = AllData.List_Bus.Find(bus1 => comparearr(bus1.licensePlateArray, bus.licensePlateArray));
            if (in_system == null)
                throw new ArgumentException("No bus already in system");
            AllData.List_Bus.Remove(in_system);
            AllData.List_Bus.Add(bus.Clone()); // remove the one in the system, add the clone.

        }
        public void Fuel(int[] plate) // along with 2 actions
        {
            Bus in_system = AllData.List_Bus.Find(bus1 => comparearr(bus1.licensePlateArray, plate));
            if (in_system == null)
                throw new ArgumentException("No bus already in system");
            AllData.List_Bus.Remove(in_system);
            in_system.fuel_up();
            AllData.List_Bus.Add(in_system.Clone()); // remove the one in the system, add the clone.
        }
        public void Maintain(int[] plate)
        {
            Bus in_system = AllData.List_Bus.Find(bus1 => comparearr(bus1.licensePlateArray, plate));
            if (in_system == null)
                throw new ArgumentException("No bus already in system");
            in_system.fix();
            AllData.List_Bus.Add(in_system.Clone()); // remove the one in the system, add the clone.
        }
        #endregion

        #region Line_func
        public IEnumerable<BusLine> GetAllBusLines() // the function for all buslines
        {
            return from line in AllData.List_BusLine
                   select line.Clone();
        }
        public BusLine GetBusLines(int linenum) // the num here is a number, and not an array.
        {
            BusLine in_system = AllData.List_BusLine.Find(line1 => linenum == line1.BusNumber);
            if (in_system == null)
                throw new ArgumentException("No line to get");
            return in_system.Clone();
        }
        public void AddBusLine(BusLine line)
        {
            BusLine in_system = AllData.List_BusLine.Find(line1 => line.BusNumber == line1.BusNumber);
            if (in_system != null)
                throw new ArgumentException("Can't add line. already in system");
            AllData.List_BusLine.Add(line.Clone());
        }
        public void RemoveBusLine(int linenum)
        {
            BusLine in_system = AllData.List_BusLine.Find(line1 => linenum == line1.BusNumber);
            if (in_system == null)
                throw new ArgumentException("No line to remove");
            AllData.List_BusLine.Remove(in_system.Clone());
        }
        public void Details_Line(BusLine line)
        {
            BusLine in_system = AllData.List_BusLine.Find(line1 => line.BusNumber == line1.BusNumber);
            if (in_system == null)
                throw new ArgumentException("No line to update details");
            AllData.List_BusLine.Remove(in_system.Clone());
            AllData.List_BusLine.Add(line.Clone());
        }
        #endregion

        #region LineStation_func
        public void addLineStation(LineStation line)
        {
            LineStation in_system = AllData.List_LineStation.Find(line1 => line.BusStationKey == line1.BusStationKey);
            if (in_system == null)
                throw new ArgumentException("No line to update details");
            AllData.List_LineStation.Remove(in_system.Clone());
            AllData.List_LineStation.Add(line.Clone());
        }
        public IEnumerable<LineStation> GetLines()
        {
            return from lines in AllData.List_LineStation
                   select lines.Clone();
        }
        public LineStation GetLineStation(int linenum) // get the line station with the i.d there.
        {
            LineStation in_system = AllData.List_LineStation.Find(bus1 => bus1.BusStationKey == linenum);
            if (in_system == null)
                throw new ArgumentException("No line to get");
            return in_system;
        }
        public void removebusLineStation(int linenum)
        {
            LineStation in_system = AllData.List_LineStation.Find(line1 => linenum == line1.BusStationKey);
            if (in_system == null)
                throw new ArgumentException("No line to remove");
            AllData.List_LineStation.Remove(in_system);
        }
        public void updatebusLineStation(LineStation line)
        {
            LineStation in_system = AllData.List_LineStation.Find(bus1 => bus1.BusStationKey == line.BusStationKey);
            if (in_system == null)
                throw new ArgumentException("No bus already in system");
            AllData.List_LineStation.Remove(in_system);
            AllData.List_LineStation.Add(line.Clone()); // remove the one in the system, add the clone.
        }


        #endregion
    }
}
