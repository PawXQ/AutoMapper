using AutoMapper.Models;
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
        public Dictionary<PropertyInfo, ExpressionModel> propertyInfoExpressionModelkeyValuePairs = new Dictionary<PropertyInfo, ExpressionModel>();

        public MapperConfiguration<TSource, TDest> ForMember<TSourceProp, TDestProp>(Expression<Func<TSource, TSourceProp>> tSourceCallback,
                                                                                     Expression<Func<TDest, TDestProp>> tDestCallback)
        {
            MemberExpression tDestCallbackMemberExpression = tDestCallback.Body as MemberExpression;
            string tDestCallbackMemberExpressionMemberName = tDestCallbackMemberExpression.Member.Name;
            PropertyInfo tDestCallbackMemberExpressionMemberNamePropertyInfo = typeof(TDest).GetProperty(tDestCallbackMemberExpressionMemberName);

            this.propertyInfoExpressionModelkeyValuePairs[tDestCallbackMemberExpressionMemberNamePropertyInfo] = new ExpressionModel(tSourceCallback.Body);

            return this;
        }
    }
}
