using Portal.Data.DataBaseContext;
using Portal.Data.Interfaces;
using Portal.Data.Services;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data.UOW
{
    public class UnitOfWork 
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

        private IGenericRepository<Role> _rolesGenericRepository;
        public IGenericRepository<Role> RolesGenericRepository
        {
            get
            {
                if (_rolesGenericRepository == null)
                {
                    _rolesGenericRepository = new GenericRepository<Role>(_db);
                }
                return _rolesGenericRepository;
            }
        }

        private IGenericRepository<Post> _postsGenericRepository;
        public IGenericRepository<Post> PostsGenericRepository
        {
            get
            {
                if (_postsGenericRepository == null)
                {
                    _postsGenericRepository = new GenericRepository<Post>(_db);
                }
                return _postsGenericRepository;
            }
        }

        private IGenericRepository<Comment> _commentsGenericRepository;
        public IGenericRepository<Comment> CommentsGenericRepository
        {
            get
            {
                if (_commentsGenericRepository == null)
                {
                    _commentsGenericRepository = new GenericRepository<Comment>(_db);
                }
                return _commentsGenericRepository;
            }
        }

        private IGenericRepository<Category> _categoriesGenericRepository;
        public IGenericRepository<Category> CategoriesGenericRepository
        {
            get
            {
                if (_categoriesGenericRepository == null)
                {
                    _categoriesGenericRepository = new GenericRepository<Category>(_db);
                }
                return _categoriesGenericRepository;
            }
        }
        #endregion

        #region actions
        public void Save()
        {
            _db.SaveChanges();
        }


        public void Dispose()
        {
            this.Dispose();
        }
        #endregion
    }
}
