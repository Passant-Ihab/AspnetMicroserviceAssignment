﻿using Products.Core.Common;

namespace Products.Core.Entities
{
    /// <summary>
    /// Product Model class Represents the product data
    /// </summary>
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public string BrandName { get; set; }

        public decimal Price { get; set; }

        public decimal Rating { get; set; }

    }
}
