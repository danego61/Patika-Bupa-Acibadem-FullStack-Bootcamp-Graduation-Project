using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public sealed class DtoAddOfferDetails : DtoBase
    {

        public string CustomerId { get; set; } = null!;

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public Relationships Relationship { get; set; }

        public string Job { get; set; } = null!;

    }
}
