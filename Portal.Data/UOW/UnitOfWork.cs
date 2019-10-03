using Portal.Data.DataBaseContext;
using Portal.Data.Interfaces;
using Portal.Data.Services;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data.UOW
{
    public class UnitOfWork : IDisposable
    {
        #region ctor
        private readonly BlogDbContext _db;
        public UnitOfWork(BlogDbContext db)
        {
            _db = db;
        }
        #endregion

        #region repositories
        private IGenericRepository<Users> _usersGenericRepository;
        public IGenericRepository<Users> UsersGenericRepository {
            get
            {
                if (_usersGenericRepository == null)
                {
                    _usersGenericRepository = new GenericRepository<Users>(_db);
                }
                return _usersGenericRepository;
            }
        }
        #endregion

        #region actions
        public async void SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void Dispose()
        {
            this.Dispose();
        }
        #endregion
    }
}
