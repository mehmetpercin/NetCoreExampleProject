using Core.Models;

namespace Entities.Concrete
{
    public class OrderDetail : DbObjectBase<int>
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsCancelled { get; set; }
    }
}
