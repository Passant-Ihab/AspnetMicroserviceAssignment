using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Queries.GetProduct
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public string BrandName { get; set; }

        public decimal Price { get; set; }

        public decimal Rating { get; set; }
    }
}
