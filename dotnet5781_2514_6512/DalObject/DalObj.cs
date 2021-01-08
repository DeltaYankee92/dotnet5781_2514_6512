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
        static bool comparearr(int[] arr1, int[] arr2)
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
        public IEnumerable<Bus> GetAllBuses()
        {
            return from bus in AllData.List_Bus
                   select bus.Clone();
        }
        public Bus GetBus(int[] plate)
        {
            Bus in_system = AllData.List_Bus.Find(bus => comparearr(bus.licensePlateArray, plate));
            if (in_system == null)
                throw new ArgumentException("No bus already in system");
            return in_system;
        }
        public void addBus(Bus bus)
        {
            Bus in_system = AllData.List_Bus.Find(bus2 => comparearr(bus2.licensePlateArray , bus.licensePlateArray));
            if (in_system != null)
                throw new ArgumentException("Bus already in system");
            AllData.List_Bus.Add(bus.Clone());
        }

        public void removeBus(int[] plate)
        {
            Bus in_system = AllData.List_Bus.Find(bus => comparearr(bus.licensePlateArray, plate));
            if (in_system == null)
                throw new ArgumentException("No bus already in system");
            AllData.List_Bus.Remove(in_system);
        }
        public void Details(Bus bus)
        {
            Bus in_system = AllData.List_Bus.Find(bus1 => comparearr(bus1.licensePlateArray, bus.licensePlateArray));
            if (in_system == null)
                throw new ArgumentException("No bus already in system");
            AllData.List_Bus.Remove(in_system);
            AllData.List_Bus.Add(bus.Clone()); // remove the one in the system, add the clone.

        }
        public void Fuel(int[] plate)
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
        public IEnumerable<BusLine> GetAllBusLines()
        {
            return from line in AllData.List_BusLine
                   select line.Clone();
        }
        public BusLine GetBusLines(int linenum)
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
        public void addStation(BusLine station)
        {
            AllData.List_LineStation;
        }
        public IEnumerable<LineStation> GetAllbusLineStation()
        {

        }
        public LineStation GetbusLineStation(int[] id)
        {

        }
        public void removebusLineStation(int[] id)
        {

        }
        public void updatebusLineStation(LineStation line)
        {

        }

        /*
                 public void addStation(DO.busLineStation station)
        {
            var result = DataSource.LineStations.Find(b => b.code == station.code);
            if ((result != null) && (result.enabled == true))
                throw new itemAlreadyExistsException($"ID number {station.code} is already taken");
            DataSource.LineStations.Add(station.Clone());
        }
        public IEnumerable<busLineStation> GetAllbusLineStation()
        {
            return from bus in DataSource.LineStations
                   select bus.Clone();
        }
        public busLineStation GetbusLineStation(int id)
        {
            var result = DataSource.LineStations.Find(b => b.id == id);
            if (result == null)
                throw new NoSuchEntryException($"No entry Matches ID number {id}");
            return result;
        }
      
        public void removebusLineStation(int id)
        {
            var result = DataSource.LineStations.Find(b => b.id == id);
            if (result == null)
                throw new NoSuchEntryException($"No entry Matches ID number {id}");
            result.enabled = false;
        }
        public void updatebusLineStation(busLineStation station)
        {
            var result = DataSource.LineStations.Find(b => b.id == station.id);
            if (result == null)
                throw new NoSuchEntryException($"No entry Matches ID number {station.id}");
            DataSource.LineStations.Remove(result);
            DataSource.LineStations.Add(station.Clone());
        }
         
         
         */


        #endregion
    }
}
