using System;

namespace dotnet5781_03B_2514_6512
{
    //enum status { NotReady, Ready, Driving};
    public class Buses  
    {
        
        public int[] licensePlateArray {get; set; }
        public int Milage { get; set; }
        public int MilageTotal  { get; set; }
        public int LastMaintenance { get; set; }
        public int Current_Fuel { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Status { get; set; }
        public string License_Plate { get; set; }
        private Timerclasstest Time;
        public Timerclasstest time 
        { get =>Time;
            set
            {
                this.Time = value;            
            } }


        public Buses(DateTime date, int[] id, int milage, int last_maintenance, int total_milage, int current_fuel) 
        {
            MaintenanceDate = date;
            licensePlateArray = id;
            MilageTotal = total_milage;
            LastMaintenance = last_maintenance;
            Current_Fuel = current_fuel;
            MaintenanceDate = date;
            Milage = MilageTotal - LastMaintenance;
            if ((20000 < MilageTotal-LastMaintenance)||(Current_Fuel == 0))
            {
                Status = "Not Ready";
            }
            else
            {
                Status = "Ready";
            }
            License_Plate = turn_to_string();
            RegistrationDate = DateTime.Now;
        }

        internal void print_mileage()
        {
            Console.Write("the bus with the ID: ");
            print(this);
            Console.WriteLine("Drove: {0} kilometers", MilageTotal);
        }

        internal int[] getplate()
        {
            return licensePlateArray;
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
            Current_Fuel = 5000;
        }

        internal void fix()
        {
            MaintenanceDate = DateTime.Now;
            LastMaintenance = MilageTotal;
            Milage = 0;
            this.Status = "Ready";
        }

        internal bool can_go(int amount_to_drive)
        {
            if ((LastMaintenance+amount_to_drive) >= (LastMaintenance+20000))
            {
                return false;
            }
            if (Current_Fuel<amount_to_drive)
            {
                return false;
            }
            if (Current_Fuel-amount_to_drive < 0)
            {
                return false;
            }
            return true;
        }

        internal void drive(int amount_to_drive)
        {
            Milage += amount_to_drive;
            MilageTotal += amount_to_drive;
            Current_Fuel -= amount_to_drive;
            if (this.Milage >= 20000)
            {
                this.Status = "Not Ready";
            }
        }

        internal void print(Buses bus)
        {
            if (licensePlateArray.Length == 7)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.Write("{0}", licensePlateArray[i]);
                }
                Console.Write("-");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{0}", licensePlateArray[i]);
                }
                Console.Write("-");
                for (int i = 0; i < 2; i++)
                {
                    Console.Write("{0}", licensePlateArray[i]);
                }
            }
            else if (licensePlateArray.Length == 8)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{0}", licensePlateArray[i]);
                }
                Console.Write("-");
                for (int i = 0; i < 2; i++)
                {
                    Console.Write("{0}", licensePlateArray[i]);
                }
                Console.Write("-");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{0}", licensePlateArray[i]);
                }
            }
            Console.WriteLine();
        }

        public string turn_to_string()
        {
            string x="";
            for (int i = 0; i < licensePlateArray.Length; i++)
            {
                x += (licensePlateArray[i]).ToString();
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
            return $"Bus with license plate: {License_Plate}. \n Milage: {MilageTotal} \n Fuel: {Current_Fuel} \n Registered Date: {RegistrationDate} \n Last Maintenace: {MaintenanceDate}, at: {LastMaintenance} kilometers. \n Next Maintenance in: {20000-Milage} \n Status: {Status}" ;
        }

    }
}
