using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Common.ViewModels.Posts;
using Portal.Data.UOW;
using Portal.Domain.Entities;

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
                ViewBag.postId = id;
                return View(detailsPost);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Comment(string postId, string Email, string Name, string cmContent, string parentId)
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(cmContent))
            {
                var comment = new Comment
                {
                    Content = cmContent,
                    Email = Email,
                    Name = Name,
                    ParentId = (!string.IsNullOrEmpty(parentId)) ? int.Parse(parentId) : 0,
                    CreatedTime = DateTime.Now,
                    PostId = postId
                };
                _db.CommentsGenericRepository.Insert(comment);
                _db.Save();
            }
            return RedirectToAction("Details", new { id = postId });
        }

        [HttpGet]
        public IActionResult Search(string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                var model = new List<PostsListViewModel>();
                foreach (var item in _db.PostsGenericRepository.Where(p => p.Title.Contains(searchText)))
                {
                    model.Add(new PostsListViewModel
                    {
                        Title = item.Title,
                        CreatedTime = item.CreatedTime,
                        Id = item.Id,
                        Summary = item.Summary,
                        Image = item.Image
                    });
                }
                return View("Index",model);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult ShowInGroup(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var model = new List<PostsListViewModel>();
                foreach (var item in _db.PostsGenericRepository.Where(p => p.CategoryId == int.Parse(id)))
                {
                    model.Add(new PostsListViewModel
                    {
                        Title = item.Title,
                        CreatedTime = item.CreatedTime,
                        Id = item.Id,
                        Summary = item.Summary,
                        Image = item.Image
                    });
                }
                return View("Index", model);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}