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
        public string name { get; set; }
        public string id { get; set; }
        public string desc { get; set; }
        public double attack { get; set; }
        public float defense { get; set; }
        public string effect_1 { get; set; }
        public int effect_2 { get; set; }
        public Effect effect_3 { get; set; }
        public Effect effect_4 { get; set; }
        public EffectDTO effect_5 { get; set; }
    }
}
