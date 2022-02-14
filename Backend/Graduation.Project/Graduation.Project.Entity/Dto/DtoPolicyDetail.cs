using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public sealed class DtoPolicyDetail : DtoBase
    {

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public Relationships Relationship { get; set; }

        public string Job { get; set; } = null!;


        public DtoCustomer Customer { get; set; } = null!;

    }
}
