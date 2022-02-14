using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Interface
{
    public interface IPolicyService : IGenericService<Policy>
    {

        IResponse<List<TDto>> GetPolicies<TDto>(DtoPolicyQuery query) where TDto : class, IDtoBase;

        IResponse<TDto> AddPolicy<TDto>(DtoAddPolicy policy) where TDto : class, IDtoBase;

    }
}
