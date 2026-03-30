using AutoMapper.Enums;
using AutoMapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionMapping
{
    internal abstract class AExpressionMapping
    {
        public abstract object _GetExpressionValue(object datasource, Expression expression);

        public object GetExpressionValue(object datasource, Expression expression)
        {
            ExpressionModel expressionModel = new ExpressionModel(expression);

            object result = expressionModel.GetExpressionValue(datasource);

            return result;
        }
    }
}
