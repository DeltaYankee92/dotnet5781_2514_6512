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

        const int max_fuel = 1200;// to use as we go along: maximum fuel
        int current_fuel;
        DateTime registrationDate, lastMaintenance; // as requested.

        internal Buses()
        {

        }

    }
}
