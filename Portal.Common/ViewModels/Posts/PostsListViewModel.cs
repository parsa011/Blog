using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Common.ViewModels.Posts
{
    public class PostsListViewModel
    {
        public string Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "خلاصه")]
        public string Summary { get; set; }

        [Display(Name = "عکس")]
        public string Image { get; set; }

        [Display(Name = "دسته بندی")]
        public string  Category { get; set; }
    }
}
