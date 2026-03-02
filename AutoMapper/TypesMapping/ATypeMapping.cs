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
    }
}
