using Graduation.Project.Dal.Abstract;
using Graduation.Project.Entity.IBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Dal.Concrete.EntityFramework.Repository
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase
    {

        #region Variables

        protected DbContext context;
        protected DbSet<T> dbset;

        #endregion

        #region Constructor

        public EfGenericRepository(DbContext context)
        {
            this.context = context;
            dbset = this.context.Set<T>();
        }

        #endregion

        #region Methods

        public T? Find(object id)
        {
            return dbset.Find(id);
        }

        public T? Get(Expression<Func<T, bool>> expression)
        {
            return dbset.Where(expression).SingleOrDefault();
        }

        public List<T> GetAll(Expression<Func<T, bool>>? expression = null)
        {
            return expression != null ? dbset.Where(expression).ToList() : dbset.ToList();
        }

        #endregion
    }
}
