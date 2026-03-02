using AutoMapper.Enums;
using AutoMapper.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
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

            //Console.WriteLine(typeof(Queue<>));
            //var tmp = typeof(Queue<>).GetInterfaces();
            //var tmp1 = typeof(Queue<>);
            //var tmp2 = typeof(TypeEnum).GetInterfaces();
            //var tmp21 = typeof(TypeEnum);
            //var tmp3 = typeof(int).GetInterfaces();
            //var tmp31 = typeof(int);
            //var tmp4 = typeof(CardModel).GetInterfaces();
            //var tmp41 = typeof(CardModel);
            //var tmp5 = typeof(string).GetInterfaces();
            //var tmp51 = typeof(string);

            //var tmpEnum = Enum.GetName(typeof(Effect), 1);
            //var tmpEnum2 = Enum.Parse(typeof(Effect), "1");
            //var tmpEnum3 = Enum.Parse(typeof(Effect), "angry");

            //Console.WriteLine((int)Effect.angry);


            var cardModel = new CardModel();
            cardModel.Id = 1;
            cardModel.Name = "a";
            cardModel.Desc = "aaa";
            cardModel.Attack = 10.123456789101112131415m;
            cardModel.Defense = 12345678910111213;
            cardModel.Effect_1 = Effect.angry;
            cardModel.Effect_2 = Effect.poison;
            cardModel.Effect_3 = "windfury";
            cardModel.Effect_4 = ((int)Effect.Battlecry);
            cardModel.Effect_5 = Effect.DivineShield;
            //cardModel.Crystals = new List<Effect> { Effect.angry, Effect.poison };
            //cardModel.Crystals2 = new int[] { 1, 2 };
            //cardModel.Crystals3 = new Stack<Effect>(new Effect[] { Effect.angry, Effect.poison });
            //cardModel.Crystals4 = new Queue<Effect>(new Effect[] { Effect.angry, Effect.poison });
            //cardModel.Crystals5 = new AClass() { ConverClass = new CClass() { Id = 1, Crystals = new List<string> { "1", "2" } } };



            var data = Mapper.Map<CardModel, CardViewModel>(cardModel);
        }
    }
}
