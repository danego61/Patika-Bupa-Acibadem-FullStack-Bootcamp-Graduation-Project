using Graduation.Project.Entity.IBase;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Dto
{
    public sealed class DtoPolicyQuery : IDtoBase
    {

        public string? ByInsurerTC { get; set; }

        public string? ByInsurerName { get; set; }

        public string? ByInsurerSurname { get; set; }

        public string? ByInsuredTC { get; set; }

        public string? ByInsuredName { get; set; }

        public string? ByInsuredSurname { get; set; }

        public decimal? ByPolicyNumber { get; set; }

        public PolicyStatus? ByPolicyStatus { get; set; }

    }
}
