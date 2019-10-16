using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Common.ViewModels.Posts;
using Portal.Data.UOW;

namespace Portal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _db;
        public HomeController(UnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var post = _db.PostsGenericRepository.Where(p => p.Id == id).FirstOrDefault();
                post.ViewCount++;
                _db.PostsGenericRepository.Update(post);
                _db.Save();
                var detailsPost = new PostDetailsViewModel
                {
                    Id = post.Id,
                    Content = post.Content,
                    ViewCount = post.ViewCount,
                    CreatedDate = post.CreatedTime,
                    Image = post.Image,
                    Summary = post.Summary,
                    Title = post.Title,
                    Category = _db.CategoriesGenericRepository.Where(c => c.Id == post.CategoryId).FirstOrDefault().Title
                };
                return View(detailsPost);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}