using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Common.Generators;
using Portal.Common.ViewModels.Account;
using Portal.Data.UOW;

namespace Portal.Web.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UnitOfWork _db;
        public UsersController(UnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.UsersGenericRepository.Where().ToList());
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View(_db.UsersGenericRepository.Where(u => u.Id == id).FirstOrDefault());
            }
            else
            {
                return Redirect("/Admin/Users/Index");
            }
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var user = _db.UsersGenericRepository.Where(u => u.Id == id).FirstOrDefault();
                var useredit = new UsersEditViewModel
                {
                    ActiveCode = user.ActiveCode,
                    Email = user.Email,
                    FullName = user.FullName,
                    IsActive = user.IsActive,
                    RoleId = user.RoleId,
                    Username = user.UserName,
                    Id = user.Id
                };
                ViewBag.Roles = _db.RolesGenericRepository.Where().ToList();
                return View(useredit);
            }
            else
            {
                return Redirect("/Admin/Users/Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(UsersEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _db.UsersGenericRepository.Where(u => u.Id == model.Id).FirstOrDefault();
                user.IsActive = model.IsActive;
                user.FullName = model.FullName;
                user.UserName = model.Username;
                if (!string.IsNullOrEmpty(model.Password))
                {
                    user.PasswordHash = PasswordHash.HashWithMD5(model.Password);
                }
                user.RoleId = model.RoleId;
                user.Email = model.Email;
                user.ActiveCode = model.ActiveCode;
                user.LastModifyTime = DateTime.Now;
                _db.UsersGenericRepository.Update(user);
                _db.Save();
                return Redirect("/Admin/Users/Index");
            }
            else
            {
                ViewBag.Roles = _db.RolesGenericRepository.Where().ToList();
                return View(model);
            }
        }
    }
}