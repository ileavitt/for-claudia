using System;
using System.Collections.Generic;

namespace Gates_API.Models
{
    public partial class GrantRegion
    {
        public int Id { get; set; }
        public int GrantId { get; set; }
        public int RegionId { get; set; }

        public virtual Grant Grant { get; set; }
        public virtual Region Region { get; set; }
    }
}
