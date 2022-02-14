using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;

namespace Graduation.Project.Entity.Models
{
    public class OfferDetail : EntityBase
    {
        public decimal OfferId { get; set; }
        public string CustomerId { get; set; } = null!;
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public Relationships Relationship { get; set; }
        public string Job { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
        public virtual Offer Offer { get; set; } = null!;
    }
}
