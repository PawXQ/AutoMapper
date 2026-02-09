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
        public override object TypeConversion(object sourceData, Type souceType, Type destType)
        {
            var sourceArray = (Array)sourceData;

            Type souceElementType = sourceArray.GetType().GetElementType();

            Array destArray = Array.CreateInstance(destType.GetElementType(), sourceArray.Length);

            MethodInfo parseMethod = destType.GetElementType().GetMethod("Parse", new Type[] { typeof(string) });

            for (int i = 0; i < sourceArray.Length; i++)
            {
                destArray.SetValue(parseMethod.Invoke(null, new object[] { sourceArray.GetValue(i) }), i);
            }

            return destArray;
        }
    }
}
