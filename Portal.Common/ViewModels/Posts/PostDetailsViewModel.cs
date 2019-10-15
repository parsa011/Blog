using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Common.ViewModels.Posts
{
    public class PostDetailsViewModel
    {
        public string Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "خلاصه")]
        [DataType(DataType.Html)]
        public string Summary { get; set; }

        [Display(Name = "عکس")]
        public string Image { get; set; }

        [Display(Name = "دسته بندی")]
        public string Category { get; set; }

        [DataType(DataType.Html)]
        [Display(Name = "محتوا")]
        public string Content { get; set; }
        [Display(Name = "تعداد بازدید")]
        public int ViewCount { get; set; }

        [Display(Name = "زمان ساخت")]
        public DateTime CreatedDate { get; set; }
    }
}
