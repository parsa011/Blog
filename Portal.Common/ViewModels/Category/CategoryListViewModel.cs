using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Common.ViewModels.Category
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        [MaxLength(20, ErrorMessage = "مقدار {0} نمی تواند بیش تر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
