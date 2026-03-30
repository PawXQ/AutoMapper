using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Enums
{
    internal enum ExpressionEnum
    {
        BinaryExpression = 0,
        ConditionalExpression = 1,
        ConstantExpression = 2,
        MemberExpression = 3,
        MethodCallExpression = 4,
        NewExpression = 5,
        ParameterExpression = 6,
        UnaryExpression = 7,
    }
}
