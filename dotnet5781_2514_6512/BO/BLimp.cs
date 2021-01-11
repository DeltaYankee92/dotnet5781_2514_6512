using BL.BLapi;
using BL.BO;
using DLAPI;
using System;
using System.Collections.Generic;


namespace BL
{

    class BLimp :IBL // internal: add manually.
    {
        #region Bus Functions
        IDL dl = DLFactory.GetDL();
        public void addBus(Bus bus)
        {
            dl.addBus(DeepCopy.BLtoDAL_Bus<DalApi.DO.Bus, BO.Bus>(bus));
        }

        public void AddBus(Bus bus)
        {
            dl.addBus(DeepCopy.BLtoDAL_Bus<DalApi.DO.Bus, BO.Bus>(bus));
        }
        #endregion

        #region BusLine Functions
        public void DeleteLine(int linenum)
        {
            dl.RemoveBusLine(DeepCopy.BLtoDAL_BusLine<DalApi.DO.BusLine, BO.BusLine>(linenum));
        }
        #endregion

        #region BusStop Functions
        public void DeleteStop(BusStop stop)
        {
            throw new NotImplementedException();   //No function in IDL
        }
        #endregion

        #region LineStation Functions
        public void addStation(LineStation station)
        {
            dl.addStation(DeepCopy.BLtoDAL_LineStation<DalApi.DO.LineStation, BO.LineStation>(station));
        }
        public void DeleteLineStation(LineStation station)
        {
            dl.removeLineStation(DeepCopy.BLtoDAL_LineStation<DalApi.DO.LineStation, BO.LineStation>(station));
        }
        #endregion


        //public void removeBus(int[] plate)
        //{
        //    dl.removeBus(DeepCopy.BLtoDAL_Bus<DalApi.DO.Bus, BO.Bus>(bus));
        //}
        public Bus GetBus(int[] plate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetBuses()
        {
            throw new NotImplementedException();
        }

        public BusLine GetBusLine(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusLine> GetBusLines()
        {
            throw new NotImplementedException();
        }

        public BusStop GetBusStop(int id)
        {
            throw new NotImplementedException();
        }

        public LineStation GetLineStation(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetLineStatons()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusStop> GetStops()
        {
            throw new NotImplementedException();
        }

        public void UpdateBus(int[] plate)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(BusLine line)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(LineStation station)
        {
            throw new NotImplementedException();
        }

        public void UpdateStop(BusStop stop)
        {
            throw new NotImplementedException();
        }
    }

}
