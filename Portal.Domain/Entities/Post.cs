using Portal.Domain.Core;
using Portal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.Entities
{
    public class Post : BaseEntity<string>
    {
        public Post()
        {
            Id = IdGenerator.GenerateGuid();
        }
        public string Title { get; set; }

        [DataType(DataType.Html)]
        public string Summary { get; set; }
        [DataType(DataType.Html)]
        public string Content { get; set; }
        public string Image { get; set; }
        public int ViewCount { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual Users Writer { get; set; }
    }
}
