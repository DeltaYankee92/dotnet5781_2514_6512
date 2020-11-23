using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{
    class LineCollecton :IEnumerable
    {
        /*
         a collection of buslines, and a few actions that stem from that
         */

        public List<BusLine> Lines;
        internal LineCollecton() // ctor
        {
            Lines = new List<BusLine>();
        }
        public void ADD_Line(BusLine l) // add l to the line
        {
            Lines.Add(l);
        }
        void Delete_Line(BusLine l) // remove l to the line
        {
            Lines.Remove(l);
        }

        public void Delete_Line(int id) // delete the id from the line.
        {
            foreach (BusLine b1 in Lines)
            {
                if(id == b1.get_line_num())
                {
                    Lines.Remove(b1);
                    return;
                }
            }
            throw new ArgumentException("no line found");
        }
        public List<BusLine> LinesInStop(int idBusStationKey) // returns a list with all of the lines including this stop.
        {
            List<BusLine> lines = new List<BusLine>();
            foreach (BusLine b1 in Lines)
            {
                if (b1.exists(idBusStationKey))
                {
                    lines.Add(b1);
                }
            }
            if (lines.Count == 0)
            {
                throw new ArgumentException("Error! no id found");
            }
            return lines;
        }
        void SortLineCollection() // using the sort function. but in a convenient way.
        {
            Lines.Sort();
        }

        public BusLine this[int index] // indexer.
        {
        get
            {
                if (index <= 0 || index > this.Lines.Count)
                    throw new ArgumentOutOfRangeException("no index exists");
                return Lines[index];
            }
        }


        public bool check_location(LineStation a) // checking if a is in the list.
        {
            bool flag;
            foreach (BusLine it in Lines)
            {
                flag = it.check_location(a);
                if (!flag)
                    return false;
            }
            return true;
        }

        public IEnumerator GetEnumerator() // using ienumerable.
        {
            return ((IEnumerable)Lines).GetEnumerator();
        }

    }
}
