using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public sealed class DtoAddPolicy : DtoBase
    {

        public int OfferId { get; set; }

        public PolicyStatus PolicyStatus { get; set; }

    }
}
