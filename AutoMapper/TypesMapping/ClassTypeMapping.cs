using AutoMapper.Enums;
using AutoMapper.Extensions;
using AutoMapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.TypesMapping
{
    internal class ClassTypeMapping : ATypeMapping
    {
        public override object TypeConversion(object sourceData, Type sourceType, Type destType)
        {
            if (sourceData == null) return null;
            //var data = Mapper.Map<souceType, CardViewModel>(cardModel);

            //MethodInfo mapperMapMethod = typeof(Mapper).GetMethod("Map", new Type[] { sourceType });
            MethodInfo mapperMapMethod = typeof(Mapper).GetMethods()
                                                       .First(x => x.Name == "Map");
            MethodInfo mapperMapGenericMethod = mapperMapMethod.MakeGenericMethod(sourceType, destType);

            return mapperMapGenericMethod.Invoke(null, new object[] { sourceData, null });

            //souceType.MakeGenericType(destType);

            //typeof(Mapper).GetMethod("Map").MakeGenericMethod(destType).Invoke;
            //return Mapper.Map<CardModel, CardViewModel>(sourceData);
        }
    }
}
