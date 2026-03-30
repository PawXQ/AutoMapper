using AutoMapper.Enums;
using AutoMapper.ExpressionMapping;
using AutoMapper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Models
{
    internal class ExpressionModel
    {
        public Expression Expression { get; set; }

        public ExpressionModel(Expression expression)
        {
            this.Expression = expression;
        }

        public object GetExpressionValue(object dataSource)
        {
            ExpressionEnum expressionEnum = this.Expression.RecornizeExpression();

            Type ExpressionType = Type.GetType($"AutoMapper.ExpressionMapping.{expressionEnum}Mapping");
            AExpressionMapping aExpressionMapping = (AExpressionMapping)Activator.CreateInstance(ExpressionType);

            object expressionValue = aExpressionMapping._GetExpressionValue(dataSource, this.Expression);

            return expressionValue;
        }
    }
}
