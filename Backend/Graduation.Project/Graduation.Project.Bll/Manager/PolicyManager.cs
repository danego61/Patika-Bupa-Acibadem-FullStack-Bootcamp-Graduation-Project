using AutoMapper;
using Graduation.Project.Dal.Abstract;
using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Entity.Models;
using Graduation.Project.Entity.Static;
using Graduation.Project.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Bll.Manager
{
    public class PolicyManager : GenericManager<Policy>, IPolicyService
    {

        private readonly IPolicyRepository repository;

        public PolicyManager(IPolicyRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
        }

        public IResponse<TDto> AddPolicy<TDto>(DtoAddPolicy policy) where TDto : class, IDtoBase
        {
            policy.PolicyStatus = PolicyStatus.Active;
            return new Response<TDto>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status201Created,
                Data = mapper.Map<TDto>(repository.AddPolicy(policy))
            };
        }

        public IResponse<List<TDto>> GetPolicies<TDto>(DtoPolicyQuery query) where TDto : class, IDtoBase
        {
            return new Response<List<TDto>>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = mapper.Map<List<TDto>>(repository.GetPolicies(query))
            };
        }
    }
}
