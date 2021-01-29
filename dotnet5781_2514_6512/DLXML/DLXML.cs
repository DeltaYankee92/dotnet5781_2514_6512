using DLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DL
{
    sealed class DLXML : IDL    //internal
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }// static ctor to ensure instance init is done just before first usage
        DLXML() { } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files

        private static string BusStopPath = @"BusStops.xml";
        private static string BusLinePath = @"BusLines.xml";
        private static string BusPath = @"Busses.xml";
        private static string LineStationPath = @"LineStations.xml";
        private static string LineCyclePath = @"LineCycles.xml";
        private static string Moving_busPath = @"MovingBusses.xml";
        private static string TwostopsPath = @"Twostops.xml";

        #endregion

        #region staticXML getters
        public static int[] atoi(string temp)
        {
            int[] generated = new int[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                char x = temp[i];
                switch (x)
                {
                    case '0':
                        generated[i] = 0;
                        break;
                    case '1':
                        generated[i] = 1;
                        break;
                    case '2':
                        generated[i] = 2;
                        break;
                    case '3':
                        generated[i] = 3;
                        break;
                    case '4':
                        generated[i] = 4;
                        break;
                    case '5':
                        generated[i] = 5;
                        break;
                    case '6':
                        generated[i] = 6;
                        break;
                    case '7':
                        generated[i] = 7;
                        break;
                    case '8':
                        generated[i] = 8;
                        break;
                    case '9':
                        generated[i] = 9;
                        break;
                    default:
                        throw new ArgumentException("can't generate");
                }
            }
            return generated;
        }

        public static string convert_to_string(int[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
                str += arr[i];
            return str;
        }
        public Bus GetBus_XML(string License_Plate)
        {
            XElement BusElement = XMLTools.LoadListFromXMLElement(BusPath);
            Bus p = (from bus in BusElement.Elements()
                     where (bus.Element("License_Plate").Value) == License_Plate
                     select new Bus()
                     {
                         Milage = Int32.Parse(bus.Element("Milage").Value),
                         licensePlateArray = atoi(bus.Element("License_Plate").Value),
                         MilageTotal = Int32.Parse(bus.Element("MilageTotal").Value),
                         Current_Fuel = Int32.Parse(bus.Element("Current_Fuel").Value),
                         LastMaintenance = Int32.Parse(bus.Element("LastMaintenance").Value),
                         RegistrationDate = DateTime.Parse(bus.Element("RegistrationDate").Value),
                         MaintenanceDate = DateTime.Parse(bus.Element("MaintenanceDate").Value),
                         Status = (bus.Element("Status").Value),
                         License_Plate = (bus.Element("License_Plate").Value)
                     }).FirstOrDefault();
            if (p == null)
                throw new XelementSearchFailedException("finding the License_Plate", License_Plate+" has failed");
            return p;
        }

        public BusStop GetBusStop_XML(int key)
        {
            XElement BusStopElement = XMLTools.LoadListFromXMLElement(BusStopPath);
            BusStop stop = (from stop1 in BusStopElement.Elements()
                            where (Int32.Parse(stop1.Element("BusStationKey").Value) == key)
                            select new BusStop()
                            {
                                BusStationKey = Int32.Parse(stop1.Element("BusStationKey").Value),
                                Latitude = double.Parse(stop1.Element("Latitude").Value),
                                Longitude = double.Parse(stop1.Element("Longitude").Value),
                                Adress = (stop1.Element("Adress").Value)
                            }).FirstOrDefault();
            if (stop == null)
                throw new XelementSearchFailedException("finding the License_Plate", key + " has failed");
            return stop;
                            
        }
        public BusLine GetBusLine_XML(int key)
        {
            XElement BusLineElement = XMLTools.LoadListFromXMLElement(BusLinePath);
            List<BusLine> BusLine_List = XMLTools.LoadListFromXMLSerializer<BusLine>(BusLinePath);

            BusStop b1 = null  , b2 = null;
            foreach (var line2 in BusLine_List)
            {
                if (line2.BusNumber == key)
                {
                    b1 = line2.FirstStation;
                    b2 = line2.LastStation;
                }
            }
            if (b1 == null || b2 == null)
                throw new NotFoundException();

            BusLine line = (from line1 in BusLineElement.Elements()
                            where (Int32.Parse(line1.Element("BusNumber").Value) == key)
                            select new BusLine()
                            {
                                FirstStation = b1
                                    ,
                                LastStation= b2
                                    ,
                                BusNumber = Int32.Parse(line1.Element("BusNumber").Value),
                                Area = (line1.Element("Area").Value)
                            }).FirstOrDefault();

            return line;

        }
        public Twostops GetTwostops_XML(int key)
        {
            XElement TwostopsElement = XMLTools.LoadListFromXMLElement(TwostopsPath);
            Twostops stop = (from stop1 in TwostopsElement.Elements()
                            where (Int32.Parse(stop1.Element("BusStationKey").Value) == key)
                            select new Twostops()
                            {
                                code1 = atoi(stop1.Element("code1").Value),
                                code2 = atoi(stop1.Element("code2").Value),
                                distance = Int32.Parse(stop1.Element("distance").Value),
                                between = TimeSpan.Parse(stop1.Element("between").Value),
                                id = Int32.Parse(stop1.Element("id").Value)
                            }).FirstOrDefault();

            return stop;

        }
        public Moving_bus GetMoving_bus_XML(int key)
        {
            XElement Moving_busElement = XMLTools.LoadListFromXMLElement(Moving_busPath);
            Moving_bus stop = (from stop1 in Moving_busElement.Elements()
                            where (Int32.Parse(stop1.Element("BusStationKey").Value) == key)
                            select new Moving_bus()
                            {
                                is_driving = bool.Parse(stop1.Element("is_driving").Value),
                                plate = atoi(stop1.Element("plate").Value),
                                everyXmins = Int32.Parse(stop1.Element("everyXmins").Value),
                                time_out = TimeSpan.Parse(stop1.Element("time_out").Value),
                                last_stop = Int32.Parse(stop1.Element("last_stop").Value),
                                time_to_next = Int32.Parse(stop1.Element("time_to_next").Value),
                                id = Int32.Parse(stop1.Element("id").Value)
                            }).FirstOrDefault();

            return stop;

        }
        public LineStation GetLineStation_XML(int key)
        {
            XElement LineStationElement = XMLTools.LoadListFromXMLElement(LineStationPath);
            LineStation stop = (from stop1 in LineStationElement.Elements()
                            where (Int32.Parse(stop1.Element("BusStationKey").Value) == key)
                            select new LineStation()
                            {
                                BusStationKey = Int32.Parse(stop1.Element("BusStationKey").Value),
                                Latitude = double.Parse(stop1.Element("Latitude").Value),
                                Longitude = double.Parse(stop1.Element("Longitude").Value),
                                Adress = stop1.Element("Adress").Value,
                                distance = double.Parse(stop1.Element("distance").Value),
                                time = TimeSpan.Parse(stop1.Element("time").Value)
                            }).FirstOrDefault();

            return stop;

        }
        public LineCycle GetLineCycle_XML(int key)
        {
            XElement LineCycleElement = XMLTools.LoadListFromXMLElement(LineCyclePath);
            LineCycle stop = (from stop1 in LineCycleElement.Elements()
                            where (Int32.Parse(stop1.Element("BusStationKey").Value) == key)
                            select new LineCycle()
                            {
                                frequency = Int32.Parse(stop1.Element("frequency").Value),
                                id = Int32.Parse(stop1.Element("id").Value)
                            }).FirstOrDefault();

            return stop;
        }
        #endregion

        #region staticXML setters

        public void setBus_XML(Bus b)
        {

            List<Bus> Bus_List = XMLTools.LoadListFromXMLSerializer<Bus>(BusPath);
            if (b == null || b.License_Plate == null || b.isactive == false)
                throw new ItemIsInactiveException("no bus fits, or bus is not active");
            if (Bus_List.FirstOrDefault(b1 => b1.License_Plate == b.License_Plate) != null)
                throw new InsystemException("object already in system");
            Bus_List.Add(b);
            XMLTools.SaveListToXMLSerializer(Bus_List,BusPath);
        }

        public void setBusStop_XML(BusStop b)
        {

            List<BusStop> BusStop_List = XMLTools.LoadListFromXMLSerializer<BusStop>(BusStopPath);
            if (b == null || b.isactive == false)
                throw new ItemIsInactiveException("no BusStop fits, or BusStop is not active");
            if (BusStop_List.FirstOrDefault(b1 => b1.BusStationKey == b.BusStationKey) != null)
                throw new InsystemException("object already in system");
            BusStop_List.Add(b);
            XMLTools.SaveListToXMLSerializer(BusStop_List, BusStopPath);
        }
        public void setBusLine_XML(BusLine l)
        {

            List<BusLine> BusLine_List = XMLTools.LoadListFromXMLSerializer<BusLine>(BusLinePath);
            if (l == null || l.isactive == false)
                throw new ItemIsInactiveException("no BusLine fits, or BusLine is not active");
            if (BusLine_List.FirstOrDefault(l1 => l1.BusNumber == l.BusNumber) != null)
                throw new InsystemException("object already in system");
            BusLine_List.Add(l);
            XMLTools.SaveListToXMLSerializer(BusLine_List, BusLinePath);
        }
        public void setLineStation_XML(LineStation l)
        {
            List<LineStation> LineStation_List = XMLTools.LoadListFromXMLSerializer<LineStation>(LineStationPath);
            if (l == null || l.isactive == false)
                throw new ItemIsInactiveException("no LineStation fits, or LineStation is not active");
            if (LineStation_List.FirstOrDefault(l1 => l1.BusStationKey == l.BusStationKey) != null)
                throw new InsystemException("object already in system");
            LineStation_List.Add(l);
            XMLTools.SaveListToXMLSerializer(LineStation_List, LineStationPath);
        }
        public void setLineCycle_XML(LineCycle c)
        {
            List<LineCycle> LineCycle_List = XMLTools.LoadListFromXMLSerializer<LineCycle>(LineCyclePath);
            if (c == null || c.isactive == false)
                throw new ItemIsInactiveException("no LineCycle fits, or LineCycle is not active");
            if (LineCycle_List.FirstOrDefault(b1 => b1.id == c.id) != null)
                throw new InsystemException("object already in system");
            LineCycle_List.Add(c);
            XMLTools.SaveListToXMLSerializer(LineCycle_List, LineCyclePath);

        }
        public void setMoving_bus_XML(Moving_bus m)
        {
            List<Moving_bus> Moving_bus_List = XMLTools.LoadListFromXMLSerializer<Moving_bus>(Moving_busPath);
            if (m == null || m.isactive == false)
                throw new ItemIsInactiveException("no Moving_bus fits, or Moving_bus is not active");
            if (Moving_bus_List.FirstOrDefault(m1 => m1.id == m.id) != null)
                throw new InsystemException("object already in system");
            Moving_bus_List.Add(m);
            XMLTools.SaveListToXMLSerializer(Moving_bus_List, Moving_busPath);

        }
        public void setTwostops_XML(Twostops t)
        {
            List<Twostops> Twostops_List = XMLTools.LoadListFromXMLSerializer<Twostops>(TwostopsPath);
            if (t == null || t.isactive == false)
                throw new ItemIsInactiveException("no Twostops fits, or Twostops is not active");
            if (Twostops_List.FirstOrDefault(t1 => t1.id == t.id) != null)
                throw new InsystemException("object already in system");
            Twostops_List.Add(t);
            XMLTools.SaveListToXMLSerializer(Twostops_List, TwostopsPath);
        }

        #endregion

        #region staticXML removers

        public static void removeBus_XML(Bus b1)
        {

            XElement element = XMLTools.LoadListFromXMLElement(BusPath);
            XElement target = ( from b in element.Elements()
                where (b.Element("License_Plate").Value) == b1.License_Plate
                select b
                ).FirstOrDefault();
            if (target == null)
                throw new NotFoundException("no bus exists to remove");
            else
            {
                target.Remove(); // removes node from the parent
                XMLTools.SaveListToXMLElement(element, BusPath);
            }
        }
        public static void removeBusStop_XML(BusStop b1)
        {
            XElement element = XMLTools.LoadListFromXMLElement(BusStopPath);
            XElement target = (from b in element.Elements()
                               where int.Parse(b.Element("BusStationKey").Value) == b1.BusStationKey
                               select b
                ).FirstOrDefault();
            if (target == null)
                throw new NotFoundException("no BusStop exists to remove");
            else
            {
                target.Remove(); // removes node from the parent
                XMLTools.SaveListToXMLElement(element, BusStopPath);
            }
        }
        public static void removeBusLine_XML(BusLine l1)
        {
            XElement element = XMLTools.LoadListFromXMLElement(BusLinePath);
            XElement target = (from b in element.Elements()
                               where int.Parse(b.Element("BusNumber").Value) == l1.BusNumber
                               select b
                ).FirstOrDefault();
            if (target == null)
                throw new NotFoundException("no BusLine exists to remove");
            else
            {
                target.Remove(); // removes node from the parent
                XMLTools.SaveListToXMLElement(element, BusLinePath);
            }
        }
        public static void removeLineStation_XML(LineStation l1)
        {
            XElement element = XMLTools.LoadListFromXMLElement(LineStationPath);
            XElement target = (from b in element.Elements()
                               where int.Parse(b.Element("BusStationKey").Value) == l1.BusStationKey
                               select b
                ).FirstOrDefault();
            if (target == null)
                throw new NotFoundException("no LineStation exists to remove");
            else
            {
                target.Remove(); // removes node from the parent
                XMLTools.SaveListToXMLElement(element, LineStationPath);
            }
        }
        public static void removeLineCycle_XML(LineCycle c1)
        {
            XElement element = XMLTools.LoadListFromXMLElement(LineCyclePath);
            XElement target = (from b in element.Elements()
                               where int.Parse(b.Element("id").Value) == c1.id
                               select b
                ).FirstOrDefault();
            if (target == null)
                throw new NotFoundException("no LineCycle exists to remove");
            else
            {
                target.Remove(); // removes node from the parent
                XMLTools.SaveListToXMLElement(element, LineCyclePath);
            }
        }
        public static void removeMoving_bus_XML(Moving_bus b1)
        {
            XElement element = XMLTools.LoadListFromXMLElement(BusPath);
            XElement target = (from b in element.Elements()
                               where int.Parse(b.Element("id").Value) == b1.id
                               select b
                ).FirstOrDefault();
            if (target == null)
                throw new NotFoundException("no bus exists to remove");
            else
            {
                target.Remove(); // removes node from the parent
                XMLTools.SaveListToXMLElement(element, BusPath);
            }
        }
        public static void removeTwostops_XML(Twostops ts1)
        {
            XElement element = XMLTools.LoadListFromXMLElement(BusPath);
            XElement target = (from b in element.Elements()
                               where int.Parse(b.Element("id").Value) == ts1.id
                               select b
                ).FirstOrDefault();
            if (target == null)
                throw new NotFoundException("no bus exists to remove");
            else
            {
                target.Remove(); // removes node from the parent
                XMLTools.SaveListToXMLElement(element, BusPath);
            }
        }

        #endregion

        #region BusStop

        public void addBusStop(BusStop bus)
        {
            setBusStop_XML(bus);
        }

        public BusStop GetBusStop(int stopnum)
        {
            return GetBusStop_XML(stopnum);
        }

        public IEnumerable<BusStop> GetAllBusStops()
        {
            List<BusStop> Bus_List = XMLTools.LoadListFromXMLSerializer<BusStop>(BusStopPath);
            return from Stop in Bus_List
                   where Stop.isactive
                   select Stop;
        }

        public IEnumerable<BusStop> GetAllBusStops_history()
        {
            List<BusStop> Bus_List = XMLTools.LoadListFromXMLSerializer<BusStop>(BusStopPath);
            return from Stop in Bus_List
                   select Stop;
        }

        public void Details_BusStop(BusStop bus)
        {
                BusStop b = GetBusStop_XML(bus.BusStationKey); // a check if it is in the system
                removeBusStop_XML(b); // remove it
                setBusStop_XML(bus); // then add it.
        }

        public void removeBusStop(int stopnum)
        {
            BusStop b = GetBusStop_XML(stopnum);
            removeBusStop_XML(b);
        }
        #endregion

        #region Bus
        public void addBus(Bus bus)
        {
            setBus_XML(bus);
        }

        public Bus GetBus(int[] plate)
        {
            return GetBus_XML(convert_to_string(plate));
        }

        public IEnumerable<Bus> GetAllBuses()
        {
            List<Bus> Bus_List = XMLTools.LoadListFromXMLSerializer<Bus>(BusPath);
            return from bus in Bus_List
                   where bus.isactive
                   select bus;
        }

        public IEnumerable<Bus> GetAllBuses_history()
        {
            List<Bus> Bus_List = XMLTools.LoadListFromXMLSerializer<Bus>(BusPath);
            return from bus in Bus_List
                   select bus;
        }

        public void Details(Bus bus)
        {
            Bus b = GetBus_XML(bus.License_Plate); // a check if it is in the system
            removeBus_XML(b); // remove it
            setBus_XML(bus); // then add it.
        }

        public void Fuel(int[] plate)
        {
            Bus b = GetBus_XML(convert_to_string(plate));
            b.fuel_up();
            this.Details(b);
        }

        public void Maintain(int[] plate)
        {
            Bus b = GetBus_XML(convert_to_string(plate));
            b.fix();
            this.Details(b);
        }

        public void removeBus(int[] plate)
        {
            Bus b = GetBus_XML(convert_to_string(plate));
            removeBus_XML(b);
        }

        #endregion

        #region BusLine
        public void AddBusLine(BusLine line)
        {
            setBusLine_XML(line);
        }

        public IEnumerable<BusLine> GetAllBusLines()
        {
            List<BusLine> BusLine_List = XMLTools.LoadListFromXMLSerializer<BusLine>(BusLinePath);
            return from line in BusLine_List
                   where line.isactive
                   select line;
        }

        public IEnumerable<BusLine> GetAllBusLines_history()
        {
            List<BusLine> BusLine_List = XMLTools.LoadListFromXMLSerializer<BusLine>(BusLinePath);
            return from line in BusLine_List
                   select line;
        }

        public BusLine GetBusLine(int linenum)
        {
            return GetBusLine_XML(linenum);
        }

        public void Details_Line(BusLine line)
        {
            BusLine l = GetBusLine_XML(line.BusNumber); // a check if it is in the system
            removeBusLine_XML(l); // remove it
            setBusLine_XML(line); // then add it.
        }

        public void RemoveBusLine(int linenum)
        {
            BusLine l = GetBusLine_XML(linenum);
            removeBusLine_XML(l);
        }

        #endregion

        #region LineStation

        public void addStation(LineStation line)
        {
            setLineStation_XML(line);
        }
        public IEnumerable<LineStation> GetLines()
        {
            List<LineStation> LineStation_List = XMLTools.LoadListFromXMLSerializer<LineStation>(LineStationPath);
            return from Station in LineStation_List
                   where Station.isactive
                   select Station;
        }

        public IEnumerable<LineStation> GetLines_history()
        {
            List<LineStation> LineStation_List = XMLTools.LoadListFromXMLSerializer<LineStation>(LineStationPath);
            return from Station in LineStation_List
                   select Station;
        }

        public LineStation GetLineStation(int linenum)
        {
            return GetLineStation_XML(linenum);
        }

        public void removeLineStation(int linenum)
        {
            LineStation b = GetLineStation_XML(linenum);
            removeLineStation_XML(b);
        }

        public void Details_LineStation(LineStation line)
        {
            LineStation l = GetLineStation_XML(line.BusStationKey); // a check if it is in the system
            removeLineStation_XML(l); // remove it
            setLineStation_XML(line); // then add it.
        }

        #endregion

        #region LineCycle
        public void addCycle(LineCycle line)
        {
            setLineCycle_XML(line);
        }

        public IEnumerable<LineCycle> GetCycles()
        {
            List<LineCycle> LineCycle_List = XMLTools.LoadListFromXMLSerializer<LineCycle>(LineCyclePath);
            return from cycle in LineCycle_List
                   where cycle.isactive
                   select cycle;
        }

        public IEnumerable<LineCycle> GetCycles_history()
        {
            List<LineCycle> LineCycle_List = XMLTools.LoadListFromXMLSerializer<LineCycle>(LineCyclePath);
            return from cycle in LineCycle_List
                   select cycle;
        }

        public LineCycle GetCycle(int counted)
        {
            return GetLineCycle_XML(counted);
        }

        public void RemoveCycle(int counted)
        {
            LineCycle c = GetLineCycle_XML(counted);
            removeLineCycle_XML(c);
        }

        public void Details_Cycle(LineCycle line)
        {
            LineCycle l = GetLineCycle_XML(line.id); // a check if it is in the system
            removeLineCycle_XML(l); // remove it
            setLineCycle_XML(line); // then add it.
        }
        #endregion

        #region MovingBus
        public void addMoving_Bus(Moving_bus bus)
        {
            setMoving_bus_XML(bus);
        }

        public IEnumerable<Moving_bus> Moving_Bus()
        {
            List<Moving_bus> Moving_bus_List = XMLTools.LoadListFromXMLSerializer<Moving_bus>(Moving_busPath);
            return from M_bus in Moving_bus_List
                   where M_bus.isactive
                   select M_bus;
        }

        public IEnumerable<Moving_bus> Moving_Bus_history()
        {
            List<Moving_bus> Moving_bus_List = XMLTools.LoadListFromXMLSerializer<Moving_bus>(Moving_busPath);
            return from M_bus in Moving_bus_List
                   select M_bus;
        }

        public Moving_bus GetMoving_Bus(int counted)
        {
            return GetMoving_bus_XML(counted);
        }

        public void removeMoving_Bus(int counted)
        {
            Moving_bus m = GetMoving_bus_XML(counted);
            removeMoving_bus_XML(m);
        }

        public void Details_Moving_Bus(Moving_bus bus)
        {
            Moving_bus l = GetMoving_bus_XML(bus.id); // a check if it is in the system
            removeMoving_bus_XML(l); // remove it
            setMoving_bus_XML(bus); // then add it.
        }
        #endregion

        #region TwoStops
        public void addTwostops(Twostops route)
        {
            setTwostops_XML(route);
        }

        public IEnumerable<Twostops> GetTwostops()
        {
            List<Twostops> Twostops_List = XMLTools.LoadListFromXMLSerializer<Twostops>(TwostopsPath);
            return from Stops in Twostops_List
                   where Stops.isactive
                   select Stops;
        }

        public IEnumerable<Twostops> GetTwostops_history()
        {
            List<Twostops> Twostops_List = XMLTools.LoadListFromXMLSerializer<Twostops>(TwostopsPath);
            return from Stops in Twostops_List
                   select Stops;
        }

        public Twostops GetGetTwostopS(int counted)
        {
            return GetTwostops_XML(counted);
        }

        public void removeTwostops(int counted)
        {
            Twostops t = GetTwostops_XML(counted);
            removeTwostops_XML(t);
        }

        public void Details_LineStation(Twostops route)
        {
            Twostops t = GetTwostops_XML(route.id); // a check if it is in the system
            removeTwostops_XML(t); // remove it
            setTwostops_XML(route); // then add it.
        }
        #endregion
    }
}