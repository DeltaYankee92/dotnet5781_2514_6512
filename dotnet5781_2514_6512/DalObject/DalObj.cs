using DalApi.DO;
using DLAPI;
using DS;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalObject
{
    sealed class DalObject : IDL // implamenting the interface
    {
        static readonly DalObject instance = new DalObject();
        static bool comparearr(int[] arr1,int[] arr2)
        {
            if(arr1.Length!=arr2.Length)
            return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }
            return true;
        }
        #region bus
        public IEnumerable<Bus> GetAllBuses()
        {
            return from bus in AllData.List_Bus
                   select bus.Clone();
        }
        public Bus GetBus(int[] id)
        {
            throw new NotImplementedException();
        }
        public void removeBus(int id)
        {
            throw new NotImplementedException();
        }
        public void updateBus(Bus bus)
        {
            throw new NotImplementedException();

        }
        public void refuel(int id)
        {
            throw new NotImplementedException();
        }
        public void maintain(int id)
        {
            throw new NotImplementedException();
        }
        #endregion


      

        public void removebusLineStation(int id)
        {
            throw new NotImplementedException();
        }

        public void removeLine(int id)
        {
            throw new NotImplementedException();
        }


        public void updatebusLineStation(LineStation line)
        {
            throw new NotImplementedException();
        }

        public void updateLine(BusLine line)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusLine> GetAllbusLines()
        {
            throw new NotImplementedException();
        }

        public BusLine GetBusLine(int id)
        {
            throw new NotImplementedException();
        }

        public void addLine(BusLine line)
        {
            throw new NotImplementedException();
        }

        public void addStation(BusLine station)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetAllbusLineStation()
        {
            throw new NotImplementedException();
        }

        public LineStation GetbusLineStation(int id)
        {
            throw new NotImplementedException();
        }

        public Bus GetBus(int id)
        {
            throw new NotImplementedException();
        }

        public void addBus(Bus bus)
        {
            throw new NotImplementedException();
        }
    }
}
