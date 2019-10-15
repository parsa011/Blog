using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Common.ViewModels.Posts
{
    public class EditPostViewModel
    {
        [Display(Name = "عنوان")]
        [StringLength(35, ErrorMessage = "عنوان مطلب نمیتواند بیش از {0} کلمه باشد")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        public string Title { get; set; }

        [Display(Name = "خلاصه")]
        [StringLength(55, ErrorMessage = "خلاصه مطلب نمیتواند بیش از {0} کلمه باشد")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        [DataType(DataType.Html)]
        public string Summary { get; set; }

        [Display(Name = "محتوا")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        [DataType(DataType.Html)]
        public string Content { get; set; }

        [Display(Name = "عکس")]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        public int CategoryId { get; set; }

        public string Id { get; set; }
    }
}
