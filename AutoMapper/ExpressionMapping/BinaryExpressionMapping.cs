using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionMapping
{
    internal class BinaryExpressionMapping : AExpressionMapping
    {
        public override object _GetExpressionValue(object datasource, Expression expression)
        {
            BinaryExpression binaryExpression = (BinaryExpression)expression;

            object obj = null;

            object objLeft = GetExpressionValue(datasource, binaryExpression.Left);
            object objRight = GetExpressionValue(datasource, binaryExpression.Right);

            if (binaryExpression.NodeType == ExpressionType.Add) { obj = (int)objLeft + (int)objRight; }
            else if (binaryExpression.NodeType == ExpressionType.Subtract) { obj = (int)objLeft - (int)objRight; }

            return obj;
        }
    }
}
