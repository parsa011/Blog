using Portal.Domain.Core;
using Portal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.Entities
{
    public class Users : BaseEntity<string>
    {
        public Users()
        {
            Id = IdGenerator.GenerateGuid();
        }

        [StringLength(25,ErrorMessage = "نام نمیتواند بیش از {0} کلمه باشد")]
        public string FullName { get; set; }

        [StringLength(25, ErrorMessage = "نام کاربری نمیتواند بیش از {0} کلمه باشد")]
        public string UserName { get; set; }
         
        [DataType(DataType.EmailAddress,ErrorMessage = "فرمت ایمیل درست نمیباشد")]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ActiveCode { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
