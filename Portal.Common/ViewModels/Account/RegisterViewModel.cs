using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Common.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        [MaxLength(20, ErrorMessage = "مقدار {0} نمی تواند بیش تر از {1} کاراکتر باشد")]
        public string Username { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        [MaxLength(20, ErrorMessage = "مقدار {0} نمی تواند بیش تر از {1} کاراکتر باشد")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نمی تواند بیش تر از {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نمی تواند بیش تر از {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        [Compare("Password", ErrorMessage = "کلمه های عبور با یکدیگر همخوانی ندارند")]
        public string ConfirmPassword { get; set; }
    }
}
