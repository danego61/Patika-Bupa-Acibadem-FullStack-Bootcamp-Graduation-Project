using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;

namespace Graduation.Project.Entity.Models
{
    public class Bill : EntityBase
    {

        public Bill()
        {
            Offers = new HashSet<Offer>();
            Policies = new HashSet<Policy>();
        }

        public decimal BillId { get; set; }

        public decimal Amount { get; set; }

        public decimal? PaymentId { get; set; }

        public InstallmentTypes? Installment { get; set; }


        public virtual BillPayment? Payment { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }

    }
}
