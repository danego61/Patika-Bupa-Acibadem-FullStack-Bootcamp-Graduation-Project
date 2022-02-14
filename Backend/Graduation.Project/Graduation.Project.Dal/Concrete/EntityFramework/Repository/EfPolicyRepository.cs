using Graduation.Project.Dal.Abstract;
using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Dal.Concrete.EntityFramework.Repository
{
    public class EfPolicyRepository : EfGenericRepository<Policy>, IPolicyRepository
    {

        private readonly IProcedureFunctions procedure;

        public EfPolicyRepository(DbContext context, IProcedureFunctions procedure) : base(context)
        {
            this.procedure = procedure;
        }

        public Policy AddPolicy(DtoAddPolicy policy)
        {
            return Find(procedure.SpAddPolicy(policy))!;
        }

        public List<Policy> GetPolicies(DtoPolicyQuery query)
        {
            return procedure.SpGetPolicyQuery(query);
        }

    }
}
