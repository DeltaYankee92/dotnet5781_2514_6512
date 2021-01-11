using BL.BLapi;
using BL.BO;
using DLAPI;
using System;
using System.Collections.Generic;


namespace BL
{
    
    class BLimp : IBL // internal: add manually.
    {
        
        IDL dl = DLFactory.GetDL();

        #region Bus
        public void AddBus(Bus bus)
        {
            dl.addBus(Utility.BOtoDO_Bus<DalApi.DO.Bus, BO.Bus>(bus));
        }
        public void removeBus(int[] plate)
        {
            dl.removeBus(plate);
        }
        public Bus GetBus(int[] plate)
        {
            return Utility.DOtoBO_Bus<BO.Bus, DalApi.DO.Bus>(dl.GetBus(plate));
        }
        public void UpdateBus(int[] plate)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Bus> GetAllBuses()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region BusLine
        public void DeleteLine(int id)
        {
            dl.RemoveBusLine(id);
        }
        public void UpdateLine(BusLine line)
        {
            throw new NotImplementedException();
        }
        public BusLine GetBusLine(int id)
        {
            return Utility.DOtoBO_BusLine<BO.BusLine, DalApi.DO.BusLine>(dl.GetBusLine(id));
        }
        public IEnumerable<BusLine> GetAllBusLines()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region BusStop
        public void DeleteStop(BusStop stop)
        {
            throw new NotImplementedException();
        }
        public void UpdateStop(BusStop stop)
        {
            throw new NotImplementedException();
        }
        public BusStop GetBusStop(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<BusStop> GetAllStops()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region LineStation
        public void addStation(LineStation station)
        {
            dl.addStation(Utility.BOtoDO_LineStation<DalApi.DO.LineStation, BO.LineStation>(station));
        }
        public void DeleteLineStation(int id)
        {
            dl.removeLineStation(id);
        }
        public void UpdateLineStation(LineStation station)
        {
            throw new NotImplementedException();
        }
        public LineStation GetLineStation(int id)
        {
            return Utility.DOtoBO_LineStation<BO.LineStation, DalApi.DO.LineStation>(dl.GetLineStation(id));
        }
        public IEnumerable<LineStation> GetAllLineStatons()
        {
            throw new NotImplementedException();
        }
        #endregion

        

        


























    }
}
