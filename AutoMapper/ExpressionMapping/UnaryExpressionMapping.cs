using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionMapping
{
    internal class UnaryExpressionMapping : AExpressionMapping
    {
        public override object _GetExpressionValue(object datasource, Expression expression)
        {
            UnaryExpression unaryExpression = (UnaryExpression)expression;

            object obj = GetExpressionValue(datasource, unaryExpression.Operand);

            if (unaryExpression.NodeType == ExpressionType.Not) { return !(bool)obj; }
            else if (unaryExpression.NodeType == ExpressionType.Negate) { return -(int)obj; }

            return null;
        }
    }
}
