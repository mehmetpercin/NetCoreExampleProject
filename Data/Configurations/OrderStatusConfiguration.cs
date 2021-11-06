using Entities.Concrete;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Data.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(x => x.OrderStatusId);
            builder.Property(x => x.OrderStatusId).IsRequired().HasConversion<int>().IsRequired();
            builder.Property(x => x.Status).IsRequired().HasMaxLength(50);
            builder.HasData(
                Enum.GetValues(typeof(OrderStatusEnum))
                    .Cast<OrderStatusEnum>()
                    .Select(e => new OrderStatus()
                    {
                        OrderStatusId = e,
                        Status = e.ToString()
                    })
            );
        }
    }
}
