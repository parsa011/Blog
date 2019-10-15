using Microsoft.AspNetCore.Mvc;
using Portal.Data.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Web.ViewComponents.NavBarComponent
{
    public class NavBarComponent : ViewComponent
    {
        private readonly UnitOfWork _db;
        public NavBarComponent(UnitOfWork db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)
                View("NavBarComponent",_db.CategoriesGenericRepository.Where().ToList()));
        }
    }
}
