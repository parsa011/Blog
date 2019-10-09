using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Common.ViewModels;
using Portal.Data.UOW;
using Portal.Domain.Entities;
namespace Portal.Web.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly UnitOfWork _db;
        public CategoriesController(UnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.CategoriesGenericRepository.Where().ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    CreatedBy = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreatedTime = DateTime.Now,
                    Title = model.Title
                };
                _db.CategoriesGenericRepository.Insert(category);
                _db.SaveAsync();
                return RedirectToAction("categories");
            }
            else
            {
                return View(model);
            }
        }
    }
}