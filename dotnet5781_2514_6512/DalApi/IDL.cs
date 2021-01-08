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
        Bus GetBus(int[] plate);
        void addBus(Bus bus);
        void removeBus(int[] plate);
        void Details(Bus bus);
        void Fuel(int[] plate);
        void Maintain(int[] plate);

        #endregion

        #region busLine 
        
        IEnumerable<BusLine> GetAllBusLines();
        BusLine GetBusLines(int linenum);
        void AddBusLine(BusLine line);
        void RemoveBusLine(int linenum);
        void Details_Line(BusLine line);
        #endregion

        #region LineStation
        void addStation(BusLine station);
        IEnumerable<LineStation> GetAllbusLineStation();
        LineStation GetbusLineStation(int[] id);
        void removebusLineStation(int[] id);
        void updatebusLineStation(LineStation line);

        #endregion


    }
}
