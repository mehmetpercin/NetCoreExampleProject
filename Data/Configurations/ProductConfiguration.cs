using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2");
            builder.Property(x => x.Creator).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.TimeStamp).IsRowVersion();
        }
    }
}
