using System;
using System.Collections.Generic;

namespace Gates_API.Models
{
    public partial class TopicGroup
    {
        public TopicGroup()
        {
            Topic = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Topic> Topic { get; set; }
    }
}
