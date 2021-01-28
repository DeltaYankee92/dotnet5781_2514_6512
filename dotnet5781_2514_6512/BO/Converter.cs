using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DLAPI;

namespace BL
{
    public static class Converter
    {
        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    p.SetValue(dest, sourceProp.GetValue(source, null), null);
                }

            }

        }
        #region BL to DO converters
        internal static T BOtoDO_Bus<T,S>(S bus) where T: DLAPI.Bus, new() where S : BO.Bus, new()
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

        internal static T BOtoDO_BusLine<T, S>(S linenum) where T : DLAPI.BusLine, new() where S : BO.BusLine, new()
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

        internal static T BOtoDO_BusStop<T, S>(S busStop) where T : DLAPI.BusStop, new() where S : BO.BusStop, new()
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

        internal static T BOtoDO_LineStation<T, S>(S station) where T : DLAPI.LineStation, new() where S : BO.LineStation, new()
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

        internal static T BOtoDO_LineCycle<T, S>(S station) where T : DLAPI.LineCycle, new() where S : BO.LineCycle, new()
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

        internal static T BOtoDO_Moving_bus<T, S>(S station) where T : DLAPI.Moving_bus, new() where S : BO.Moving_bus, new()
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

        internal static T BOtoDO_TwoStops<T, S>(S station) where T : DLAPI.Twostops, new() where S : BO.Twostops, new()
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

        #region DO to BL converters
        internal static T DOtoBO_Bus<T, S>(S bus) where T : BO.Bus, new() where S : DLAPI.Bus, new()
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

        internal static T DOtoBO_BusLine<T, S>(S busLine) where T : BO.BusLine, new() where S : DLAPI.BusLine, new()
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

        internal static T DOtoBO_BusStop<T, S>(S busStop) where T : BO.BusStop, new() where S : DLAPI.BusStop, new()
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

        internal static T DOtoBO_LineStation<T, S>(S station) where T : BO.LineStation, new() where S : DLAPI.LineStation, new()
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
        internal static T DOtoBO_Moving_bus<T, S>(S bus) where T : BO.Moving_bus, new() where S : DLAPI.Moving_bus, new()
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

        internal static T DOtoBO_LineCycle<T, S>(S cycle) where T : BO.LineCycle, new() where S : DLAPI.LineCycle, new()
        {
            T output = new T();
            foreach (PropertyInfo propto in output.GetType().GetProperties())
            {
                PropertyInfo propfrom = cycle.GetType().GetProperty(propto.Name);
                if (propfrom == null || propto.PropertyType != propfrom.PropertyType)
                {
                    continue;
                }
                propto.SetValue(output, propfrom.GetValue(cycle, null));
            }
            return output;
        }

        internal static T DOtoBO_Twostops<T, S>(S stops) where T : BO.Twostops, new() where S : DLAPI.Twostops, new()
        {
            T output = new T();
            foreach (PropertyInfo propto in output.GetType().GetProperties())
            {
                PropertyInfo propfrom = stops.GetType().GetProperty(propto.Name);
                if (propfrom == null || propto.PropertyType != propfrom.PropertyType)
                {
                    continue;
                }
                propto.SetValue(output, propfrom.GetValue(stops, null));
            }
            return output;
        }

        //write function to convert from DO.IEnumerable<T> to BO.IEnumrable<T>
        #endregion
    }
}
