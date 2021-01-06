using System;
using System.Collections.Generic;
using DalApi.DO;


namespace DLAPI
{
    //CRUD Logic:
    // Create - add new instance
    // Request - ask for an instance or for a collection
    // Update - update properties of an instance
    // Delete - delete an instance
    public interface IDL
    {
        #region Bus
        IEnumerable<Bus> GetAllBuses();
        Bus GetBus(int id);
        void addBus(Bus bus);
        void removeBus(int id);
        void updateBus(Bus bus);
        void refuel(int id);
        void maintain(int id);

        #endregion

        #region busLine 
        
        IEnumerable<BusLine> GetAllbusLines();
        BusLine GetBusLine(int id);
        void addLine(BusLine line);
        void removeLine(int id);
        void updateLine(BusLine line);
        #endregion

        #region LineStation
        void addStation(BusLine station);
        IEnumerable<LineStation> GetAllbusLineStation();
        LineStation GetbusLineStation(int id);
        void removebusLineStation(int id);
        void updatebusLineStation(LineStation line);

        #endregion


    }
}
