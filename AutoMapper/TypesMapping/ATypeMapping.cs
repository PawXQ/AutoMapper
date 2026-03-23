using AutoMapper.Enums;
using AutoMapper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.TypesMapping
{
    internal abstract class ATypeMapping
    {
        public abstract object TypeConversion(object sourceData, Type sourceType, Type destType);

        public object TypeConversionCallback(object source, Type destType)
        {
            Type sourceType = source.GetType();
            TypeEnum destTypeEnum = destType.RecornizeType();

            Type destTypeMapping = Type.GetType($"AutoMapper.TypesMapping.{destTypeEnum}Mapping");
            ATypeMapping aTypeMapping = (ATypeMapping)Activator.CreateInstance(destTypeMapping);

            return aTypeMapping.TypeConversion(source, sourceType, destType);
        }
    }
}
