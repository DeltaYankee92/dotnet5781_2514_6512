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

        void addBus(Bus bus); // Crud

        Bus GetBus(int[] plate);//cRud
        IEnumerable<Bus> GetAllBuses();//cRud
        void Details(Bus bus); // crUd
        void Fuel(int[] plate); // crUd
        void Maintain(int[] plate); //crUd

        void removeBus(int[] plate); // cruD
        #endregion

        #region busLine 

        void AddBusLine(BusLine line); // Crud
        IEnumerable<BusLine> GetAllBusLines(); //cRud
        BusLine GetBusLine(int linenum); //cRud
        void Details_Line(BusLine line);//crUd
        void RemoveBusLine(int linenum);// cruD
        #endregion

        #region LineStation
        void addStation(LineStation line); //Crud
        IEnumerable<LineStation> GetLines(); //cRud
        LineStation GetLineStation(int linenum); //cRud
        void removeLineStation(int linenum); //crUd
        void Details_LineStation(LineStation line); //cruD

        #endregion


    }
}
