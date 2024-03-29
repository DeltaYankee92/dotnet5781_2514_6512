﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    enum status { NotReady, Ready};
    public class Buses
    {
        string license_plate;
        //int[] license_plate; //not determining the size here, because there are 2 options. we will add the '-'s to the print function. 
        int milage;       //milage since last maintenance
        int milage_total; // kilometrag'
        int LastMaintenance;  //km number of last maintenance
        int current_fuel;     //fuel used by km
        DateTime registrationDate, MaintenanceDate; // as requested.
        status Status;


        public Buses(DateTime date, string id, int v1, int v2, int v3) 
        {
            
            registrationDate = date;
            license_plate = id;
            milage = v1;
            LastMaintenance = v2;
            current_fuel = v3;
            MaintenanceDate = date;
            Status = status.Ready;

        }

        internal void print_mileage()
        {
            Console.Write("the bus with the ID: ");
            print(this);
            Console.WriteLine("Drove: {0} kilometers", milage_total);
        }

        string getplate()
        {
            return license_plate;
        }

        internal void fuel_up()
        {
            current_fuel = 1200;
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
                Console.WriteLine("Bus needs maintenance!");
                return false;
            }
            if (current_fuel<amount_to_drive)
            {
                Console.WriteLine("Not enough fuel!");
                return false;
            }
            if (current_fuel-amount_to_drive < 0)
            {
                Console.WriteLine("Not enough fuel!");
                return false;
            }
            return true;
        }

        internal void drive(int amount_to_drive)
        {
            milage += amount_to_drive;
            milage_total += amount_to_drive;
            current_fuel -= amount_to_drive;
        }

        internal void print(Buses bus)
        {
            if (license_plate.Length == 7)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.Write("{0}", license_plate[i]);
                }
                Console.Write("-");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{0}", license_plate[i]);
                }
                Console.Write("-");
                for (int i = 0; i < 2; i++)
                {
                    Console.Write("{0}", license_plate[i]);
                }
            }
            else if (license_plate.Length == 8)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{0}", license_plate[i]);
                }
                Console.Write("-");
                for (int i = 0; i < 2; i++)
                {
                    Console.Write("{0}", license_plate[i]);
                }
                Console.Write("-");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{0}", license_plate[i]);
                }
            }
            Console.WriteLine();
        }

        public string turn_to_string()
        {
            string x="";
            for (int i = 0; i < license_plate.Length; i++)
            {
                x += (license_plate[i]).ToString();
            }
            return x;
        }
        public override string ToString()
        {
            return $"{turn_to_string()} bus, with the status of {Status}";
        }

    }
}
