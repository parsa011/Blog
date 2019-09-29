using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public int ParentId { get; set; }
        public int like { get; set; }
    }
}
