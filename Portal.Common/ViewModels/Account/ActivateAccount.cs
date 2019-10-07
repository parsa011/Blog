using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Common.ViewModels.Account
{
    public class ActivateAccount
    {
        [Display(Name = "کد فعالسازی")]
        [MaxLength(6, ErrorMessage = "مقدار {0} نمی تواند بیش تر از {1} کاراکتر باشد")]
        public string Code { get; set; }
    }
}
