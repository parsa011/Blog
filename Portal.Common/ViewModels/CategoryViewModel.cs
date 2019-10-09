using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Common.ViewModels
{
    public class CategoryViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        [MaxLength(20, ErrorMessage = "مقدار {0} نمی تواند بیش تر از {1} کاراکتر باشد")]
        public string Title { get; set; }
    }
}
