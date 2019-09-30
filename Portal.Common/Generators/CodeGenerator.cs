using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Common.Generators
{
    public class CodeGenerator
    {
        public static string EmailCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 5).Replace("-","");
        }
    }
}
