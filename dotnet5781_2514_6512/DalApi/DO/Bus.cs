using System;

namespace DalApi.DO
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

        #endregion

    }
}
