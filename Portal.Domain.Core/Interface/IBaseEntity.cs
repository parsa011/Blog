using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Core.Interface
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
        DateTime CreatedTime { get; set; }
        T CreatedBy { get; set; }
        DateTime LastModifyTime { get; set; }
        T LastModifyBy { get; set; }
    }
}
