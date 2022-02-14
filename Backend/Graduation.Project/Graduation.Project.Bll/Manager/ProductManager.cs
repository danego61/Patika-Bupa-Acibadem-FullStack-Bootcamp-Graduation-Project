using AutoMapper;
using Graduation.Project.Dal.Abstract;
using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Entity.Models;
using Graduation.Project.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Bll.Manager
{
    public class ProductManager : GenericManager<Product>, IProductService
    {

        private readonly IProductRepository repository;

        public ProductManager(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
        }

        IResponse<TDto> IProductService.AddProduct<TDto>(DtoAddProduct newProduct)
        {
            Product product = repository.AddProduct(newProduct);
            return new Response<TDto>
            {
                Message = "Success",
                Data = mapper.Map<TDto>(product),
                StatusCode = StatusCodes.Status201Created
            };
        }
    }
}
