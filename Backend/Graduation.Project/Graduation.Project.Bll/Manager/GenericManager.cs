using AutoMapper;
using Graduation.Project.Dal.Abstract;
using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Bll.Manager
{
    public class GenericManager<T> : IGenericService<T> where T : class, IEntityBase
    {

        private readonly IGenericRepository<T> repository;
        protected readonly IMapper mapper;

        public GenericManager(IGenericRepository<T> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IResponse<TDto> Find<TDto>(object id) where TDto : class, IDtoBase
        {
            Response<TDto> response;

            T? entity = repository.Find(id);
            if (entity == null)
            {
                response = new Response<TDto>
                {
                    Message = "Not Found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                response = new Response<TDto>
                {
                    Message = "Success",
                    Data = mapper.Map<TDto>(entity),
                    StatusCode = StatusCodes.Status200OK
                };
            }
            return response;
        }

        public IResponse<TDto> Get<TDto>(Expression<Func<T, bool>> expression) where TDto : class, IDtoBase
        {
            Response<TDto> response;

            T? entity = repository.Get(expression);
            if (entity == null)
            {
                response = new Response<TDto>
                {
                    Message = "Not Found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                response = new Response<TDto>
                {
                    Message = "Success",
                    Data = mapper.Map<TDto>(entity),
                    StatusCode = StatusCodes.Status200OK
                };
            }
            return response;
        }

        public IResponse<List<TDto>> GetAll<TDto>(Expression<Func<T, bool>>? expression = null) where TDto : class, IDtoBase
        {
            List<T> entity = repository.GetAll(expression);
            return new Response<List<TDto>>
            {
                Message = "Success",
                Data = mapper.Map<List<TDto>>(entity),
                StatusCode = StatusCodes.Status200OK
            }; ;
        }

    }
}
