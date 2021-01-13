using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLAPI
{
    public class LineCycle:Activity // a class to manage the cycles of a given bus
    {
        public static int counter = 0;
        public BusLine line { get; set; } // the bus leaving at what times
        public int frequency { get; set; }
        readonly int start_hour = 7; //all bus cycles will start at 7.
        public int id { get; set; }

    }
}
