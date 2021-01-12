using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.BO
{
    public class Twostops // two stops have stuff between them. what? here we are.
    {
        public static int counter = 0;
        public int[] code1 { get; set; }
        public int[] code2 { get; set; }
        public int distance { get; set; }
        public TimeSpan between { get; set; }
        public int id { get; set; }
        public Twostops()
        {
            id = counter;
            counter++;
        }
        public Twostops(int[] _code1,int[] _code2, int _distance,TimeSpan time)
        {
            id = counter;
            counter++;
            between = time;
            distance = _distance;
            code1 = new int[_code1.Length];
            code2 = new int[_code2.Length];
            for (int i = 0; i < _code1.Length; i++)
            {
                code1[i] = _code1[i];
            }
            for (int i = 0; i < _code2.Length; i++)
            {
                code2[i] = _code2[i];
            }
        }
    }
}
