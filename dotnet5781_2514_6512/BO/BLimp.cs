using BL.BLapi;
using BL.BO;
using DLAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{

    class BLimp : IBL // internal: add manually.
    {

        IDL dl = DLFactory.GetDL();

        #region Bus
        public void AddBus(BO.Bus bus)
        {
            dl.addBus(Converter.BOtoDO_Bus<DLAPI.Bus, BO.Bus>(bus));
        }
        public void removeBus(int[] plate)
        {
            dl.removeBus(plate);
        }
        public BO.Bus GetBus(int[] plate)
        {
            return Converter.DOtoBO_Bus<BO.Bus, DLAPI.Bus>(dl.GetBus(plate));
        }
        public void UpdateBus(BO.Bus bus)
        {
            dl.Details(Converter.BOtoDO_Bus<DLAPI.Bus, BO.Bus>(bus));
        }
        public IEnumerable<BO.Bus> GetAllBuses()
        {
            var result = dl.GetAllBuses();
            return (from item in result
                    where (item != null)
                    select Converter.DOtoBO_Bus<BO.Bus, DLAPI.Bus>(item)).ToList();
        }
        public IEnumerable<BO.Bus> GetAllBuses_history()
        {
            var result = dl.GetAllBuses_history();
            return (from item in result
                    where (item != null)
                    orderby item.licensePlateArray ascending
                    select Converter.DOtoBO_Bus<BO.Bus, DLAPI.Bus>(item)).ToList();
        }
        #endregion

        #region BusLine
        public void addLine(BO.BusLine line)
        {
            dl.AddBusLine(Converter.BOtoDO_BusLine<DLAPI.BusLine, BO.BusLine>(line));
        }
        public void DeleteLine(int id)
        {
            dl.RemoveBusLine(id);
        }
        public void UpdateLine(BO.BusLine line)
        {
            dl.Details_Line(Converter.BOtoDO_BusLine<DLAPI.BusLine, BO.BusLine>(line));
        }
        public BO.BusLine GetBusLine(int id)
        {
            return Converter.DOtoBO_BusLine<BO.BusLine, DLAPI.BusLine>(dl.GetBusLine(id));
        }
        public IEnumerable<BO.BusLine> GetAllBusLines()
        {
            var result = dl.GetAllBusLines();
            return (from item in result
                    where (item != null)
                    orderby item.BusNumber ascending
                    select Converter.DOtoBO_BusLine<BO.BusLine, DLAPI.BusLine>(item)).ToList();
        }
        public IEnumerable<BO.BusLine> GetAllBusesLines_history()
        {
            var result = dl.GetAllBusLines_history();
            return (from item in result
                    where (item != null)
                    orderby item.BusNumber ascending
                    select Converter.DOtoBO_BusLine<BO.BusLine, DLAPI.BusLine>(item)).ToList();
        }
        #endregion

        #region BusStop
        public void addStop(BO.BusStop stop)
        {
            dl.addBusStop(Converter.BOtoDO_BusStop<DLAPI.BusStop, BO.BusStop>(stop));
        }
        public void DeleteStop(int key)
        {
            dl.removeBusStop(key);
        }
        public void UpdateStop(BO.BusStop stop)
        {
            dl.Details_BusStop(Converter.BOtoDO_BusStop<DLAPI.BusStop, BO.BusStop>(stop));
        }
        public BO.BusStop GetBusStop(int id)
        {
            return Converter.DOtoBO_BusStop<BO.BusStop, DLAPI.BusStop>(dl.GetBusStop(id));
        }
        public IEnumerable<BO.BusStop> GetAllBusStops()
        {
            var result = dl.GetAllBusStops();
            return (from item in result
                    where (item != null)
                    orderby item.BusStationKey ascending
                    select Converter.DOtoBO_BusStop<BO.BusStop, DLAPI.BusStop>(item)).ToList();
        }
        public IEnumerable<BO.BusStop> GetAllBusStops_history()
        {
            var result = dl.GetAllBusStops_history();
            return (from item in result
                    where (item != null)
                    orderby item.BusStationKey ascending
                    select Converter.DOtoBO_BusStop<BO.BusStop, DLAPI.BusStop>(item)).ToList();
        }

        public bool CheckIfExists(BO.BusStop stop)
        {
            var result = dl.GetAllBusStops();
            foreach (DLAPI.BusStop item in result)
            {
                if (item.BusStationKey == stop.BusStationKey)
                    return true;
            }
            return false;
        }
        #endregion

        #region LineStation
        public void addStation(BO.LineStation station)
        {
            dl.addStation(Converter.BOtoDO_LineStation<DLAPI.LineStation, BO.LineStation>(station));
        }
        public void DeleteLineStation(int id)
        {
            dl.removeLineStation(id);
        }
        public void UpdateLineStation(BO.LineStation station)
        {
            dl.Details_LineStation(Converter.BOtoDO_LineStation<DLAPI.LineStation, BO.LineStation>(station));
        }
        public BO.LineStation GetLineStation(int id)
        {
            return Converter.DOtoBO_LineStation<BO.LineStation, DLAPI.LineStation>(dl.GetLineStation(id));
        }
        public IEnumerable<BO.LineStation> GetAllLineStations()
        {
            var result = dl.GetLines();
            return (from item in result
                    where (item != null)
                    orderby item.BusStationKey ascending
                    select Converter.DOtoBO_LineStation<BO.LineStation, DLAPI.LineStation>(item)).ToList();
        }
        public IEnumerable<BO.LineStation> GetAllLineStations_history()
        {
            var result = dl.GetLines_history();
            return (from item in result
                    where (item != null)
                    orderby item.BusStationKey ascending
                    select Converter.DOtoBO_LineStation<BO.LineStation, DLAPI.LineStation>(item)).ToList();
        }
        #endregion

        #region LineCycle
        public void addLineCycle(BO.LineCycle cycle)
        {
            dl.addCycle(Converter.BOtoDO_LineCycle<DLAPI.LineCycle, BO.LineCycle>(cycle));
        }
        public void DeleteLineCycle(int id)
        {
            dl.removeLineStation(id);
        }
        public void UpdateLineCycle(BO.LineCycle cycle)
        {
            dl.Details_Cycle(Converter.BOtoDO_LineCycle<DLAPI.LineCycle, BO.LineCycle>(cycle));
        }
        public BO.LineCycle GetLineCycle(int id)
        {
            return Converter.DOtoBO_LineCycle<BO.LineCycle, DLAPI.LineCycle>(dl.GetCycle(id));
        }
        public IEnumerable<BO.LineCycle> GetAllLineCycles()
        {
            var result = dl.GetCycles();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_LineCycle<BO.LineCycle, DLAPI.LineCycle>(item)).ToList();
        }
        public IEnumerable<BO.LineCycle> GetAllLineCycles_history()
        {
            var result = dl.GetCycles_history();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_LineCycle<BO.LineCycle, DLAPI.LineCycle>(item)).ToList();
        }
        #endregion

        #region Moving_bus
        public void addMoving_bus(BO.Moving_bus station)
        {
            dl.addMoving_Bus(Converter.BOtoDO_Moving_bus<DLAPI.Moving_bus, BO.Moving_bus>(station));
        }
        public void DeleteMoving_bus(int id)
        {
            dl.removeMoving_Bus(id);
        }
        public void UpdateMoving_bus(BO.Moving_bus station)
        {
            dl.Details_Moving_Bus(Converter.BOtoDO_Moving_bus<DLAPI.Moving_bus, BO.Moving_bus>(station));
        }
        public BO.Moving_bus GetMoving_bus(int id)
        {
            return Converter.DOtoBO_Moving_bus<BO.Moving_bus, DLAPI.Moving_bus>(dl.GetMoving_Bus(id));
        }
        public IEnumerable<BO.Moving_bus> GetAllMoving_buses()
        {
            var result = dl.Moving_Bus();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_Moving_bus<BO.Moving_bus, DLAPI.Moving_bus>(item)).ToList();
        }
        public IEnumerable<BO.Moving_bus> GetAllMoving_buses_history()
        {
            var result = dl.Moving_Bus_history();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_Moving_bus<BO.Moving_bus, DLAPI.Moving_bus>(item)).ToList();
        }
        #endregion

        #region Twostops
        public void addTwostops(BO.Twostops station)
        {
            dl.addTwostops(Converter.BOtoDO_TwoStops<DLAPI.Twostops, BO.Twostops>(station));
        }
        public void DeleteTwostops(int id)
        {
            dl.removeTwostops(id);
        }
        public void UpdateTwostops(BO.Twostops station)
        {
            dl.Details_LineStation(Converter.BOtoDO_TwoStops<DLAPI.Twostops, BO.Twostops>(station));
        }
        public BO.Twostops GetTwostops(int id)
        {
            return Converter.DOtoBO_Twostops<BO.Twostops, DLAPI.Twostops>(dl.GetGetTwostopS(id));
        }
        public IEnumerable<BO.Twostops> GetAllTwostops()
        {
            var result = dl.GetTwostops();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_Twostops<BO.Twostops, DLAPI.Twostops>(item)).ToList();
        }
        public IEnumerable<BO.Twostops> GetAllTwostops_history()
        {
            var result = dl.GetTwostops_history();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_Twostops<BO.Twostops, DLAPI.Twostops>(item)).ToList();
        }

        public void UpdateBusesStatus(IEnumerable<BO.Bus> data)
        {
            var result = dl.GetAllBuses();
            IEnumerable<BO.Bus> get_to_update = (from item in result
                    where (item != null)
                    select Converter.DOtoBO_Bus<BO.Bus, DLAPI.Bus>(item)).ToList();
            foreach (var item in get_to_update)
            {
                if (item.can_go(1))
                {
                    item.Status = "Ready";
                }
                else
                {
                    item.Status = "Not Ready";
                }
            }
            foreach (var item in get_to_update)
            {
                dl.Details(Converter.BOtoDO_Bus<DLAPI.Bus, BO.Bus>(item));
            }
        }
        #endregion


        public double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }





















    }
}
