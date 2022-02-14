using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public sealed class DtoAddCustomer : DtoBase
    {

        public string? TcNo { get; set; }

        public string? Passaport { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public Genders Gender { get; set; }

        public string Gsm { get; set; } = null!;

        public string Mail { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime Birthdate { get; set; }

    }
}
