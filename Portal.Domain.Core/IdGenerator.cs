using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Core
{
    public class IdGenerator
    {
        public string GenerateGuid()
        {
            return Guid.NewGuid().ToString().Substring(0, 6).Replace("-", "");
        }
    }
}
