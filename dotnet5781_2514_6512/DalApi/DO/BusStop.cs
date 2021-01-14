using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DLAPI
{

   public class BusStop : Activity
    {
        #region fields
        public int BusStationKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string adress { get; set; }
        public BusStop()
        {
            isactive = true;
        }
        public BusStop(int busStationKey, double latitude, double longitude, string adress)
        {
            BusStationKey = busStationKey;
            Latitude = latitude;
            Longitude = longitude;
            this.adress = adress;
            isactive = true;
        }


        #endregion

    }
}
