using Core.Models;
using Entities.Enums;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Order : DbObject<int>
    {
        public OrderStatusEnum StatusId { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
