using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Common.ViewModels.Account
{
    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        [MaxLength(20, ErrorMessage = "مقدار {0} نمی تواند بیش تر از {1} کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نمی تواند بیش تر از {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا بخاطر بسپار")]
        public bool IsRemember { get; set; }
    }
}
