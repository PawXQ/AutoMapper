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
        public string name { get; set; }
        public int id { get; set; }
        public string desc { get; set; }
        public decimal attack { get; set; }
        public long defense { get; set; }
        public Effect effect_1 { get; set; }
        public Effect effect_2 { get; set; }
        public string effect_3 { get; set; }
        public int effect_4 { get; set; }
        public Effect effect_5 { get; set; }
    }
}
