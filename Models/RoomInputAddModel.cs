using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoomInputAddModel
    {
        public int? Id { get; set; }
        public int IdInput { get; set; }
        public int IdRoom { get; set; }
        public int IdSecondaryInput { get; set; }
        public string Description { get; set; }
    }
}
