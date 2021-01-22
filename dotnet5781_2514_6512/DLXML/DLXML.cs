using DLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DLXML
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

        private static string dir = @"xml\";// directive i assume. makes life easier. dan's technique
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
            BusLine line = (from line1 in BusLineElement.Elements()
                            where (Int32.Parse(line1.Element("BusNumber").Value) == key)
                            select new BusLine()
                            {
                                FirstStation = new BusStop(
                                Int32.Parse(line1.Element("BusStationKey").Value),
                                double.Parse(line1.Element("Latitude").Value),
                                double.Parse(line1.Element("Longitude").Value),
                                (line1.Element("Adress").Value)
                                    ),
                                LastStation = new BusStop(
                                Int32.Parse(line1.Element("BusStationKey").Value),
                                double.Parse(line1.Element("Latitude").Value),
                                double.Parse(line1.Element("Longitude").Value),
                                (line1.Element("Adress").Value)
                                    ),
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


        #region BusStop

        public void addBusStop(BusStop bus)
        {

        }

        public BusStop GetBusStop(int stopnum)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusStop> GetAllBusStops()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusStop> GetAllBusStops_history()
        {
            throw new NotImplementedException();
        }

        public void Details_BusStop(BusStop bus)
        {
            throw new NotImplementedException();
        }

        public void removeBusStop(int stopnum)
        {
            throw new NotImplementedException();
        }
        #endregion
        public void addBus(Bus bus)
        {
            throw new NotImplementedException();
        }

        public Bus GetBus(int[] plate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetAllBuses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetAllBuses_history()
        {
            throw new NotImplementedException();
        }

        public void Details(Bus bus)
        {
            throw new NotImplementedException();
        }

        public void Fuel(int[] plate)
        {
            throw new NotImplementedException();
        }

        public void Maintain(int[] plate)
        {
            throw new NotImplementedException();
        }

        public void removeBus(int[] plate)
        {
            throw new NotImplementedException();
        }

        public void AddBusLine(BusLine line)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusLine> GetAllBusLines()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusLine> GetAllBusLines_history()
        {
            throw new NotImplementedException();
        }

        public BusLine GetBusLine(int linenum)
        {
            throw new NotImplementedException();
        }

        public void Details_Line(BusLine line)
        {
            throw new NotImplementedException();
        }

        public void RemoveBusLine(int linenum)
        {
            throw new NotImplementedException();
        }

        public void addStation(LineStation line)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetLines()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetLines_history()
        {
            throw new NotImplementedException();
        }

        public LineStation GetLineStation(int linenum)
        {
            throw new NotImplementedException();
        }

        public void removeLineStation(int linenum)
        {
            throw new NotImplementedException();
        }

        public void Details_LineStation(LineStation line)
        {
            throw new NotImplementedException();
        }

        public void addCycle(LineCycle line)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineCycle> GetCycles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineCycle> GetCycles_history()
        {
            throw new NotImplementedException();
        }

        public LineCycle GetCycle(int counted)
        {
            throw new NotImplementedException();
        }

        public void RemoveCycle(int counted)
        {
            throw new NotImplementedException();
        }

        public void Details_Cycle(LineCycle line)
        {
            throw new NotImplementedException();
        }

        public void addMoving_Bus(Moving_bus bus)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Moving_bus> Moving_Bus()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Moving_bus> Moving_Bus_history()
        {
            throw new NotImplementedException();
        }

        public Moving_bus GetMoving_Bus(int counted)
        {
            throw new NotImplementedException();
        }

        public void removeMoving_Bus(int counted)
        {
            throw new NotImplementedException();
        }

        public void Details_Moving_Bus(Moving_bus bus)
        {
            throw new NotImplementedException();
        }

        public void addTwostops(Twostops route)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Twostops> GetTwostops()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Twostops> GetTwostops_history()
        {
            throw new NotImplementedException();
        }

        public Twostops GetGetTwostopS(int counted)
        {
            throw new NotImplementedException();
        }

        public void removeTwostops(int counted)
        {
            throw new NotImplementedException();
        }

        public void Details_LineStation(Twostops route)
        {
            throw new NotImplementedException();
        }



    }
}