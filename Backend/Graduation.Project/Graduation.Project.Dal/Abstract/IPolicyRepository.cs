using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Dal.Abstract
{
    public interface IPolicyRepository : IGenericRepository<Policy>
    {

        List<Policy> GetPolicies(DtoPolicyQuery query);

        Policy AddPolicy(DtoAddPolicy policy);

    }
}
