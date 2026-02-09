using AutoMapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Models
{
    internal class CardModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Desc { get; set; }
        public decimal Attack { get; set; }
        public long Defense { get; set; }
        public Effect Effect_1 { get; set; }
        public Effect Effect_2 { get; set; }
        public string Effect_3 { get; set; }
        public int Effect_4 { get; set; }
        public Effect Effect_5 { get; set; }
        public List<string> Crystals { get; set; }
        public string[] Crystals2 { get; set; }
        public Stack<string> Crystals3 { get; set; }
        public Queue<string> Crystals4 { get; set; }
    }
}
