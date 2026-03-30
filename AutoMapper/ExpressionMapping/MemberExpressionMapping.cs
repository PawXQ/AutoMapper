using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionMapping
{
    internal class MemberExpressionMapping : AExpressionMapping
    {
        public override object _GetExpressionValue(object datasource, Expression expression)
        {
            MemberExpression memberExpression = (MemberExpression)expression;

            PropertyInfo memberPropertyInfo = (PropertyInfo)memberExpression.Member;

            return memberPropertyInfo.GetValue(datasource);
        }
    }
}
