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
    public interface IProductRepository : IGenericRepository<Product>
    {

        Product AddProduct(DtoAddProduct newProduct);

    }
}
