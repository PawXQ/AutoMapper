using AutoMapper.Enums;
using AutoMapper.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cardModel = new CardModel();
            cardModel.id = 1;
            cardModel.name = "a";
            cardModel.desc = "aaa";
            cardModel.attack = 10.123456789101112131415m;
            cardModel.defense = 12345678910111213;
            cardModel.effect_1 = Effect.angry;
            cardModel.effect_2 = Effect.poison;
            cardModel.effect_3 = "windfury";
            cardModel.effect_4 = ((int)Effect.Battlecry);
            cardModel.effect_5 = Effect.DivineShield;

            //Console.WriteLine(((int)Effect.angry));

            var data = Mapper.Map<CardModel, CardViewModel>(cardModel);
        }
    }
}
