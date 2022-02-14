using Graduation.Project.Entity.IBase;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public sealed class DtoOffer : IDtoBase
    {

        public decimal OfferNumber { get; set; }

        public decimal? BillId { get; set; }

        public OfferStatus OfferStatus { get; set; }

        public DateTime? EndTime { get; set; }


        public DtoBill? Bill { get; set; }

        public DtoCustomer Customer { get; set; } = null!;

        public DtoProduct? SelectedProduct { get; set; }

        public ICollection<DtoOfferDetail> OfferDetails { get; set; }

    }
}
