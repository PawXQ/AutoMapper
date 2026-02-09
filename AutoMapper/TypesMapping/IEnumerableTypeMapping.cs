using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.TypesMapping
{
    internal class IEnumerableTypeMapping : ATypeMapping
    {
        public override object TypeConversion(object sourceData, Type souceType, Type destType)
        {
            Type TypeDefinition = destType.GetGenericTypeDefinition();
            Type[] typeArguments = destType.GetGenericArguments();
            Type genericType = typeArguments[0];

            MethodInfo genericMethod = genericType.GetMethod("Parse", new Type[] { typeof(string) });

            var genericListType = TypeDefinition.MakeGenericType(typeArguments);

            //IList genericTypes = (IList)Activator.CreateInstance(genericListType);
            object genericTypes = Activator.CreateInstance(genericListType);

            MethodInfo enumeratorMethodType = souceType.GetMethod("GetEnumerator");
            IEnumerator enumerator = (IEnumerator)enumeratorMethodType.Invoke(sourceData, null);

            MethodInfo typeDefinitionAddMethod = genericTypes.GetType().GetMethod("Add", new Type[] { genericType });

            while (enumerator.MoveNext())
            {
                //genericTypes.Add(genericMethod.Invoke(null, new object[] { enumerator.Current }));
                typeDefinitionAddMethod.Invoke(genericTypes, new object[] { genericMethod.Invoke(null, new object[] { enumerator.Current }) });
            }

            return genericTypes;
        }
    }
}
