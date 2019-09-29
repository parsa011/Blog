using Portal.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Portal.Data.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Portal.Data.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region ctor
        private readonly BlogDbContext _db;
        private readonly DbSet<TEntity> _Entity;
        public GenericRepository(BlogDbContext context)
        {
            _db = context;
            _Entity = _db.Set<TEntity>();
        }
        #endregion

        #region actions
        public void Delete(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _Entity.Attach(entity);
            }
            _Entity.Remove(entity);
        }

        public void Delete(object Id)
        {
            var entity = GetById(Id);
            Delete(entity);
        }

        public TEntity GetById(object Id)
        {
            return _Entity.Find(Id);
        }

        public async void Insert(TEntity entity)
        {
            await _Entity.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _Entity.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> entities = _Entity;
            if (where != null)
            {
                entities = entities.Where(where);
            }
            return entities.ToList();
        }
        #endregion
    }
}
