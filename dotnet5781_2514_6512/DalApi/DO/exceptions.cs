using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLAPI
{
     [Serializable]
    public class InsystemException : Exception
    {
       public InsystemException() { }
       public InsystemException(string Meassage) : base(Meassage) { } // sends the exception with the meassage
    }   
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string Meassage) : base(Meassage) { } // sends the exception with the meassage

    }
    [Serializable]
    public class ItemIsInactiveException : Exception
        {
            public ItemIsInactiveException() { }
            public ItemIsInactiveException(string Meassage) : base(Meassage) { } // sends the exception with the meassage
        }
    }

