using Entities.Concrete;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.Creator).IsRequired();
            builder.Property(x => x.StatusId).IsRequired().HasConversion<int>().HasDefaultValue(OrderStatusEnum.Open);
            builder.Property(x => x.TimeStamp).IsRowVersion();
        }
    }
}
