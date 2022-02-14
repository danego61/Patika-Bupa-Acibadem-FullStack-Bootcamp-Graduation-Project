using Graduation.Project.Entity.IBase;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public sealed class DtoBill : IDtoBase
    {

        public decimal BillId { get; set; }

        public decimal Amount { get; set; }

        public InstallmentTypes Installment { get; set; }

        public DtoBillPayment? Payment { get; set; }

    }
}
