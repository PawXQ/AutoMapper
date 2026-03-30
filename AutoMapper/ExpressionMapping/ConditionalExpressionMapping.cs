using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionMapping
{
    internal class ConditionalExpressionMapping : AExpressionMapping
    {
        public override object _GetExpressionValue(object datasource, Expression expression)
        {
            ConditionalExpression conditionalExpression = (ConditionalExpression)expression;

            bool conditional = (bool)GetExpressionValue(datasource, conditionalExpression.Test);

            object objTrue = GetExpressionValue(datasource, conditionalExpression.IfTrue);
            object objFalse = GetExpressionValue(datasource, conditionalExpression.IfFalse);

            return conditional ? objTrue : objFalse;
        }
    }
}
