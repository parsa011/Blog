using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Common.ViewModels.Posts;
using Portal.Data.UOW;

namespace Portal.Web.Areas.Admin.Controllers
{
    [Area(areaName:"Admin")]
    [Authorize(Roles = "Admin")]
    public class PostsController : Controller
    {
        private readonly UnitOfWork _db;
        public PostsController(UnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var model = new List<PostsListViewModel>();
            foreach (var item in _db.PostsGenericRepository.Where())
            {
                model.Add(new PostsListViewModel {
                    Category = _db.CategoriesGenericRepository.Where(c => c.Id == item.CategoryId).FirstOrDefault().Title,
                    Image = item.Image,
                    Title = item.Title,
                    Summary = item.Summary,
                    Id = item.Id
                });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _db.CategoriesGenericRepository.Where().ToList();
            return View();
        }
    }
}