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
                _db.Save();
                return Redirect("/Admin/Categories/Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public bool Delete(int id)
        {
            if (id != null && id != 0)
            {
                var category = _db.CategoriesGenericRepository.Where(c => c.Id == id).FirstOrDefault();
                if (category != null)
                {
                    _db.CategoriesGenericRepository.Delete(category);
                    _db.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}