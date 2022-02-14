using Graduation.Project.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Dal.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntityBase
    {

        T? Find(object id);

        T? Get(Expression<Func<T, bool>> expression);

        List<T> GetAll(Expression<Func<T, bool>>? expression = null);

    }
}
