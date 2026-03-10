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
        public Dictionary<MemberExpression, MemberExpression> memberExpressionkeyValuePairs = new Dictionary<MemberExpression, MemberExpression>();

        public MapperConfiguration<TSource, TDest> ForMember<TSourceProp, TDestProp>(Expression<Func<TSource, TSourceProp>> callback1,
                                                                                     Expression<Func<TDest, TDestProp>> callback2)
        {
            MemberExpression memberExpression1 = callback1.Body as MemberExpression;
            MemberExpression memberExpression2 = callback2.Body as MemberExpression;

            this.memberExpressionkeyValuePairs.Add(memberExpression1, memberExpression2);

            return this;
        }
    }
}
