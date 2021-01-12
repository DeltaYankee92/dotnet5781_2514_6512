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
        public static IBL GetBL()
        {
            return new BLimp();
        }
    }
}
