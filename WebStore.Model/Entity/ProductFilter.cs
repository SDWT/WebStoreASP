﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Model.Entity
{
    public class ProductFilter
    {
        public int? SectionId { get; set; }

        public int? BrandId { get; set; }
        public IEnumerable<int> Ids { get; set; }
    }
}
