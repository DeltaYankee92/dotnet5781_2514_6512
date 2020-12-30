using BL.BLapi;
using DLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class BLimp :IBL // internal: add manually.
    {
        IDL dl = DLFactory.GetDL();
    }
}
