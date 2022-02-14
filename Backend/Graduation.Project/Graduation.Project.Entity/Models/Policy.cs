using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;

namespace Graduation.Project.Entity.Models
{
    public class Policy : EntityBase
    {
        public Policy()
        {
            PolicyDetails = new HashSet<PolicyDetail>();
        }

        public decimal PolicyId { get; set; }
        public decimal BillId { get; set; }
        public string CustomerId { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PolicyStatus PolicyStatus { get; set; }
        public decimal ProductId { get; set; }

        public virtual Bill Bill { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<PolicyDetail> PolicyDetails { get; set; }
    }
}
