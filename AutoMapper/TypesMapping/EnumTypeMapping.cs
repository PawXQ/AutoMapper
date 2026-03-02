using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.TypesMapping
{
    internal class EnumTypeMapping : ATypeMapping
    {
        public override object TypeConversion(object sourceData, Type sourceType, Type destType)
        {
            string sourceDataString = sourceData.ToString();

            return Enum.Parse(destType, sourceDataString);
        }
    }
}
