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
        IEnumerable<Bus> GetAllBuses_history();//cRud
        void Details(Bus bus); // crUd
        void Fuel(int[] plate); // crUd
        void Maintain(int[] plate); //crUd
        void removeBus(int[] plate); // cruD
        #endregion

        #region busLine 

        void AddBusLine(BusLine line); // Crud
        IEnumerable<BusLine> GetAllBusLines(); //cRud
        IEnumerable<BusLine> GetAllBusLines_history(); //cRud
        BusLine GetBusLine(int linenum); //cRud
        void Details_Line(BusLine line);//crUd
        void RemoveBusLine(int linenum);// cruD
        #endregion

        #region LineStation
        void addStation(LineStation line); //Crud
        IEnumerable<LineStation> GetLines(); //cRud
        IEnumerable<LineStation> GetLines_history(); //cRud
        LineStation GetLineStation(int linenum); //cRud
        void removeLineStation(int linenum); //crUd
        void Details_LineStation(LineStation line); //cruD
        #endregion


        #region LineCycle
        void addCycle(LineCycle line); //Crud
        IEnumerable<LineCycle> GetCycles(); //cRud
        IEnumerable<LineCycle> GetCycles_history(); //cRud
        LineCycle GetCycle(int counted); //cRud
        void RemoveCycle(int counted); //crUd
        void Details_Cycle(LineCycle line); //cruD
        #endregion

        #region Moving_bus

        void addMoving_Bus(Moving_bus bus); //Crud
        IEnumerable<Moving_bus> Moving_Bus(); //cRud
        IEnumerable<Moving_bus> Moving_Bus_history(); //cRud
        Moving_bus GetMoving_Bus(int counted); //cRud
        void removeMoving_Bus(int counted); //crUd
        void Details_Moving_Bus(Moving_bus bus); //cruD

        #endregion

        #region Twostops

        void addTwostops(Twostops route); //Crud
        IEnumerable<Twostops> GetTwostops(); //cRud
        IEnumerable<Twostops> GetTwostops_history(); //cRud
        Twostops GetGetTwostopS(int counted); //cRud
        void removeTwostops(int counted); //crUd
        void Details_LineStation(Twostops route); //cruD

        #endregion

    }
}
