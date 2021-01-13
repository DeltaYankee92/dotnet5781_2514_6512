using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLAPI
{
    public class Twostops:Activity
    {
        public static int counter=0;
        public int[] code1 { get; set; }
        public int[] code2 { get; set; }
        public int distance { get; set; }
        public TimeSpan between { get; set; }
        public int id { get; set; }
    }
}
