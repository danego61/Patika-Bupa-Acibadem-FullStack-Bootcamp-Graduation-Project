using Graduation.Project.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public class DtoUpdateProductResult : DtoBase
    {

        public decimal BillId { get; set; }

        public decimal Price { get; set; }

    }
}
