using Graduation.Project.Entity.IBase;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public sealed class DtoBillPayment : IDtoBase
    {

        public decimal PaymentId { get; set; }

        public string CardNo { get; set; } = null!;

        public string CardName { get; set; } = null!;

        public byte CardDateMounth { get; set; }

        public byte CardDateYear { get; set; }

        public string CardType { get; set; } = null!;

    }
}
