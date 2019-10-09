using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Core.Interface
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
        DateTime CreatedTime { get; set; }
        string CreatedBy { get; set; }
        DateTime LastModifyTime { get; set; }
        string LastModifyBy { get; set; }
    }
}
