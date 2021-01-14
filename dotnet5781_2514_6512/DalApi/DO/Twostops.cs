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
        public Twostops()
        {
            counter++;
            isactive = true;
        }

        public Twostops(int[] code1, int[] code2, int distance, TimeSpan between, int id)
        {

            this.code1 = new int[code1.Length];
            this.code2 = new int[code2.Length];
            for(int i=0;i<code1.Length;i++)
            {
                this.code1[i] = code1[i];
            }
            for (int i = 0; i < code2.Length; i++)
            {
                this.code2[i] = code2[i];
            }
            this.distance = distance;
            this.between = between;
            this.id = id;
            counter++;
            isactive = true;
        }
    }
}
