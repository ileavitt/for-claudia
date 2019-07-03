using System;
using System.Collections.Generic;

namespace Gates_API.Models
{
    public partial class Grant
    {

        public int Id { get; set; }
        public string OpportunityId { get; set; }
        public string Title { get; set; }
        public long Amount { get; set; }
        public DateTime StartDate { get; set; }
        public int OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
