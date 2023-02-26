using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Circuit { get; set; }
        public string Dev { get; set; }
        public decimal? Value { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
