using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoomModel
    {
        public int ID { get; set; }
        public decimal DefaultTemp { get; set; }
        public decimal Hystersis { get; set; }
        public string Name { get; set; }
    }
}
