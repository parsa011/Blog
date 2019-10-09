using Microsoft.AspNetCore.Mvc;
using Portal.Data.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Web.ViewComponents.SiteInfoComponent
{
    public class SiteInfoComponent : ViewComponent
    {

        private readonly UnitOfWork _db;
        public SiteInfoComponent(UnitOfWork db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.UsersCount = _db.UsersGenericRepository.Where().Count();
            ViewBag.CommentsCount = _db.CommentsGenericRepository.Where().Count();
            ViewBag.PostsCount = _db.PostsGenericRepository.Where().Count();
            ViewBag.CategoriesCount = _db.CategoriesGenericRepository.Where().Count();
            return await Task.FromResult((IViewComponentResult)View("SiteInfo"));
        }
    }
}
