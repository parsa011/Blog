﻿using Portal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Title { get; set; }
    }
}
