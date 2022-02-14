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
    public class CustomerManager : GenericManager<Customer>, ICustomerService
    {

        private readonly ICustomerRepository repository;

        public CustomerManager(ICustomerRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
        }

        IResponse<TDto> ICustomerService.AddCustomer<TDto>(DtoAddCustomer customer)
        {
            Customer newCustomer = repository.AddCustomer(customer);
            return new Response<TDto>
            {
                Message = "Success",
                Data = mapper.Map<TDto>(newCustomer),
                StatusCode = StatusCodes.Status201Created
            };
        }
    }
}
