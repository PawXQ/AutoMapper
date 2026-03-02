using AutoMapper.Enums;
using AutoMapper.Extensions;
using AutoMapper.TypesMapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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

                TypeEnum destTypeEnum = destType.RecornizeType();

                Type destTypeMapping = Type.GetType($"AutoMapper.TypesMapping.{destTypeEnum}Mapping");
                ATypeMapping aTypeMapping = (ATypeMapping)Activator.CreateInstance(destTypeMapping);

                var result = aTypeMapping.TypeConversion(prop.GetValue(source), sourcePropType, destType);
                // 轉換 Tsource.X => TDestination.y return propertyinfo
                // 找 TDestination property index
                propertyInfo.SetValue(destination, result);
            }

            return destination;
        }

        public static object MapCallback(object source, Type destType)
        {
            Type sourceType = source.GetType();
            TypeEnum destTypeEnum = destType.RecornizeType();

            Type destTypeMapping = Type.GetType($"AutoMapper.TypesMapping.{destTypeEnum}Mapping");
            ATypeMapping aTypeMapping = (ATypeMapping)Activator.CreateInstance(destTypeMapping);

            return aTypeMapping.TypeConversion(source, sourceType, destType);
        }

        //public static Mapper Convert(Func<PropertyInfo, PropertyInfo, PropertyInfo> func)
        //{
        //    Type AType = PropertyInfo
        //    func.Invoke(null, null);

        //    return this
        //}
    }
}
