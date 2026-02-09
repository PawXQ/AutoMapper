using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.TypesMapping
{
    internal class StackTypeMapping : ATypeMapping
    {
        public override object TypeConversion(object sourceData, Type souceType, Type destType)
        {
            Type typeDefinition = destType.GetGenericTypeDefinition();
            Type[] typeArguments = destType.GetGenericArguments();
            Type genericType = typeArguments[0];

            MethodInfo genericMethod = genericType.GetMethod("Parse", new Type[] { typeof(string) });

            var genericListType = typeDefinition.MakeGenericType(typeArguments);

            object genericTypes = Activator.CreateInstance(genericListType);

            MethodInfo enumeratorMethodType = souceType.GetMethod("GetEnumerator");
            IEnumerator enumerator = (IEnumerator)enumeratorMethodType.Invoke(sourceData, null);

            MethodInfo typeDefinitionPushMethod = genericTypes.GetType().GetMethod("Push", new Type[] { genericType });

            while (enumerator.MoveNext())
            {
                typeDefinitionPushMethod.Invoke(genericTypes, new object[] { genericMethod.Invoke(null, new object[] { enumerator.Current }) });
            }

            return genericTypes;
        }
    }
}
