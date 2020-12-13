using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_03B_2514_6512
{
    //enum status { NotReady, Ready, Driving};
    public class Buses
    {
        
        public int[] license_plate {get; set; }
        public int milage { get; set; }
        public int milage_total  { get; set; }
        public int LastMaintenance { get; set; }
        public int current_fuel { get; set; }
        public DateTime registrationDate { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Status { get; set; }
        public string License_Plate { get; set; }


        public Buses(DateTime date, int[] id, int v1, int v2, int v3) 
        {
            MaintenanceDate = date;
            license_plate = id;
            milage = v1;
            milage_total += milage;
            LastMaintenance = v2;
            current_fuel = v3;
            MaintenanceDate = date;
            Status = "Ready";
            License_Plate = turn_to_string();
            registrationDate = DateTime.Now;
        }

        internal void print_mileage()
        {
            Console.Write("the bus with the ID: ");
            print(this);
            Console.WriteLine("Drove: {0} kilometers", milage_total);
        }

        internal int[] getplate()
        {
            return license_plate;
        }
        public bool compare_plate(Buses b1)
        {
            int x = this.getplate().Length; // to prevent accessive use of .get() and length
            if (x != b1.getplate().Length)
                return false;
            else
            {
                for (int i = 0; i < x; i++)
                    if (this.getplate()[i] != b1.getplate()[i])
                        return false;
            }
            return true;
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

        public string turn_to_string(int[] arr)
        {
            string x = "";
            for (int i = 0; i < arr.Length; i++)
            {
                x += (arr[i]).ToString();
            }
            return x;
        }
        public override string ToString()
        {
            //return $"{turn_to_string()} bus, with the status of {Status}";
            return $"Bus with license plate: {License_Plate}. \n Milage: {milage_total} \n Fuel: {current_fuel} \n Registered Date: {registrationDate} \n Last Maintenace: {MaintenanceDate}, at: {LastMaintenance} kilometers.";
        }

    }
}
