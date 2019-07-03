using System;
using System.Collections.Generic;

namespace Gates_API.Models
{
    public partial class GrantTopic
    {
        public int Id { get; set; }
        public int GrantId { get; set; }
        public int TopicId { get; set; }

        public virtual Grant Grant { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
