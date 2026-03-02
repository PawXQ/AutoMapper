using AutoMapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Models
{
    internal class CardViewModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Desc { get; set; }
        public double Attack { get; set; }
        public float Defense { get; set; }
        public string Effect_1 { get; set; }
        public int Effect_2 { get; set; }
        public Effect Effect_3 { get; set; }
        public Effect Effect_4 { get; set; }
        public EffectDTO Effect_5 { get; set; }
        //public List<string> Crystals { get; set; }
        //public string[] Crystals2 { get; set; }
        //public Stack<EffectDTO> Crystals3 { get; set; }
        //public Queue<int> Crystals4 { get; set; }
        //public BClass Crystals5 { get; set; } = new BClass();
    }
}
