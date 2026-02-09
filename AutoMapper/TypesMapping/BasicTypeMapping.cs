using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.TypesMapping
{
    internal class BasicTypeMapping : ATypeMapping
    {
        List<Type> numTypes = new List<Type>() { typeof(int), typeof(long), typeof(double) };
        public override object TypeConversion(object sourceData, Type souceType, Type destType)
        {
            string sourceDataString = sourceData.ToString();

            if (destType == typeof(string)) return sourceDataString;
            //if (destType.IsEnum) return Enum.Parse(destType, sourceDataString);

            if (souceType.IsEnum && numTypes.Any(x => x == destType))
            {
                return Convert.ChangeType(sourceData, destType);
            }

            var parseMethod = destType.GetMethod("Parse", new Type[] { typeof(string) });
            var result = parseMethod.Invoke(null, new object[] { sourceDataString });
            return result;
        }
    }
}
