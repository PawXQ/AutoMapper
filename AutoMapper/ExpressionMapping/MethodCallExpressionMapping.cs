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

            object obj = methodCallExpression.Method.Invoke(datasource, methodCallExpressionValues.ToArray());

            return obj;


            //var temp = TestExp<CardViewModel>(x => TestMethod(x.Name, 20, new AClass()));
        }

        //private T TestExp<T>(Expression<Func<CardModel, T>> expression)
        //{

        //}

        //private CardViewModel TestMethod(string str, int num, AClass aclss)
        //{

        //}
    }
}
