using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BO;


namespace BL.BLapi
{
    public interface IBL
    {
        #region Bus
        IEnumerable<BO.Bus> GetAllBuses();
        Bus GetBus(int[] plate);
        void AddBus(Bus bus);
        void removeBus(int[] plate);
        void UpdateBus(int[] plate);
        #endregion

        #region BusLine
        IEnumerable<BO.BusLine> GetAllBusLines();
        BusLine GetBusLine(int id);
        void DeleteLine(int id);
        void UpdateLine(BusLine line);
        #endregion

        #region BusStop
        IEnumerable<BO.BusStop> GetAllStops();
        BusStop GetBusStop(int id);
        void DeleteStop(BusStop stop);
        void UpdateStop(BusStop stop);
        #endregion

        #region LineStation
        IEnumerable<BO.LineStation> GetAllLineStatons();
        LineStation GetLineStation(int id);
        void addStation(LineStation station);
        void DeleteLineStation(int id);
        void UpdateLineStation(LineStation station);
        #endregion

    }
}
