using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Services.Interfaces
{
    public interface ISender
    {
        Task SendAsync(string message, string to);
    }
}
