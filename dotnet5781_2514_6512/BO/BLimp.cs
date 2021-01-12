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
        public void AddBus(Bus bus)
        {
            dl.addBus(Converter.BOtoDO_Bus<DalApi.DO.Bus, BO.Bus>(bus));
        }
        public void removeBus(int[] plate)
        {
            dl.removeBus(plate);
        }
        public Bus GetBus(int[] plate)
        {
            return Converter.DOtoBO_Bus<BO.Bus, DalApi.DO.Bus>(dl.GetBus(plate));
        }
        public void UpdateBus(Bus bus)
        {
            dl.Details(Converter.BOtoDO_Bus<DalApi.DO.Bus, BO.Bus>(bus));
        }
        public IEnumerable<Bus> GetAllBuses()
        {
            var result = dl.GetAllBuses();
            return (from item in result
                    where (item != null)
                    orderby item.licensePlateArray ascending
                    select Converter.DOtoBO_Bus<BO.Bus, DalApi.DO.Bus>(item)).ToList();
        }
        public IEnumerable<Bus> GetAllBuses_history()
        {
            var result = dl.GetAllBuses_history();
            return (from item in result
                    where (item != null)
                    orderby item.licensePlateArray ascending
                    select Converter.DOtoBO_Bus<BO.Bus, DalApi.DO.Bus>(item)).ToList();
        }
        #endregion

        #region BusLine
        public void addLine(BusLine line)
        {
            dl.AddBusLine(Converter.BOtoDO_BusLine<DalApi.DO.BusLine, BO.BusLine>(line));
        }
        public void DeleteLine(int id)
        {
            dl.RemoveBusLine(id);
        }
        public void UpdateLine(BusLine line)
        {
            dl.Details_Line(Converter.BOtoDO_BusLine<DalApi.DO.BusLine, BO.BusLine>(line));
        }
        public BusLine GetBusLine(int id)
        {
            return Converter.DOtoBO_BusLine<BO.BusLine, DalApi.DO.BusLine>(dl.GetBusLine(id));
        }
        public IEnumerable<BusLine> GetAllBuseLines()
        {
            var result = dl.GetAllBusLines();
            return (from item in result
                    where (item != null)
                    orderby item.BusNumber ascending
                    select Converter.DOtoBO_BusLine<BO.BusLine, DalApi.DO.BusLine>(item)).ToList();
        }
        public IEnumerable<BusLine> GetAllBusesLines_history()
        {
            var result = dl.GetAllBusLines_history();
            return (from item in result
                    where (item != null)
                    orderby item.BusNumber ascending
                    select Converter.DOtoBO_BusLine<BO.BusLine, DalApi.DO.BusLine>(item)).ToList();
        }
        #endregion

        #region BusStop
        public void addStop(BusStop stop)
        {
            dl.addBusStop(Converter.BOtoDO_BusStop<DalApi.DO.BusStop, BO.BusStop>(stop));
        }
        public void DeleteStop(int key)
        {
            dl.removeBusStop(key);
        }
        public void UpdateStop(BusStop stop)
        {
            dl.Details_BusStop(Converter.BOtoDO_BusStop<DalApi.DO.BusStop, BO.BusStop>(stop));
        }
        public BusStop GetBusStop(int id)
        {
            return Converter.DOtoBO_BusStop<BO.BusStop, DalApi.DO.BusStop>(dl.GetBusStop(id));
        }
        public IEnumerable<BusStop> GetAllBusStops()
        {
            var result = dl.GetAllBusStops();
            return (from item in result
                    where (item != null)
                    orderby item.BusStationKey ascending
                    select Converter.DOtoBO_BusStop<BO.BusStop, DalApi.DO.BusStop>(item)).ToList();
        }
        public IEnumerable<BusStop> GetAllBusStops_history()
        {
            var result = dl.GetAllBusStops_history();
            return (from item in result
                    where (item != null)
                    orderby item.BusStationKey ascending
                    select Converter.DOtoBO_BusStop<BO.BusStop, DalApi.DO.BusStop>(item)).ToList();
        }
        #endregion

        #region LineStation
        public void addStation(LineStation station)
        {
            dl.addStation(Converter.BOtoDO_LineStation<DalApi.DO.LineStation, BO.LineStation>(station));
        }
        public void DeleteLineStation(int id)
        {
            dl.removeLineStation(id);
        }
        public void UpdateLineStation(LineStation station)
        {
            dl.Details_LineStation(Converter.BOtoDO_LineStation<DalApi.DO.LineStation, BO.LineStation>(station));
        }
        public LineStation GetLineStation(int id)
        {
            return Converter.DOtoBO_LineStation<BO.LineStation, DalApi.DO.LineStation>(dl.GetLineStation(id));
        }
        public IEnumerable<LineStation> GetAllLineStations()
        {
            var result = dl.GetLines();
            return (from item in result
                    where (item != null)
                    orderby item.BusStationKey ascending
                    select Converter.DOtoBO_LineStation<BO.LineStation, DalApi.DO.LineStation>(item)).ToList();
        }
        public IEnumerable<LineStation> GetAllLineStations_history()
        {
            var result = dl.GetLines_history();
            return (from item in result
                    where (item != null)
                    orderby item.BusStationKey ascending
                    select Converter.DOtoBO_LineStation<BO.LineStation, DalApi.DO.LineStation>(item)).ToList();
        }
        #endregion

        #region LineCycle
        public void addLineCycle(LineCycle cycle)
        {
            dl.addCycle(Converter.BOtoDO_LineCycle<DalApi.DO.LineCycle, BO.LineCycle>(cycle));
        }
        public void DeleteLineCycle(int id)
        {
            dl.removeLineStation(id);
        }
        public void UpdateLineCycle(LineCycle cycle)
        {
            dl.Details_Cycle(Converter.BOtoDO_LineCycle<DalApi.DO.LineCycle, BO.LineCycle>(cycle));
        }
        public LineCycle GetLineCycle(int id)
        {
            return Converter.DOtoBO_LineCycle<BO.LineCycle, DalApi.DO.LineCycle>(dl.GetCycle(id));
        }
        public IEnumerable<LineCycle> GetAllLineCycles()
        {
            var result = dl.GetCycles();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_LineCycle<BO.LineCycle, DalApi.DO.LineCycle>(item)).ToList();
        }
        public IEnumerable<LineCycle> GetAllLineCycles_history()
        {
            var result = dl.GetCycles_history();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_LineCycle<BO.LineCycle, DalApi.DO.LineCycle>(item)).ToList();
        }
        #endregion

        #region Moving_bus
        public void addMoving_bus(Moving_bus station)
        {
            dl.addMoving_Bus(Converter.BOtoDO_Moving_bus<DalApi.DO.Moving_bus, BO.Moving_bus>(station));
        }
        public void DeleteMoving_bus(int id)
        {
            dl.removeMoving_Bus(id);
        }
        public void UpdateMoving_bus(Moving_bus station)
        {
            dl.Details_Moving_Bus(Converter.BOtoDO_Moving_bus<DalApi.DO.Moving_bus, BO.Moving_bus>(station));
        }
        public Moving_bus GetMoving_bus(int id)
        {
            return Converter.DOtoBO_Moving_bus<BO.Moving_bus, DalApi.DO.Moving_bus>(dl.GetMoving_Bus(id));
        }
        public IEnumerable<Moving_bus> GetAllMoving_buses()
        {
            var result = dl.Moving_Bus();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_Moving_bus<BO.Moving_bus, DalApi.DO.Moving_bus>(item)).ToList();
        }
        public IEnumerable<Moving_bus> GetAllMoving_buses_history()
        {
            var result = dl.Moving_Bus_history();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_Moving_bus<BO.Moving_bus, DalApi.DO.Moving_bus>(item)).ToList();
        }
        #endregion

        #region Twostops
        public void addTwostops(Twostops station)
        {
            dl.addTwostops(Converter.BOtoDO_TwoStops<DalApi.DO.Twostops, BO.Twostops>(station));
        }
        public void DeleteTwostops(int id)
        {
            dl.removeTwostops(id);
        }
        public void UpdateTwostops(Twostops station)
        {
            dl.Details_LineStation(Converter.BOtoDO_TwoStops<DalApi.DO.Twostops, BO.Twostops>(station));
        }
        public Twostops GetTwostops(int id)
        {
            return Converter.DOtoBO_Twostops<BO.Twostops, DalApi.DO.Twostops>(dl.GetGetTwostopS(id));
        }
        public IEnumerable<Twostops> GetAllTwostops()
        {
            var result = dl.GetTwostops();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_Twostops<BO.Twostops, DalApi.DO.Twostops>(item)).ToList();
        }
        public IEnumerable<Twostops> GetAllTwostops_history()
        {
            var result = dl.GetTwostops_history();
            return (from item in result
                    where (item != null)
                    orderby item.id ascending
                    select Converter.DOtoBO_Twostops<BO.Twostops, DalApi.DO.Twostops>(item)).ToList();
        }
        #endregion
























    }
}
