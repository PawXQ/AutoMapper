using AutoMapper.Enums;
using AutoMapper.Extensions;
using AutoMapper.TypesMapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Mapper
    {
        public static TDestination Map<Tsource, TDestination>(Tsource source, Action<MapperConfiguration<Tsource, TDestination>> callback) where TDestination : class, new()
        {
            PropertyInfo sourceTypePropertyInfo = null;
            TDestination destination = new TDestination();

            PropertyInfo[] destProps = typeof(TDestination).GetProperties();
            Type sourceType = typeof(Tsource);

            MapperConfiguration<Tsource, TDestination> mapperConfiguration = new MapperConfiguration<Tsource, TDestination>();
            callback.Invoke(mapperConfiguration);

            foreach (PropertyInfo prop in destProps)
            {
                Type destProptyType = prop.PropertyType;

                var result = mapperConfiguration.memberExpressionkeyValuePairs.FirstOrDefault(x =>
                {
                    string name = x.Value.Member.Name;
                    PropertyInfo propertyInfo = typeof(TDestination).GetProperty(name);

                    return propertyInfo == prop;
                });

                if (result.Key != null)
                {
                    sourceTypePropertyInfo = typeof(Tsource).GetProperty(result.Key.Member.Name);
                    mapperConfiguration.memberExpressionkeyValuePairs.Remove(result.Key);
                }
                else
                {
                    sourceTypePropertyInfo = sourceType.GetProperty(prop.Name);
                };

                Type sourceTypePropertyInfoType = sourceTypePropertyInfo.PropertyType;

                TypeEnum destTypeEnum = destProptyType.RecornizeType();

                Type destTypeMapping = Type.GetType($"AutoMapper.TypesMapping.{destTypeEnum}Mapping");
                ATypeMapping aTypeMapping = (ATypeMapping)Activator.CreateInstance(destTypeMapping);

                var typeConversionResult = aTypeMapping.TypeConversion(sourceTypePropertyInfo.GetValue(source), sourceTypePropertyInfoType, destProptyType);
                // 轉換 Tsource.X => TDestination.y return propertyinfo
                // 找 TDestination property index
                prop.SetValue(destination, typeConversionResult);
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
