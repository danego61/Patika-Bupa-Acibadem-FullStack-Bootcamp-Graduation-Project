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
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {

        private readonly IProcedureFunctions procedures;

        public EfProductRepository(IProcedureFunctions procedures, DbContext context) : base(context)
        {
            this.procedures = procedures;
        }

        public Product AddProduct(DtoAddProduct newProduct)
        {
            return new Product
            {
                ProductName = newProduct.ProductName,
                IsEnabled = true,
                Price = newProduct.Price,
                ProductId = procedures.SpAddProduct(newProduct)
            };
        }
    }
}
