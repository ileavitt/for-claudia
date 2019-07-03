using System;
using System.Collections.Generic;

namespace Gates_API.Models
{
    public partial class Organization
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
