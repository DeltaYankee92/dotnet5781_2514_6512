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


        #region busstop
        public void addBusStop(BusStop bus)
        {
            BusStop in_system = AllData.List_BusStop.Find(bus2 => bus2.BusStationKey ==  bus.BusStationKey);
            if (in_system != null && in_system.isactive == true)
                throw new InsystemException("Can't add bus. already in system");
            if (in_system == null && bus.isactive == false)
                throw new ItemIsInactiveException("can't add inactive bus");
            if (in_system != null && in_system.isactive == false)
                AllData.List_BusStop.Remove(in_system);
            AllData.List_BusStop.Add(bus.Clone());
        }
        // cRud
        public BusStop GetBusStop(int stopnum)
        {
            BusStop in_system = AllData.List_BusStop.Find(bus => bus.BusStationKey== stopnum);
            if (in_system == null)
                throw new NotFoundException("No bus already in system");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("bus is not active");
            return in_system; 
        }
        public IEnumerable<BusStop> GetAllBusStops() 
        {
            return from bus in AllData.List_BusStop
                   where (bus != null && bus.isactive == true)
                   select bus.Clone();
        }
        public IEnumerable<BusStop> GetAllBusStops_history() 
        {
            return from bus in AllData.List_BusStop
                   where (bus != null)
                   select bus.Clone();
        }
        // crUd
        public void Details_BusStop(BusStop bus)
        {
            BusStop in_system = AllData.List_BusStop.Find(bus1 => bus1.BusStationKey == bus.BusStationKey);
            if (in_system == null)
                throw new NotFoundException("No bus already in system");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("bus is not active");
            AllData.List_BusStop.Remove(in_system);
            AllData.List_BusStop.Add(bus.Clone()); 

        }
        // crUd
        public void removeBusStop(int stopnum)
        {
            BusStop in_system = AllData.List_BusStop.Find(bus => stopnum == bus.BusStationKey);
            if (in_system == null)
                throw new NotFoundException("No bus already in system");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("bus is not active");
            AllData.List_BusStop.Remove(in_system);

            in_system.Word_activity("inactive");
            AllData.List_BusStop.Add(in_system.Clone()); 
        }
        #endregion

        #region bus_func

        // Crud
        public void addBus(Bus bus) // adding a Bus to the Line of Buses
        {
            Bus in_system = AllData.List_Bus.Find(bus2 => comparearr(bus2.licensePlateArray, bus.licensePlateArray)); // lambda with bus2 as the function
            if (in_system != null && in_system.isactive == true)
                throw new InsystemException("Can't add bus. already in system");
            if (in_system == null && bus.isactive == false)
                throw new ItemIsInactiveException("can't add inactive bus");
            if (in_system != null && in_system.isactive == false)
                AllData.List_Bus.Remove(in_system);
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
        public IEnumerable<Bus> GetAllBuses_history() // get all of the clones. Ienumerable<T> is easy
        {
            return from bus in AllData.List_Bus
                   where (bus != null)
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
        public void Maintain(int[] plate) //crUd
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
            if (in_system != null && in_system.isactive == true)
                throw new InsystemException("Can't add line. already in system");
            if (in_system == null && line.isactive == false)
                throw new ItemIsInactiveException("can't add inactive busline");
            if (in_system != null && in_system.isactive == false)
                AllData.List_BusLine.Remove(in_system);
            AllData.List_BusLine.Add(line.Clone());
        }
        //cRud
        public IEnumerable<BusLine> GetAllBusLines() // the function for all buslines
        {
            return from line in AllData.List_BusLine
                   where (line != null && line.isactive == true)
                   select line.Clone();
        }
        public IEnumerable<BusLine> GetAllBusLines_history() // the function for all buslines
        {
            return from line in AllData.List_BusLine
                   where (line != null)
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
            if (in_system != null && in_system.isactive == true)
                throw new InsystemException("Can't add line. already in system");
            if (in_system == null && line.isactive == false)
                throw new ItemIsInactiveException("can't add inactive busline");
            if (in_system != null && in_system.isactive == false)
                AllData.List_LineStation.Remove(in_system);
            AllData.List_LineStation.Add(line.Clone());
        }
        public IEnumerable<LineStation> GetLines()
        {
            return from lines in AllData.List_LineStation
                   where (lines != null && lines.isactive == true)
                   select lines.Clone();
        }
        public IEnumerable<LineStation> GetLines_history()
        {
            return from lines in AllData.List_LineStation
                   where (lines != null)
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


        #region LineCycle
        public void addCycle(LineCycle line)// Crud
        {
            LineCycle in_system = AllData.List_LineCycle.Find(line1 => line.id == line1.id);
            if (in_system != null && in_system.isactive == true)
                throw new InsystemException("Can't add cycle. already in system");
            if (in_system == null && line.isactive == false)
                throw new ItemIsInactiveException("can't add inactive cycle");
            if (in_system != null && in_system.isactive == false)
                AllData.List_LineCycle.Remove(in_system);

            AllData.List_LineCycle.Add(line.Clone());
        }

        public IEnumerable<LineCycle> GetCycles()// cRud
        {
            return from lines in AllData.List_LineCycle
                   where (lines != null && lines.isactive == true)
                   select lines.Clone();
        }

        public IEnumerable<LineCycle> GetCycles_history()// cRud
        {
            return from lines in AllData.List_LineCycle
                   where (lines != null)
                   select lines.Clone();
        }

        public LineCycle GetCycle(int counted) // cRud
        {
            LineCycle in_system = AllData.List_LineCycle.Find(line => line.id == counted);
            if (in_system == null)
                throw new NotFoundException("No cycle to get");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("cycle is not active");
            return in_system;
        }

        public void Details_Cycle(LineCycle line) // crUd
        {
            LineCycle in_system = AllData.List_LineCycle.Find(bus1 => bus1.id == line.id);
            if (in_system == null)
                throw new NotFoundException("No cycle to remove");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("cycle is not active");
            AllData.List_LineCycle.Remove(in_system);
            AllData.List_LineCycle.Add(line.Clone()); // remove the one in the system, add the clone.
        }
        public void RemoveCycle(int counted)// cruD
        {
            LineCycle in_system = AllData.List_LineCycle.Find(line1 => counted == line1.id);
            if (in_system == null)
                throw new NotFoundException("No cycle to remove");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("cycle is not active");
            AllData.List_LineCycle.Remove(in_system);

            in_system.Word_activity("inactive");
            AllData.List_LineCycle.Add(in_system);
        }

        #endregion

        #region Moving_bus
        public void addMoving_Bus(Moving_bus bus)// Crud
        {
            Moving_bus in_system = AllData.List_Moving_bus.Find(bus1 => bus.id == bus1.id);
            if (in_system != null && in_system.isactive == true)
                throw new InsystemException("Can't add bus. already in system");
            if (in_system == null && bus.isactive == false)
                throw new ItemIsInactiveException("can't add inactive bus");
            if (in_system != null && in_system.isactive == false)
                AllData.List_Moving_bus.Remove(in_system);
            AllData.List_Moving_bus.Add(bus.Clone());
        }

        public IEnumerable<Moving_bus> Moving_Bus()//cRud
        {
            return from lines in AllData.List_Moving_bus
                   where (lines != null && lines.isactive == true)
                   select lines.Clone();
        }

        public IEnumerable<Moving_bus> Moving_Bus_history()//cRud
        {
            return from lines in AllData.List_Moving_bus
                   where (lines != null)
                   select lines.Clone();
        }

        public Moving_bus GetMoving_Bus(int counted)//cRud
        {
            Moving_bus in_system = AllData.List_Moving_bus.Find(bus => bus.id == counted);
            if (in_system == null)
                throw new NotFoundException("No bus to get");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("bus is not active");
            return in_system;
        }

        public void Details_Moving_Bus(Moving_bus bus)//crUd
        {
            Moving_bus in_system = AllData.List_Moving_bus.Find(bus1 => bus1.id == bus.id);
            if (in_system == null)
                throw new NotFoundException("No bus to remove");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("bus is not active");
            AllData.List_Moving_bus.Remove(in_system);
            AllData.List_Moving_bus.Add(bus.Clone()); // remove the one in the system, add the clone.
        }
        public void removeMoving_Bus(int counted)//cruD
        {
            Moving_bus in_system = AllData.List_Moving_bus.Find(bus1 => counted == bus1.id);
            if (in_system == null)
                throw new NotFoundException("No bus to remove");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("bus is not active");
            AllData.List_Moving_bus.Remove(in_system);

            in_system.Word_activity("inactive");
            AllData.List_Moving_bus.Add(in_system);
        }
        #endregion

        #region Twostops
        public void addTwostops(Twostops route)//Crud
        {
            Twostops in_system = AllData.List_Twostops.Find(route1 => route.id == route1.id);
            if (in_system != null && in_system.isactive == true)
                throw new InsystemException("Can't add rotue. already in system");
            if (in_system == null && route.isactive == false)
                throw new ItemIsInactiveException("can't add inactive route");
            if(in_system!=null && in_system.isactive == false)
                AllData.List_Twostops.Remove(in_system);
            AllData.List_Twostops.Add(route.Clone());
        }

        public IEnumerable<Twostops> GetTwostops() //cRud
        {
            return from lines in AllData.List_Twostops
                   where (lines != null && lines.isactive == true)
                   select lines.Clone();
        }

        public IEnumerable<Twostops> GetTwostops_history()//cRud
        {
            return from lines in AllData.List_Twostops
                   where (lines != null)
                   select lines.Clone();
        }

        public Twostops GetGetTwostopS(int counted)//cRud
        {
            Twostops in_system = AllData.List_Twostops.Find(route => route.id == counted);
            if (in_system == null)
                throw new NotFoundException("No Route to get");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("Route is not active");
            return in_system;
        }

        public void Details_LineStation(Twostops route)//crUd
        {
            Twostops in_system = AllData.List_Twostops.Find(route1 => route1.id == route.id);
            if (in_system == null)
                throw new NotFoundException("No Route to remove");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("Route is not active");
            AllData.List_Twostops.Remove(in_system);
            AllData.List_Twostops.Add(route.Clone()); // remove the one in the system, add the clone.
        }
        public void removeTwostops(int counted)//cruD
        {
            Twostops in_system = AllData.List_Twostops.Find(route => counted == route.id);
            if (in_system == null)
                throw new NotFoundException("No Route to remove");
            if (in_system.isactive == false)
                throw new ItemIsInactiveException("Route is not active");
            AllData.List_Twostops.Remove(in_system);

            in_system.Word_activity("inactive");
            AllData.List_Twostops.Add(in_system);
        }
        #endregion
    }
}
