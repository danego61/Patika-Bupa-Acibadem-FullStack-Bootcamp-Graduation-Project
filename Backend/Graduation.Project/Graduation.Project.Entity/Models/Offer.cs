using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;

namespace Graduation.Project.Entity.Models
{
    public class Offer : EntityBase
    {
        public Offer()
        {
            OfferDetails = new HashSet<OfferDetail>();
        }

        public decimal OfferNumber { get; set; }
        public decimal? SelectedProduct { get; set; }
        public decimal? BillId { get; set; }
        public OfferStatus OfferStatus { get; set; }
        public string CustomerId { get; set; } = null!;
        public DateTime? EndTime { get; set; }

        public virtual Bill? Bill { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public virtual Product? SelectedProductNavigation { get; set; }
        public virtual ICollection<OfferDetail> OfferDetails { get; set; }
    }
}
