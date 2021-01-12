using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DalApi.DO
{

   public class BusStop : Activity
    {
        #region fields
        public Random rand = new Random();
        public int BusStationKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string adress { get; set; }

        #endregion

    }
}
