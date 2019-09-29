using Portal.Domain.Core;
using Portal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
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

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
