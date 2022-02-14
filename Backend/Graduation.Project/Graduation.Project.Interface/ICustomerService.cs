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
    public interface ICustomerService : IGenericService<Customer>
    {

        IResponse<TDto> AddCustomer<TDto>(DtoAddCustomer customer) where TDto : class, IDtoBase;

    }
}
