using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;

namespace Graduation.Project.Entity.Models
{
    public class BillPayment : EntityBase
    {

        public BillPayment()
        {
            Bills = new HashSet<Bill>();
        }

        public decimal PaymentId { get; set; }

        public string CardNo { get; set; } = null!;

        public string CardName { get; set; } = null!;

        public byte CardDateMounth { get; set; }

        public byte CardDateYear { get; set; }

        public string CardType { get; set; } = null!;


        public virtual ICollection<Bill> Bills { get; set; }

    }
}
