using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL;
using BL.BLapi;

namespace BLapi
{
    public static class BLFactory
    {
        public static IBL GetBL(string type)
        {
            switch (type)
            {
                case "1":
                    return new BLimp();
                case "2":
                //return new BLImp2();
                default:
                    return new BLimp();
            }
        }
    }
}
