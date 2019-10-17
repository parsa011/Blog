using Microsoft.AspNetCore.Mvc;
using Portal.Data.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Web.ViewComponents.CommentComponent
{
    public class CommentComponent : ViewComponent
    {
        private readonly UnitOfWork _db;
        public CommentComponent(UnitOfWork db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(string postId)
        {
            return await Task.FromResult((IViewComponentResult)
                View("CommentComponent", _db.CommentsGenericRepository.Where(c => c.PostId == postId).ToList()));
        }
    }
}
