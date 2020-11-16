using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{
    class LineCollecton 
    {
        public readonly List<BusLine> Lines = new List<BusLine>();

        void ADD_Line(BusLine l)
        {
            Lines.Add(l);
        }
        void Delete_Line(BusLine l)
        {
            Lines.Remove(l);
        }

        List<BusLine> LinesInStop(int idBusStationKey)
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
        void SortLineCollection()
        {

        }




    }
}
