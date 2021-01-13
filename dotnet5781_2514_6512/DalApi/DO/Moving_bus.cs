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

    }
}
