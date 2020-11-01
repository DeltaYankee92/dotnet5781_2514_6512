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
        int milage;       //milage since last maintenance
        int milage_total; // kilometrag'
        int LastMaintenance;  //km number of last maintenance
        int current_fuel;     //fuel used by km
        DateTime registrationDate, MaintenanceDate; // as requested.


        public Buses(DateTime date, int[] id, int v1, int v2, int v3) 
        {

        }

        internal void print_mileage()
        {
            Console.WriteLine("The milage of the bus is: {0}", milage_total);
        }

        internal int[] getplate()
        {
            return license_plate;
        }

        internal void fuel_up()
        {
            current_fuel = 0;
        }

        internal void fix()
        {
            MaintenanceDate = DateTime.Now;
            LastMaintenance = milage_total;
            milage = 0;
        }

        internal bool can_go(int amount_to_drive)
        {
            if ((LastMaintenance+amount_to_drive) >= (LastMaintenance+20000))
            {
                return false;
            }
            if (current_fuel+amount_to_drive > 1200)
            {
                return false;
            }
            return true;
        }

        internal void drive(int amount_to_drive)
        {
            milage += amount_to_drive;
            milage_total += amount_to_drive;
            current_fuel += amount_to_drive;
        }
    }
}
