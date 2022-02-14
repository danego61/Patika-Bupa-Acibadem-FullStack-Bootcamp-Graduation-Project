using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public sealed class DtoAddOffer : DtoBase
    {

        public string CustomerId { get; set; } = null!;

        public OfferStatus OfferStatus { get; set; }

    }
}
