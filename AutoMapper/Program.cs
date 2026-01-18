using System;
using System.Collections.Generic;
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
            var data = Mapper.Map<CardViewModel>(cardModel);
        }
    }
}
