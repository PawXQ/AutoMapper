using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.TypesMapping
{
    internal class ArrayTypeMapping : ATypeMapping
    {
        public override object TypeConversion(object sourceData, Type sourceType, Type destType)
        {
            var sourceArray = (Array)sourceData;
            Type destGenericType = destType.GetElementType();

            Array destArray = Array.CreateInstance(destGenericType, sourceArray.Length);

            //MethodInfo parseMethod = destType.GetElementType().GetMethod("Parse", new Type[] { typeof(string) });

            for (int i = 0; i < sourceArray.Length; i++)
            {
                //destArray.SetValue(parseMethod.Invoke(null, new object[] { sourceArray.GetValue(i) }), i);
                destArray.SetValue(Mapper.MapCallback(sourceArray.GetValue(i), destGenericType), i);
            }

            return destArray;
        }
    }
}
