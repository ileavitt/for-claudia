using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gates_API.Models
{
    public class GrantListDTO
    {
        public GrantListDTO()
        {
            Grants = new HashSet<Grant>();
        }
        public int TotalGrants { get; set; }
        public long TotalAmount { get; set; }
        
        public virtual ICollection<Grant> Grants { get; set; }
    }
}
