using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class MapperConfiguration<TSource, TDest>
    {
        public Dictionary<PropertyInfo, PropertyInfo> proPertyInfokeyValuePairs = new Dictionary<PropertyInfo, PropertyInfo>();
        public Dictionary<MemberExpression, MemberExpression> memberExpressionkeyValuePairs = new Dictionary<MemberExpression, MemberExpression>();

        public MapperConfiguration<TSource, TDest> ForMember<TSourceProp, TDestProp>(Expression<Func<TSource, TSourceProp>> callback1,
                                                                                     Expression<Func<TDest, TDestProp>> callback2)
        {
            MemberExpression memberExpression1 = callback1.Body as MemberExpression;
            MemberExpression memberExpression2 = callback2.Body as MemberExpression;

            //string name1 = memberExpression1.Member.Name;
            //string name2 = memberExpression2.Member.Name;

            //PropertyInfo propertyInfo1 = typeof(TSource).GetProperty(name1);
            //PropertyInfo propertyInfo2 = typeof(TDest).GetProperty(name2);

            //this.proPertyInfokeyValuePairs.Add(propertyInfo1, propertyInfo2);
            this.memberExpressionkeyValuePairs.Add(memberExpression1, memberExpression2);

            return this;
        }
    }
}
