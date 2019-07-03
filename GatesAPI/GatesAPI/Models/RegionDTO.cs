using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatesAPI.Models
{
    public class RegionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalGrants { get; set; }
        public long TotalAmount { get; set; }
    }
}
