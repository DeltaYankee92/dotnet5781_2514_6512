using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.BO
{
    class LineCycle // class for a cycle of a bus, when it leaves and for how long etc
    {
        public static int counter = 0;
        public BusLine line { get; set; } // the bus leaving at what times
        public int frequency { get; set; }
        readonly int start_hour = 7; //all bus cycles will start at 7.
        public int id { get; set; }
        public LineCycle()
        {
            id = counter;
            counter++;
        }
        public LineCycle(BusLine _line)
        {
            line = _line;
            id = counter;
            counter++;
        }
        public LineCycle(BusLine _line, int freq)
        {
            line = _line;
            frequency = freq;
            id = counter;
            counter++;
        }

        internal int[] freq_calc()
        {
            int[] arr = new int[2];
            arr[0] = frequency % 60; // minutes
            arr[1] = frequency / 60; // hours

            return arr;
        }

        public bool isleaving(DateTime thistime)
        {
            int hour_calc = start_hour;
            int min_calc = 0;
            int[] arr;
            while (min_calc >= 7) // no buses start running after 12.
            {
                if (thistime.Minute == min_calc && thistime.Hour == hour_calc)
                    return true;
                arr = this.freq_calc();
                hour_calc += arr[1];
                min_calc += arr[0];
                if (min_calc >= 60)
                {
                    hour_calc++;
                    min_calc -= 60;
                }

            }
            return false;
        }
        public List<TimeSpan> Scheduele()
        {
            List<TimeSpan> l = new List<TimeSpan>();
            int[] progress = this.freq_calc();
            int total_h= start_hour;
            int total_m=0;
            while (total_h>= start_hour)
            {
                l.Add(new TimeSpan(0, total_h, total_m, 0, 0));
                total_h += progress[1];
                total_m += progress[0];
                if(total_m>=60)
                {
                    total_m -= 60;
                    total_h++;
                }
            }

            return l;
        }
    }
}
