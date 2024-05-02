using Product.Core.Common;

namespace Product.Core.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }


    }
}
