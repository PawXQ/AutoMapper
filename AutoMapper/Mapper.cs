using AutoMapper.Enums;
using AutoMapper.Extensions;
using AutoMapper.TypesMapping;
using System;
using System.Collections;
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
                Type sourcePropType = prop.PropertyType;

                PropertyInfo propertyInfo = destinationType.GetProperty(prop.Name);
                Type destType = propertyInfo.PropertyType;

                TypeEnum typeEnum = destType.RecornizeType();

                Type typeMapping = Type.GetType($"AutoMapper.TypesMapping.{typeEnum}Mapping");
                ATypeMapping aTypeMapping = (ATypeMapping)Activator.CreateInstance(typeMapping);

                var result = aTypeMapping.TypeConversion(prop.GetValue(source), sourcePropType, destType);

                propertyInfo.SetValue(destination, result);
            }

            return destination;
        }
    }
}
