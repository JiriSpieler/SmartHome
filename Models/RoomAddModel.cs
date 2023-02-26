using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoomAddModel
    {
        public string Name { get; set; }
        public decimal DefaultTemp { get; set; }
        public decimal Hystersis { get; set; }
    }
}
