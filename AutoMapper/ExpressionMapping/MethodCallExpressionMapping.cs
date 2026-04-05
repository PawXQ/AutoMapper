using AutoMapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ExpressionMapping
{
    internal class MethodCallExpressionMapping : AExpressionMapping
    {
        public override object _GetExpressionValue(object datasource, Expression expression)
        {
            MethodCallExpression methodCallExpression = (MethodCallExpression)expression;

            List<object> methodCallExpressionValues = new List<object> { };

            foreach (Expression methodCallArgumentsexpression in methodCallExpression.Arguments)
            {
                object methodCallExpressionValue = GetExpressionValue(datasource, methodCallArgumentsexpression);
                methodCallExpressionValues.Add(methodCallExpressionValue);
            }

            if (methodCallExpression.Arguments.Count == 0)
            {
                object data = GetExpressionValue(datasource, methodCallExpression.Object);
                return methodCallExpression.Method.Invoke(data, new object[] { });
            }

            object obj = methodCallExpression.Method.Invoke(null, methodCallExpressionValues.ToArray());

            return obj;

        }
    }
}
