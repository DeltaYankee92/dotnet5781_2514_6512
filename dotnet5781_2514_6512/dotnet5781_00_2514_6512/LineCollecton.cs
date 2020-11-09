using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{
    class LineCollecton : IEnumerable<BusLine>
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
        void LinesInStop(int idBusStationKey)
        {
            foreach (var BusLine in Lines)
            {

            }
        }

        public IEnumerator<BusLine> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
