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
            cardModel.Id = -1;
            cardModel.Name = "22";
            cardModel.IsHero = true;
            //cardModel.Desc = "aaa";
            //cardModel.Attack = 10.123456789101112131415m;
            //cardModel.Defense = 12345678910111213;
            //cardModel.Effect_1 = Effect.angry;
            //cardModel.Effect_2 = Effect.poison;
            //cardModel.Effect_3 = "windfury";
            //cardModel.Effect_4 = ((int)Effect.Battlecry);
            //cardModel.Effect_5 = Effect.DivineShield;
            //cardModel.Crystals = new List<Effect> { Effect.angry, Effect.poison };
            cardModel.Crystals2 = new int[] { 1, 2 };
            //cardModel.Crystals3 = new Stack<Effect>(new Effect[] { Effect.angry, Effect.poison });
            //cardModel.Crystals4 = new Queue<Effect>(new Effect[] { Effect.angry, Effect.poison });
            cardModel.Crystals5 = new AClass() { ConverClass = new CClass() { Id = 1, Crystals = new List<string> { "1", "2" } } };


            //var data = Mapper.Map<CardModel, CardViewModel>(cardModel);
            var data = Mapper.Map<CardModel, CardViewModel>(cardModel, x =>
            {
                x.ForMember(y => y.Id.ToString(), z => z.Id)
                //.ForMember(y => y.Name, z => z.Desc)
                //x.ForMember(y => !y.IsHero, z => z.IsHero)
                //.ForMember(y => !y.IsHero, z => z.IsHero)
                //.ForMember(y => -y.Id, z => z.intNegate)
                //.ForMember(y => ReturnInt(y), z => z.Desc) //Parameter
                //.ForMember(y => new AClass(), z => z.Crystals5); // New
                //.ForMember(y => y.Id + MultiArgu(29, 28) - 30 + -y.Id - (2 * y.Id + 'a'), z => z.Desc2); // Biniary
                //.ForMember(y => y.IsHero ? "HELLO" : y.Name, z => z.Desc2); // Condition
                .ForMember(y => int.Parse(y.Name), z => z.Desc);
                //.ForMember(y => 50, z => z.Desc2);
            });

            //var data = Mapper.Map<CardModel, CardViewModel>(cardModel,cfg=>{
            //
            //      cfg.ForMember(x.id,y.ID)
            //         .ForMember(x.name,y.CardName)
            //
            //})

            //List<int> ints = new List<int>();
            //ints.OrderBy(i => i).ToList();
            bool a = false;
            int b = 20;
            //GetCard(data, x => x.Id);
        }

        private static int ReturnInt(CardModel cardModel)
        {
            return cardModel.Id + 1;
        }

        private static int MultiArgu(int num1, int num2)
        {
            return num1 + num2;
        }


        private static void GetCard<T>(CardViewModel viewModel, Expression<Func<CardViewModel, T>> data)
        {
            MethodCallExpression memberExpression = data.Body as MethodCallExpression;
            //string name = memberExpression.Member.Name;
            //PropertyInfo res1 = null;
            //PropertyInfo[] sourceProps = typeof(CardViewModel).GetProperties();

            //foreach (PropertyInfo sourceProp in sourceProps)
            //{
            //    if (sourceProp.GetValue(viewModel).Equals(data.Invoke(viewModel)))
            //    {
            //        res1 = sourceProp;
            //    }
            //}

            // var res = data.Invoke(viewModel);
        }


        //Member  O=> 直接傳入類別屬性
        //Constant  O=> 常數使用
        //Unary => !x.Enabled  => 一元運算等簡單運算
        //MethodCall => 函數呼叫完後的結果
        //Conditional => 條件式 (三元運算式)
        //Binary => 當今天有多種條件
        //Parameter
        //New
    }
}
