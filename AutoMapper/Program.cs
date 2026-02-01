using AutoMapper.Enums;
using AutoMapper.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // enum 轉 long, double,float

            // HW: List<string>"1","2","3","4" => List<int>

            //Console.WriteLine(typeof(Stack<>));
            Console.WriteLine(typeof(Queue<>));


            var cardModel = new CardModel();
            //cardModel.Id = 1;
            //cardModel.Name = "a";
            //cardModel.Desc = "aaa";
            //cardModel.Attack = 10.123456789101112131415m;
            //cardModel.Defense = 12345678910111213;
            //cardModel.Effect_1 = Effect.angry;
            //cardModel.Effect_2 = Effect.poison;
            //cardModel.Effect_3 = "windfury";
            //cardModel.Effect_4 = ((int)Effect.Battlecry);
            //cardModel.Effect_5 = Effect.DivineShield;
            cardModel.Crystals = new List<string> { "1", "2" };
            cardModel.Crystals2 = new string[] { "1", "2" };
            cardModel.Crystals3 = new Stack<string>(new string[] { "1", "2" });
            cardModel.Crystals4 = new Queue<string>(new string[] { "1", "2" });


            ////Console.WriteLine(((int)Effect.angry));

            var data = Mapper.Map<CardModel, CardViewModel>(cardModel);


            object strs = new string[] { "1", "2", "3", "4", "5" };
            Type desType = typeof(int[]);

            Type sourceType = strs.GetType();

            if (sourceType.IsArray)
            {
                var sourceArray = (Array)strs;

                //1. 我要怎麼知道自己&目標Array是甚麼類型?
                //2. 我要如何知道他有幾筆資料
                //3. 如何動態創建一個array

                Type sourceElementType = sourceType.GetElementType();
                Array destArray = Array.CreateInstance(desType.GetElementType(), sourceArray.Length);

                for (int i = 0; i < sourceArray.Length; i++)
                {
                    destArray.SetValue(int.Parse(sourceArray.GetValue(i).ToString()), i);
                }
            }




            //object strs = new List<string>() { "1", "2", "3", "4", "5" };
            //Type destType = typeof(List<int>);
            ////Type destType = typeof(CardViewModel<int, string>);

            ////1. 我要怎麼知道自己或者對方是List?
            ////2. 我要怎麼創造出 List<int> 出來?
            ////3. 我真正要轉的是 string=>int, 而不是List<string> => List<int> 但我怎麼知道 <T> 是甚麼東西?

            ////檢查自己是否為List
            //var tmp = strs.GetType().GetInterfaces();
            //bool isEnumerable = strs.GetType().GetInterfaces().Any(x => x == typeof(IEnumerable));

            //string name = destType.FullName;

            ////解掉當前 destType 泛型<>
            //Type typeDefinition = destType.GetGenericTypeDefinition(); // List<> List'1

            ////拿到List`裡面的數量以及類型
            //Type[] typeArgments = destType.GetGenericArguments();

            ////取得第一個List int 型別
            //Type intType = typeArgments[0];

            ////取得Parse方法
            //MethodInfo intMethod = intType.GetMethod("Parse", new Type[] { typeof(string) });

            ////製作List<T>
            //var intListType = typeDefinition.MakeGenericType(typeArgments);

            ////實體化List<int>
            //List<int> ints = (List<int>)Activator.CreateInstance(intListType);

            ////跑迭代模式，一個蘿蔔一個坑把東西填進去
            //MethodInfo enumeratorMethodType = strs.GetType().GetMethod("GetEnumerator");
            //IEnumerator enumerator = (IEnumerator)enumeratorMethodType.Invoke(strs, null);

            //while (enumerator.MoveNext())
            //{
            //    ints.Add((int)intMethod.Invoke(null, new object[] { enumerator.Current }));
            //}
        }
    }
}
