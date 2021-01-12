using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public static class Utility
    {
        #region BL to DAL converters
        internal static T BOtoDO_Bus<T,S>(S bus) where T: DalApi.DO.Bus, new() where S : BO.Bus, new()
        {
            T output = new T();
            foreach (PropertyInfo propto in output.GetType().GetProperties())
            {
                PropertyInfo propfrom = bus.GetType().GetProperty(propto.Name);
                if (propfrom == null || propto.PropertyType != propfrom.PropertyType)
                {
                    continue;
                }
                propto.SetValue(output, propfrom.GetValue(bus, null));
            }
            return output;
        }

        internal static T BOtoDO_BusLine<T, S>(S linenum) where T : DalApi.DO.BusLine, new() where S : BO.BusLine, new()
        {
            T output = new T();
            foreach (PropertyInfo propto in output.GetType().GetProperties())
            {
                PropertyInfo propfrom = linenum.GetType().GetProperty(propto.Name);
                if (propfrom == null || propto.PropertyType != propfrom.PropertyType)
                {
                    continue;
                }
                propto.SetValue(output, propfrom.GetValue(linenum, null));
            }
            return output;
        }

        internal static T BOtoDO_BusStop<T, S>(S busStop) where T : DalApi.DO.BusStop, new() where S : BO.BusStop, new()
        {
            T output = new T();
            foreach (PropertyInfo propto in output.GetType().GetProperties())
            {
                PropertyInfo propfrom = busStop.GetType().GetProperty(propto.Name);
                if (propfrom == null || propto.PropertyType != propfrom.PropertyType)
                {
                    continue;
                }
                propto.SetValue(output, propfrom.GetValue(busStop, null));
            }
            return output;
        }

        internal static T BOtoDO_LineStation<T, S>(S station) where T : DalApi.DO.LineStation, new() where S : BO.LineStation, new()
        {
            T output = new T();
            foreach (PropertyInfo propto in output.GetType().GetProperties())
            {
                PropertyInfo propfrom = station.GetType().GetProperty(propto.Name);
                if (propfrom == null || propto.PropertyType != propfrom.PropertyType)
                {
                    continue;
                }
                propto.SetValue(output, propfrom.GetValue(station, null));
            }
            return output;
        }
        #endregion

        #region DAL to BL converters
        internal static T DOtoBO_Bus<T, S>(S bus) where T : BO.Bus, new() where S : DalApi.DO.Bus, new()
        {
            T output = new T();
            foreach (PropertyInfo propto in output.GetType().GetProperties())
            {
                PropertyInfo propfrom = bus.GetType().GetProperty(propto.Name);
                if (propfrom == null || propto.PropertyType != propfrom.PropertyType)
                {
                    continue;
                }
                propto.SetValue(output, propfrom.GetValue(bus, null));
            }
            return output;
        }

        internal static T DOtoBO_BusLine<T, S>(S busLine) where T : BO.BusLine, new() where S : DalApi.DO.BusLine, new()
        {
            T output = new T();
            foreach (PropertyInfo propto in output.GetType().GetProperties())
            {
                PropertyInfo propfrom = busLine.GetType().GetProperty(propto.Name);
                if (propfrom == null || propto.PropertyType != propfrom.PropertyType)
                {
                    continue;
                }
                propto.SetValue(output, propfrom.GetValue(busLine, null));
            }
            return output;
        }

        internal static T DOtoBO_BusStop<T, S>(S busStop) where T : BO.BusStop, new() where S : DalApi.DO.BusStop, new()
        {
            T output = new T();
            foreach (PropertyInfo propto in output.GetType().GetProperties())
            {
                PropertyInfo propfrom = busStop.GetType().GetProperty(propto.Name);
                if (propfrom == null || propto.PropertyType != propfrom.PropertyType)
                {
                    continue;
                }
                propto.SetValue(output, propfrom.GetValue(busStop, null));
            }
            return output;
        }

        internal static T DOtoBO_LineStation<T, S>(S lineStation) where T : BO.LineStation, new() where S : DalApi.DO.LineStation, new()
        {
            T output = new T();
            foreach (PropertyInfo propto in output.GetType().GetProperties())
            {
                PropertyInfo propfrom = lineStation.GetType().GetProperty(propto.Name);
                if (propfrom == null || propto.PropertyType != propfrom.PropertyType)
                {
                    continue;
                }
                propto.SetValue(output, propfrom.GetValue(lineStation, null));
            }
            return output;
        }
        

        //write function to convert from DO.IEnumerable<T> to BO.IEnumrable<T>
        #endregion
    }
}
