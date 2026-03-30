using AutoMapper.Enums;
using AutoMapper.ExpressionMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Extensions
{
    internal static class ExpressionExtension
    {
        public static ExpressionEnum RecornizeExpression(this Expression expression)
        {
            if (expression is MemberExpression) return ExpressionEnum.MemberExpression;
            else if (expression is ConstantExpression) return ExpressionEnum.ConstantExpression;
            else if (expression is UnaryExpression) return ExpressionEnum.UnaryExpression;
            else if (expression is MethodCallExpression) return ExpressionEnum.MethodCallExpression;
            else if (expression is BinaryExpression) return ExpressionEnum.BinaryExpression;
            else if (expression is ParameterExpression) return ExpressionEnum.ParameterExpression;
            else if (expression is NewExpression) return ExpressionEnum.NewExpression;
            else if (expression is ConditionalExpression) return ExpressionEnum.ConditionalExpression;

            throw new NotSupportedException();
        }
    }
}
