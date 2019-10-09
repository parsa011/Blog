using Portal.Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Domain.Core.Entities
{
    public class BaseEntity<T> : IBaseEntity<T>
    {
        [Key]
        public T Id { get; set; }

        [Display(Name = "تاریخ ساخت")]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "ساخته شده توسط")]
        public string CreatedBy { get; set; }
        
        [Display(Name = "اخرین تغییر")]
        public DateTime LastModifyTime { get; set; }

        [Display(Name = "اخرین تغییر توسط")]
        public string LastModifyBy { get; set; }
    }
}
