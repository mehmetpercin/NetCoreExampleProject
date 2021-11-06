using Core.Models;
using Entities.Enums;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class OrderStatus : ITable
    {
        public OrderStatusEnum OrderStatusId { get; set; }
        public string Status { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
