using Graduation.Project.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public sealed class DtoProduct : DtoBase
    {

        public decimal ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public bool IsEnabled { get; set; }

    }
}
