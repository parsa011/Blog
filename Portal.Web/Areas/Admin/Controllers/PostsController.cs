using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portal.Common.ViewModels.Posts;
using Portal.Data.UOW;
using Portal.Domain.Entities;

namespace Portal.Web.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    [Authorize(Roles = "Admin")]
    public class PostsController : Controller
    {
        private readonly UnitOfWork _db;
        private readonly IHostingEnvironment _environment;
        public PostsController(UnitOfWork db, IHostingEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var model = new List<PostsListViewModel>();
            foreach (var item in _db.PostsGenericRepository.Where())
            {
                model.Add(new PostsListViewModel
                {
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

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "Uploads");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                var filePath = Path.Combine(uploadsRootFolder, model.Image.FileName);
                if (model.Image.ContentType == "image/jpeg" || model.Image.ContentType == "image/png")
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream).ConfigureAwait(false);
                    }
                }
                else
                {
                    ModelState.AddModelError("Image", "عکس را به درستی انتخاب نمایید");
                    return View(model);
                }
                var post = new Post
                {
                    CategoryId = model.CategoryId,
                    Category = _db.CategoriesGenericRepository.Where(c => c.Id == model.CategoryId).FirstOrDefault(),
                    Content = model.Content,
                    Summary = model.Summary,
                    Image = "/Uploads/" + model.Image.FileName,
                    Title = model.Title,
                    CreatedTime = DateTime.Now,
                    ViewCount = 0
                };
                _db.PostsGenericRepository.Insert(post);
                _db.Save();
                return Redirect("/Admin/Posts/Index");

            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ViewBag.Categories = _db.CategoriesGenericRepository.Where().ToList();
                var post = _db.PostsGenericRepository.Where(p => p.Id == id).FirstOrDefault();
                var editPost = new EditPostViewModel
                {
                    Id = post.Id,
                    CategoryId = post.CategoryId,
                    Content = post.Content,
                    Summary = post.Summary,
                    Title = post.Title
                };
                return View(editPost);
            }
            else
            {
                return Redirect("/Admin/Posts/Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "Uploads");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                var filePath = Path.Combine(uploadsRootFolder, model.Image.FileName);
                if (model.Image.ContentType == "image/jpeg" || model.Image.ContentType == "image/png")
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream).ConfigureAwait(false);
                    }
                }
                else
                {
                    ModelState.AddModelError("Image", "عکس را به درستی انتخاب نمایید");
                    return View(model);
                }
                var post = _db.PostsGenericRepository.Where(u => u.Id == model.Id).FirstOrDefault();
                post.Title = model.Title;
                post.Summary = model.Summary;
                post.Content = model.Content;
                post.CategoryId = model.CategoryId;
                post.Image = "/Uploads/" + model.Image.FileName;
                post.LastModifyTime = DateTime.Now;
                _db.PostsGenericRepository.Update(post);
                _db.Save();
                return Redirect("/Admin/Posts/Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}