

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace DLAPI
{
    public class BusLine : Activity
    {
        public int BusNumber { get; set; }
        public BusStop FirstStation { get; set; }
        public BusStop LastStation { get; set; }
        public string Area { get; set; }

        public BusLine()
        {
            isactive = true;
        }
        public BusLine(BusStop _firststation,BusStop _laststation, int busnumber, string area)
        {
            isactive = true;
            FirstStation = _firststation;
            LastStation = _laststation;
            BusNumber = busnumber;
            Area = area;
        }
    }

}
