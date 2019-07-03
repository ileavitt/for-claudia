using System;
using System.Collections.Generic;

namespace GatesAPI.Models
{
    public partial class Topic
    {
        public Topic()
        {
            GrantTopic = new HashSet<GrantTopic>();
        }

        public int Id { get; set; }
        public int TopicGroupId { get; set; }
        public string Name { get; set; }

        public virtual TopicGroup TopicGroup { get; set; }
        public virtual ICollection<GrantTopic> GrantTopic { get; set; }
    }
}
