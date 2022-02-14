using Graduation.Project.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Interface
{
    public interface IGenericService<T> where T : class, IEntityBase
    {

        IResponse<TDto> Find<TDto>(object id) where TDto : class, IDtoBase;

        IResponse<TDto> Get<TDto>(Expression<Func<T, bool>> expression) where TDto : class, IDtoBase;

        IResponse<List<TDto>> GetAll<TDto>(Expression<Func<T, bool>>? expression = null) where TDto : class, IDtoBase;

    }
}
