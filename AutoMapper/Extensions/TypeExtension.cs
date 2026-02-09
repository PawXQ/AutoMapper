using AutoMapper.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Extensions
{
    internal static class TypeExtension
    {
        public static TypeEnum RecornizeType(this Type type)
        {
            if (BasicTypeCheck(type)) return TypeEnum.BasicType;
            if (EnumTypeCheck(type)) return TypeEnum.EnumType;
            if (ArrayTypeCheck(type)) return TypeEnum.ArrayType;
            if (ClassTypeCheck(type)) return TypeEnum.ClassType;
            if (IEnumerableCheck(type).Item1) return IEnumerableCheck(type).Item2;

            throw new NotSupportedException();
        }

        //public static TypeEnum RecornizeType(this Type type)
        //{
        //    if ((type == typeof(string) ||
        //         type == typeof(int) ||
        //         type == typeof(double) ||
        //         type == typeof(float) ||
        //         type == typeof(long) ||
        //         type == typeof(decimal)) &&
        //        !type.IsGenericType)
        //    {
        //        return TypeEnum.BasicType;
        //    }

        //    if (type.IsArray) return TypeEnum.ArrayType;
        //    if (type.IsEnum) return TypeEnum.EnumType;

        //    var interfaces = type.GetInterfaces();

        //    if (type.IsClass && !interfaces.Any(x => x == typeof(IEnumerable))) return TypeEnum.ClassType;

        //    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Stack<>)) return TypeEnum.StackType;
        //    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Queue<>)) return TypeEnum.QueueType;

        //    if (type.GetInterfaces().Any(x => x == typeof(IList))) return TypeEnum.IEnumerableType;

        //    throw new NotSupportedException();
        //}

        private static bool BasicTypeCheck(Type type)
        {
            if ((type == typeof(string) ||
                 type == typeof(int) ||
                 type == typeof(double) ||
                 type == typeof(float) ||
                 type == typeof(long) ||
                 type == typeof(decimal)) &&
                !type.IsGenericType)
            {
                return true;
            }
            return false;
        }

        private static bool EnumTypeCheck(Type type)
        {
            return type.IsEnum;
        }
        private static bool ArrayTypeCheck(Type type)
        {
            return type.IsArray;
        }
        private static bool ClassTypeCheck(Type type)
        {
            var interfaces = type.GetInterfaces();

            return type.IsClass && !interfaces.Any(x => x == typeof(IEnumerable));
        }

        private static (bool, TypeEnum) IEnumerableCheck(Type type)
        {
            var interfaces = type.GetInterfaces();
            if (!interfaces.Any(x => x == typeof(IEnumerable))) return (false, default);

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Stack<>)) return (true, TypeEnum.StackType);
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Queue<>)) return (true, TypeEnum.QueueType);

            return (true, TypeEnum.IEnumerableType);
        }

    }
}
