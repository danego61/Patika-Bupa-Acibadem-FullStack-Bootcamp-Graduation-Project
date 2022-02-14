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
    public interface IProductService : IGenericService<Product>
    {

        IResponse<TDto> AddProduct<TDto>(DtoAddProduct newProduct) where TDto : class, IDtoBase;

    }
}
