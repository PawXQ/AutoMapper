using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Mapper
    {
        public static TDestination Map<Tsource, TDestination>(Tsource source) where TDestination : class, new()
        {
            TDestination destination = new TDestination();

            PropertyInfo[] sourceProps = typeof(Tsource).GetProperties();
            Type destinationType = typeof(TDestination);

            foreach (PropertyInfo prop in sourceProps)
            {
                PropertyInfo propertyInfo = destinationType.GetProperty(prop.Name);
                string propValueString = prop.GetValue(source)?.ToString();

                if (propValueString == null) continue;
                if (propertyInfo == null) continue;


                if (propertyInfo.PropertyType == typeof(string)) { propertyInfo.SetValue(destination, propValueString); continue; }
                if (propertyInfo.PropertyType == typeof(float)) { propertyInfo.SetValue(destination, float.Parse(propValueString)); continue; }
                if (propertyInfo.PropertyType == typeof(double)) { propertyInfo.SetValue(destination, double.Parse(propValueString)); continue; }
                if (propertyInfo.PropertyType == typeof(long)) { propertyInfo.SetValue(destination, long.Parse(propValueString)); continue; }
                if (propertyInfo.PropertyType == typeof(decimal)) { propertyInfo.SetValue(destination, decimal.Parse(propValueString)); continue; }

                if (propertyInfo.PropertyType.IsEnum) { propertyInfo.SetValue(destination, Enum.Parse(propertyInfo.PropertyType, propValueString)); continue; }

                propertyInfo.SetValue(destination, prop.GetValue(source));
            }

            return destination;
        }
    }
}
