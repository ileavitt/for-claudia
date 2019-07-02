﻿using System;
using System.Collections.Generic;

namespace GatesAPI.Models
{
    public partial class Region
    {
        public Region()
        {
            GrantRegion = new HashSet<GrantRegion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GrantRegion> GrantRegion { get; set; }
    }
}
