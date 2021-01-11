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
        IEnumerable<Bus> GetBuses();

        Bus GetBus(int[] plate);

        void AddBus(Bus bus);

        //void removeBus(int[] plate);

        void UpdateBus(int[] plate);
        #endregion

        #region BusLine
        IEnumerable<BusLine> GetBusLines();
        BusLine GetBusLine(int id);
        void DeleteLine(int linenum);
        void UpdateLine(BusLine line);
        #endregion

        #region BusStop
        IEnumerable<BusStop> GetStops();
        BusStop GetBusStop(int id);
        void DeleteStop(BusStop stop);
        void UpdateStop(BusStop stop);
        #endregion

        #region LineStation
        IEnumerable<LineStation> GetLineStatons();
        LineStation GetLineStation(int id);
        void addStation(LineStation station);
        void DeleteLineStation(LineStation station);
        void UpdateLineStation(LineStation station);
        #endregion

    }
}
