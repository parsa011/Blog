using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Data.UOW;

namespace Portal.Web.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentsController : Controller
    {
        private readonly UnitOfWork _db;
        public CommentsController(UnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.CommentsGenericRepository.Where().ToList());
        }

        public IActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                foreach (var item in _db.CommentsGenericRepository.Where(c => c.ParentId == int.Parse(id)))
                {
                    _db.CommentsGenericRepository.Delete(int.Parse(id));
                }
                _db.CommentsGenericRepository.Delete(int.Parse(id));
                _db.Save();
                
            }
            return Redirect("/Admin/Comments/Index");
        }
    }
}