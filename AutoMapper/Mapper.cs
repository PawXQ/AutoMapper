using AutoMapper.Enums;
using AutoMapper.ExpressionMapping;
using AutoMapper.Extensions;
using AutoMapper.Models;
using AutoMapper.TypesMapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Mapper
    {
        public static TDestination Map<Tsource, TDestination>(Tsource source, Action<MapperConfiguration<Tsource, TDestination>> callback) where TDestination : class, new()
        {
            TDestination destination = new TDestination();

            PropertyInfo[] destProps = typeof(TDestination).GetProperties();
            Type sourceType = typeof(Tsource);

            MapperConfiguration<Tsource, TDestination> mapperConfiguration = new MapperConfiguration<Tsource, TDestination>();
            callback.Invoke(mapperConfiguration);

            foreach (PropertyInfo prop in destProps)
            {
                Type destProptyType = prop.PropertyType;


                PropertyInfo sourceTypePropertyInfo = sourceType.GetProperty(prop.Name);

                int constantValue = 0;
                object unaryValue = null;
                object methodcallValue = null;
                object conditionalValue = null;
                object binaryValue = null;
                AClass newAClass = null;
                if (mapperConfiguration.propertyInfoMemberExpressionkeyValuePairs.TryGetValue(prop, out Expression soureExpression))
                {
                    if (soureExpression is MemberExpression memberExpression)
                    {
                        sourceTypePropertyInfo = (PropertyInfo)(memberExpression).Member;
                    }
                    else if (soureExpression is ConstantExpression constantExpression)
                    {
                        constantValue = (int)(constantExpression).Value;
                    }
                    else if (soureExpression is UnaryExpression unaryExpression)
                    {
                        sourceTypePropertyInfo = (PropertyInfo)((MemberExpression)(((UnaryExpression)soureExpression).Operand)).Member;
                        if (unaryExpression.NodeType == ExpressionType.Not)
                        {
                            unaryValue = !(bool)sourceTypePropertyInfo.GetValue(source);
                        }
                        else if (unaryExpression.NodeType == ExpressionType.Negate)
                        {
                            unaryValue = -(int)sourceTypePropertyInfo.GetValue(source);
                        }
                    }
                    else if (soureExpression is MethodCallExpression methodCallExpression)
                    {
                        if (methodCallExpression.Arguments[0] is MemberExpression methodCallExpressionArgumentMemberExpression)
                        {
                            PropertyInfo methodCallExpressionArgumentPropertyInfo = (PropertyInfo)methodCallExpressionArgumentMemberExpression.Member;
                            object methodCallExpressionArgumentProperty = methodCallExpressionArgumentPropertyInfo.GetValue(source);
                            methodcallValue = methodCallExpression.Method.Invoke(source, new object[] { methodCallExpressionArgumentProperty });
                        }
                        else if (methodCallExpression.Arguments[0] is ParameterExpression methodCallExpressionArgumentParameterExpression)
                        {
                            methodcallValue = methodCallExpression.Method.Invoke(source, new object[] { source });
                        }
                    }
                    else if (soureExpression is ConditionalExpression conditionalExpression)
                    {
                        PropertyInfo testMemberExpressionPropertyInfo = (PropertyInfo)((MemberExpression)conditionalExpression.Test).Member;
                        bool testMemberExpressionProperty = (bool)testMemberExpressionPropertyInfo.GetValue(source);

                        string ifTrueValue = ((ConstantExpression)conditionalExpression.IfTrue).Value.ToString();

                        PropertyInfo ifFalseMemberExpressionPropertyInfo = (PropertyInfo)((MemberExpression)conditionalExpression.IfFalse).Member;
                        string ifFalseValue = ifFalseMemberExpressionPropertyInfo.GetValue(source).ToString();

                        conditionalValue = testMemberExpressionProperty ? ifTrueValue : ifFalseValue;
                    }
                    else if (soureExpression is BinaryExpression binaryExpression)
                    {
                        PropertyInfo leftExpressionPropertyInfo = (PropertyInfo)((MemberExpression)binaryExpression.Left).Member;
                        int leftExpressionValue = (int)leftExpressionPropertyInfo.GetValue(source);

                        Expression rightExpression = binaryExpression.Right;
                        string stringConstantValue = ((ConstantExpression)((MethodCallExpression)rightExpression).Arguments[0]).Value.ToString();
                        methodcallValue = ((MethodCallExpression)rightExpression).Method.Invoke(source, new object[] { stringConstantValue });

                        binaryValue = (int)methodcallValue + leftExpressionValue;
                    }
                    else if (soureExpression is NewExpression newExpression)
                    {
                        Type newExpressionType = Type.GetType(newExpression.Type.FullName);
                        newAClass = (AClass)Activator.CreateInstance(newExpressionType);
                    }
                }

                //PropertyInfo sourceTypePropertyInfo = mapperConfiguration.propertyInfoMemberExpressionkeyValuePairs.ContainsKey(prop) ?
                //                                      (PropertyInfo)mapperConfiguration.propertyInfoMemberExpressionkeyValuePairs[prop].Member :
                //                                      sourceType.GetProperty(prop.Name);

                TypeEnum destTypeEnum = destProptyType.RecornizeType();

                Type destTypeMapping = Type.GetType($"AutoMapper.TypesMapping.{destTypeEnum}Mapping");
                ATypeMapping aTypeMapping = (ATypeMapping)Activator.CreateInstance(destTypeMapping);

                object typeConversionResult = null;
                Type sourceTypePropertyInfoType = sourceTypePropertyInfo == null ? null : sourceTypePropertyInfo.PropertyType;

                if (sourceTypePropertyInfoType != null)
                {
                    typeConversionResult = aTypeMapping.TypeConversion(sourceTypePropertyInfo.GetValue(source), sourceTypePropertyInfoType, destProptyType);
                }

                if (soureExpression is MemberExpression)
                {
                    typeConversionResult = aTypeMapping.TypeConversion(sourceTypePropertyInfo.GetValue(source), sourceTypePropertyInfoType, destProptyType);
                }
                else if (soureExpression is ConstantExpression)
                {
                    typeConversionResult = aTypeMapping.TypeConversion(constantValue, sourceTypePropertyInfoType, destProptyType);
                }
                else if (soureExpression is UnaryExpression)
                {
                    typeConversionResult = unaryValue;
                }
                else if (soureExpression is MethodCallExpression)
                {
                    sourceTypePropertyInfoType = methodcallValue.GetType();
                    typeConversionResult = aTypeMapping.TypeConversion(methodcallValue, sourceTypePropertyInfoType, destProptyType);
                }
                else if (soureExpression is ConditionalExpression)
                {
                    typeConversionResult = conditionalValue;
                }
                else if (soureExpression is BinaryExpression)
                {
                    sourceTypePropertyInfoType = binaryValue.GetType();
                    typeConversionResult = aTypeMapping.TypeConversion(binaryValue, sourceTypePropertyInfoType, destProptyType);
                }
                else if (soureExpression is NewExpression)
                {
                    typeConversionResult = newAClass;
                }


                // 轉換 Tsource.X => TDestination.y return propertyinfo
                // 找 TDestination property index
                prop.SetValue(destination, typeConversionResult);
            }

            return destination;
        }

        //public static Mapper Convert(Func<PropertyInfo, PropertyInfo, PropertyInfo> func)
        //{
        //    Type AType = PropertyInfo
        //    func.Invoke(null, null);

        //    return this
        //}
    }
}
