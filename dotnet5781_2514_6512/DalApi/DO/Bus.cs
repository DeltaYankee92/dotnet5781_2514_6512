﻿using System;

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

        public Bus(DateTime date, int[] id, int milage, int last_maintenance, int total_milage, int current_fuel)
        {
            MaintenanceDate = date;
            licensePlateArray = id;
            MilageTotal = total_milage;
            LastMaintenance = last_maintenance;
            Current_Fuel = current_fuel;
            MaintenanceDate = date;
            Milage = MilageTotal - LastMaintenance;
            if ((20000 < MilageTotal - LastMaintenance) || (Current_Fuel == 0))
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

        public Bus()
        {

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

        public string turn_to_string(int[] arr)
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

        #endregion

    }
}
