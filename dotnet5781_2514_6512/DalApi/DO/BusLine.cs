using DalApi.DO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace DalApi.DO
{
    public class BusLine : Activity
    {
        public BusStop FirstStation { get; set; }
        public BusStop LastStation { get; set; }
        public int BusNumber { get; set; }
        public string Area { get; set; }

    }

}
