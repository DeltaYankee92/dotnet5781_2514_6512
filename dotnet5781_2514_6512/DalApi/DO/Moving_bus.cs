using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLAPI
{
    public class Moving_bus:Activity
    {
        public static int counter = 0;
        public  bool is_driving { get; set; }
        public int[] plate { get; set; }
        public int everyXmins { get; set; }
        public TimeSpan time_out { get; set; }
        public int last_stop { get; set; }
        public int time_to_next { get; set; }
        public int id { get; set; }


        public Moving_bus()
        {
            counter++;
                isactive = true;
        }

        public Moving_bus(bool is_driving, int[] plate, int everyXmins, TimeSpan time_out, int last_stop, int time_to_next, int id)
        {
            this.is_driving = is_driving;
            this.plate = plate;
            this.everyXmins = everyXmins;
            this.time_out = time_out;
            this.last_stop = last_stop;
            this.time_to_next = time_to_next;
            this.id = id;
            counter++;
            isactive = true;
        }
    }
}
