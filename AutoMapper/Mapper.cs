using AutoMapper.Enums;
using AutoMapper.ExpressionMapping;
using AutoMapper.Extensions;
using AutoMapper.Models;
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

                object destObjectValue = null;

                if (mapperConfiguration.propertyInfoExpressionModelkeyValuePairs.TryGetValue(prop, out ExpressionModel expressionModel))
                {
                    destObjectValue = expressionModel.GetExpressionValue(source);
                }

                TypeEnum destTypeEnum = destProptyType.RecornizeType();

                Type destTypeMapping = Type.GetType($"AutoMapper.TypesMapping.{destTypeEnum}Mapping");
                ATypeMapping aTypeMapping = (ATypeMapping)Activator.CreateInstance(destTypeMapping);

                object typeConversionResult = null;
                Type sourceTypePropertyInfoType = null;
                sourceTypePropertyInfoType = sourceTypePropertyInfo == null ? null : sourceTypePropertyInfo.PropertyType;

                if (sourceTypePropertyInfoType != null)
                {
                    typeConversionResult = aTypeMapping.TypeConversion(sourceTypePropertyInfo.GetValue(source), sourceTypePropertyInfoType, destProptyType);
                }

                if (expressionModel != null)
                {
                    sourceTypePropertyInfoType = destObjectValue.GetType();
                    typeConversionResult = aTypeMapping.TypeConversion(destObjectValue, sourceTypePropertyInfoType, destProptyType);
                }

                // 轉換 Tsource.X => TDestination.y return propertyinfo
                // 找 TDestination property index
                prop.SetValue(destination, typeConversionResult);
            }

            return destination;
        }
    }
}
