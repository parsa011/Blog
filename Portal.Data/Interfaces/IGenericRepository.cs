using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Portal.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where = null);
        TEntity GetById(object Id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(object Id);
    }
}
