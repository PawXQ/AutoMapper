using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionMapping
{
    internal class NewExpressionMapping : AExpressionMapping
    {
        public override object _GetExpressionValue(object datasource, Expression expression)
        {
            NewExpression newExpression = (NewExpression)expression;

            object obj = Activator.CreateInstance(newExpression.Type);

            return obj;
        }
    }
}
