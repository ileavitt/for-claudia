using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatesAPI.Models
{
    public class FilterCriteria
    {
        public int? TopicId { get; set; }
        public int? RegionId { get; set; }
        public string Year { get; set; }
    }
}
