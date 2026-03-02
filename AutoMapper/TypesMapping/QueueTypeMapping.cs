using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.TypesMapping
{
    internal class QueueTypeMapping : ATypeMapping
    {
        public override object TypeConversion(object sourceData, Type sourceType, Type destType)
        {
            Type typeDefinition = destType.GetGenericTypeDefinition();
            Type[] typeArguments = destType.GetGenericArguments();
            Type genericType = typeArguments[0];

            //MethodInfo genericMethod = genericType.GetMethod("Parse", new Type[] { typeof(string) });

            var genericListType = typeDefinition.MakeGenericType(typeArguments);

            object genericTypes = Activator.CreateInstance(genericListType);

            MethodInfo enumeratorMethodType = sourceType.GetMethod("GetEnumerator");
            IEnumerator enumerator = (IEnumerator)enumeratorMethodType.Invoke(sourceData, null);

            MethodInfo typeDefinitionEnqueqeMethod = genericTypes.GetType().GetMethod("Enqueue", new Type[] { genericType });

            while (enumerator.MoveNext())
            {
                //typeDefinitionEnqueqeMethod.Invoke(genericTypes, new object[] { genericMethod.Invoke(null, new object[] { enumerator.Current }) });
                typeDefinitionEnqueqeMethod.Invoke(genericTypes, new object[] { Mapper.MapCallback(enumerator.Current, genericType) });
            }

            return genericTypes;
        }
    }
}
