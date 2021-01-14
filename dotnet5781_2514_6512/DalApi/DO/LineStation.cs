using DLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DLAPI
{
    public class LineStation : BusStop
    {


        #region fields
        //distance from the previous station
        public double distance { get; set; }

        //Travel time from the previous station
        public TimeSpan time { get; set; }

        #endregion

        public LineStation(double distance, TimeSpan time)
        {
            this.distance = distance;
            this.time = time;
            isactive = true;
        }
        public LineStation()
        {

        }

    }
}
