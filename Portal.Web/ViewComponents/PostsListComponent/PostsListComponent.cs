using Microsoft.AspNetCore.Mvc;
using Portal.Common.ViewModels.Posts;
using Portal.Data.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Web.ViewComponents.PostsListComponent
{
    public class PostsListComponent : ViewComponent
    {
        private readonly UnitOfWork _db;
        public PostsListComponent(UnitOfWork db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<PostsListViewModel> model)
        {
            if (model== null)
            {
                model = new List<PostsListViewModel>();
                foreach (var item in _db.PostsGenericRepository.Where().ToList())
                {
                    model.Add(new PostsListViewModel {
                        CreatedTime = item.CreatedTime,
                        Id = item.Id,
                        Image = item.Image,
                        Summary = item.Summary,
                        Title = item.Title
                    });
                }
            }
            return await Task.FromResult((IViewComponentResult)
                View("PostsListComponent",model));
        }
    }
}
