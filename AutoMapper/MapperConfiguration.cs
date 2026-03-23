using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoMapper
{
    internal class MapperConfiguration<TSource, TDest>
    {
        public Dictionary<PropertyInfo, Expression> propertyInfoMemberExpressionkeyValuePairs = new Dictionary<PropertyInfo, Expression>();

        public MapperConfiguration<TSource, TDest> ForMember<TSourceProp, TDestProp>(Expression<Func<TSource, TSourceProp>> tSourceCallback,
                                                                                     Expression<Func<TDest, TDestProp>> tDestCallback)
        {
            MemberExpression tDestCallbackMemberExpression = tDestCallback.Body as MemberExpression;
            string tDestCallbackMemberExpressionMemberName = tDestCallbackMemberExpression.Member.Name;
            PropertyInfo tDestCallbackMemberExpressionMemberNamePropertyInfo = typeof(TDest).GetProperty(tDestCallbackMemberExpressionMemberName);

            if (tSourceCallback.Body is MemberExpression) this.propertyInfoMemberExpressionkeyValuePairs[tDestCallbackMemberExpressionMemberNamePropertyInfo] = tSourceCallback.Body;
            else if (tSourceCallback.Body is ConstantExpression) this.propertyInfoMemberExpressionkeyValuePairs[tDestCallbackMemberExpressionMemberNamePropertyInfo] = tSourceCallback.Body;
            else if (tSourceCallback.Body is UnaryExpression) this.propertyInfoMemberExpressionkeyValuePairs[tDestCallbackMemberExpressionMemberNamePropertyInfo] = tSourceCallback.Body;
            else if (tSourceCallback.Body is MethodCallExpression) this.propertyInfoMemberExpressionkeyValuePairs[tDestCallbackMemberExpressionMemberNamePropertyInfo] = tSourceCallback.Body;
            else if (tSourceCallback.Body is ConditionalExpression) this.propertyInfoMemberExpressionkeyValuePairs[tDestCallbackMemberExpressionMemberNamePropertyInfo] = tSourceCallback.Body;
            else if (tSourceCallback.Body is BinaryExpression) this.propertyInfoMemberExpressionkeyValuePairs[tDestCallbackMemberExpressionMemberNamePropertyInfo] = tSourceCallback.Body;
            else if (tSourceCallback.Body is NewExpression) this.propertyInfoMemberExpressionkeyValuePairs[tDestCallbackMemberExpressionMemberNamePropertyInfo] = tSourceCallback.Body;

            //ConstantExpression constantExpression1 = callback1 as ConstantExpression;

            return this;
        }
    }
}
