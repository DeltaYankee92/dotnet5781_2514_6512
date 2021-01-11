using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO
{
    public class Activity
    {
        public bool isactive { get; set; }
        public void Word_activity(string str)
        {
            if (str == "active")
                isactive = true;
            if (str == "inactive")
                isactive = false;
        }
    }
}
