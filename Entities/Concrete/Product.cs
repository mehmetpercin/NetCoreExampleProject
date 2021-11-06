using Core.Models;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Product : DbObject<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
