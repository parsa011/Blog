using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Common.ViewModels.Category
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
