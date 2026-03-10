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
        public Dictionary<PropertyInfo, MemberExpression> propertyInfoMemberExpressionkeyValuePairs = new Dictionary<PropertyInfo, MemberExpression>();

        public MapperConfiguration<TSource, TDest> ForMember<TSourceProp, TDestProp>(Expression<Func<TSource, TSourceProp>> callback1,
                                                                                     Expression<Func<TDest, TDestProp>> callback2)
        {
            MemberExpression memberExpression1 = callback1.Body as MemberExpression;
            MemberExpression memberExpression2 = callback2.Body as MemberExpression;

            string name2 = memberExpression2.Member.Name;

            PropertyInfo propertyInfo2 = typeof(TDest).GetProperty(name2);

            this.propertyInfoMemberExpressionkeyValuePairs.Add(propertyInfo2, memberExpression1);

            return this;
        }
    }
}
