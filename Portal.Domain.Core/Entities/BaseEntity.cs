using Portal.Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Core.Entities
{
    public class BaseEntity<T> : IBaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public T CreatedBy { get; set; }
        public DateTime LastModifyTime { get; set; }
        public T LastModifyBy { get; set; }
    }
}
