using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class Moving_bus // a bus that is busy driving is a new thing now
    {
        public static int counter = 0;
        public bool is_driving { get; set; }
        public int[] plate { get; set; }
        public int everyXmins { get; set; }
        public TimeSpan time_out { get; set; }
        public int last_stop { get; set; }
        public int time_to_next { get; set; }
        public int id { get; set; }

        public Moving_bus()
        {
            id = counter;
            counter++;
        }
        public Moving_bus(int[] _plate, int _everyxmins, TimeSpan time,int _last_stop,int _time_to_next)
        {
            id = counter;
            counter++;
            time_out = time;
            everyXmins = _everyxmins;
            _last_stop = last_stop;
            _time_to_next = time_to_next;

            plate = new int[_plate.Length];
            is_driving = false;

            for (int i = 0; i < _plate.Length; i++)
            {
                plate[i] = _plate[i];
            }

        }
        public void stop()
        {
            is_driving = false;
        }
        public void go()
        {
            is_driving = true   ;
        }
    }
}
