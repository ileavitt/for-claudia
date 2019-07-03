using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gates_API.Models
{
    public class TopicGroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long TotalAmount { get; set; }
        public int TotalGrants { get; set; }
    }
}
