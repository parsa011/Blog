using Microsoft.AspNetCore.Mvc;
using Portal.Common.ViewModels.Posts;
using Portal.Data.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Web.ViewComponents.TopPostsComponent
{
    public class TopPostsComponent : ViewComponent
    {
        private readonly UnitOfWork _db;
        public TopPostsComponent(UnitOfWork db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = new List<PostsListViewModel>();
            foreach (var item in _db.PostsGenericRepository.Where().OrderByDescending(p => p.ViewCount).Take(5))
            {
                posts.Add(new PostsListViewModel
                {
                    Title = item.Title,
                    Category = item.Category.Title,
                    Id = item.Id,
                    CreatedTime = item.CreatedTime,
                    Image = item.Image,
                    Summary = item.Summary
                });
            }
            return await Task.FromResult((IViewComponentResult)
                View("TopPostsComponent", posts));
        }
    }
}