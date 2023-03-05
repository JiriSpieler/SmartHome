using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ThermoRuleModel
    {
        public int Id { get; set; }
        public decimal Temp { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int WeekDay { get; set; }
        public bool IntervalStatus { get; set; }
        public bool Disabled { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
