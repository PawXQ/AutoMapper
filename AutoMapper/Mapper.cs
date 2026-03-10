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
            TDestination destination = new TDestination();

            PropertyInfo[] destProps = typeof(TDestination).GetProperties();
            Type sourceType = typeof(Tsource);

            MapperConfiguration<Tsource, TDestination> mapperConfiguration = new MapperConfiguration<Tsource, TDestination>();
            callback.Invoke(mapperConfiguration);

            foreach (PropertyInfo prop in destProps)
            {
                Type destProptyType = prop.PropertyType;


                PropertyInfo sourceTypePropertyInfo = sourceType.GetProperty(prop.Name);
                if (mapperConfiguration.propertyInfoMemberExpressionkeyValuePairs.TryGetValue(prop, out MemberExpression soureExpression))
                {
                    sourceTypePropertyInfo = (PropertyInfo)mapperConfiguration.propertyInfoMemberExpressionkeyValuePairs[prop].Member;
                }

                //PropertyInfo sourceTypePropertyInfo = mapperConfiguration.propertyInfoMemberExpressionkeyValuePairs.ContainsKey(prop) ?
                //                                      (PropertyInfo)mapperConfiguration.propertyInfoMemberExpressionkeyValuePairs[prop].Member :
                //                                      sourceType.GetProperty(prop.Name);

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
