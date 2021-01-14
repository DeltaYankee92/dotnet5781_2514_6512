using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLAPI
{
    public class LineCycle:Activity // a class to manage the cycles of a given bus
    {
     //   readonly int start_hour = 7; //all bus cycles will start at 7.

        public static int counter = 0;
        public BusLine line { get; set; } // the bus leaving at what times
        public int frequency { get; set; }
        public int id { get; set; }
        public LineCycle()
        {
            isactive = true;
            counter++;
        }
        public LineCycle(BusLine line, int frequency, int id)
        {
            this.line = line;
            this.frequency = frequency;
            this.id = id;
            isactive = true;
            counter++;
        }
    }
}
