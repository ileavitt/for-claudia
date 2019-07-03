using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gates_API.Models
{
    public class GrantDTO
    {
        public GrantDTO()
        {
            Region = new HashSet<Region>();
            TopicGroup = new HashSet<TopicGroup>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public long Amount { get; set; }
        public DateTime StartDate { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<Region> Region { get; set; }
        public virtual ICollection<TopicGroup> TopicGroup { get; set; }
    }
}
