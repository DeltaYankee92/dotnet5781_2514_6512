using System;

namespace DLAPI
{
    //enum status { NotReady, Ready, Driving};
    public class Bus : Activity
    {
        #region 
        public int[] licensePlateArray { get; set; }
        public int Milage { get; set; }
        public int MilageTotal { get; set; }
        public int LastMaintenance { get; set; }
        public int Current_Fuel { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Status { get; set; }
        public string License_Plate { get; set; }



        public Bus()
        {
            isactive = true;
        }

        public Bus(int[] licensePlateArray, int milage, int milageTotal, int lastMaintenance, int current_Fuel, DateTime registrationDate, DateTime maintenanceDate, string status)
        {
            this.licensePlateArray = new int[licensePlateArray.Length];
            for (int i = 0; i < licensePlateArray.Length; i++)
            {
                this.licensePlateArray[i] = licensePlateArray[i];
            }
            Milage = milage;
            MilageTotal = milageTotal;
            LastMaintenance = lastMaintenance;
            Current_Fuel = current_Fuel;
            RegistrationDate = registrationDate;
            MaintenanceDate = maintenanceDate;
            Status = status;
            License_Plate = turn_to_string(licensePlateArray);
            isactive = true;
        }

        public string turn_to_string()
        {
            string x = "";
            for (int i = 0; i < licensePlateArray.Length; i++)
            {
                x += (licensePlateArray[i]).ToString();
            }
            return x;

        }

        public static string turn_to_string(int[] arr)
        {
            string x = "";
            for (int i = 0; i < arr.Length; i++)
            {
                x += (arr[i]).ToString();
            }
            return x;
        }
        public void fuel_up()
        {
            Current_Fuel = 5000;
        }

        public void fix()
        {
            MaintenanceDate = DateTime.Now;
            LastMaintenance = MilageTotal;
            Milage = 0;
            this.Status = "Ready";
        }

        public override string ToString()
        {
            return $"{this.turn_to_string()} hello";
        }
        #endregion

    }
}
