using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public sealed class DtoPolicy : DtoBase
    {

        public decimal PolicyId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public PolicyStatus PolicyStatus { get; set; }

        
        public DtoBill Bill { get; set; } = null!;

        public DtoCustomer Customer { get; set; } = null!;

        public DtoProduct Product { get; set; } = null!;

        public ICollection<DtoPolicyDetail> PolicyDetails { get; set; }

    }
}
