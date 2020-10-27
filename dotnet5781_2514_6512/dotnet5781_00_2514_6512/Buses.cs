using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{
    class Buses
    {
        int[] license_plate; //not determining the size here, because there are 2 options. we will add the '-'s to the print function. 
        int milage;
        int milage_total; // kilometrag'

        int current_fuel;
        DateTime registrationDate, MaintenanceDate; // as requested.


        public Buses(DateTime date, int[] id, int v1, int v2, int v3) 
        {

        }

        internal void print_mileage()
        {
            throw new NotImplementedException();
        }

        internal int[] getplate()
        {
            throw new NotImplementedException();
        }

        internal void fuel_up()
        {
            throw new NotImplementedException();
        }

        internal void fix()
        {
            throw new NotImplementedException();
        }

        internal bool can_go(int amount_to_drive)
        {
            throw new NotImplementedException();
        }

        internal void drive(int amount_to_drive)
        {
            throw new NotImplementedException();
        }
    }
}
