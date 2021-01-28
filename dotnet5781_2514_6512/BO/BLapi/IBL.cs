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
        IEnumerable<Bus> GetAllBuses_history();
        Bus GetBus(int[] plate);
        void AddBus(Bus bus);
        void removeBus(int[] plate);
        void UpdateBus(Bus bus);
        #endregion

        #region BusLine
        IEnumerable<BusLine> GetAllBusLines();
        IEnumerable<BusLine> GetAllBusesLines_history();
        void addLine(BusLine line);
        BusLine GetBusLine(int id);
        void DeleteLine(int id);
        void UpdateLine(BusLine line);
        #endregion

        #region BusStop
        IEnumerable<BusStop> GetAllBusStops();
        IEnumerable<BusStop> GetAllBusStops_history();
        void addStop(BusStop stop);
        BusStop GetBusStop(int id);
        void DeleteStop(int key);
        void UpdateStop(BusStop stop);
        bool CheckIfExists(BusStop stop);
        #endregion

        #region LineStation
        IEnumerable<LineStation> GetAllLineStations();
        IEnumerable<LineStation> GetAllLineStations_history();
        LineStation GetLineStation(int id);
        void addStation(LineStation station);
        void DeleteLineStation(int id);
        void UpdateLineStation(LineStation station);
        #endregion

        #region Moving_bus
        void addMoving_bus(Moving_bus station);
        void DeleteMoving_bus(int id);
        void UpdateMoving_bus(Moving_bus station);
        Moving_bus GetMoving_bus(int id);
        IEnumerable<Moving_bus> GetAllMoving_buses();
        IEnumerable<Moving_bus> GetAllMoving_buses_history();

        #endregion

        #region LineCycle
        void addLineCycle(LineCycle cycle);
        void DeleteLineCycle(int id);
        void UpdateLineCycle(LineCycle cycle);
        LineCycle GetLineCycle(int id);
        IEnumerable<LineCycle> GetAllLineCycles();
        IEnumerable<LineCycle> GetAllLineCycles_history();
        #endregion

        #region Twostops
        void addTwostops(Twostops station);
        void DeleteTwostops(int id);
        void UpdateTwostops(Twostops station);
        Twostops GetTwostops(int id);
        IEnumerable<Twostops> GetAllTwostops();
        IEnumerable<Twostops> GetAllTwostops_history();


        #endregion

        void UpdateBusesStatus(IEnumerable<Bus> data);

        double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K');


    }
}
