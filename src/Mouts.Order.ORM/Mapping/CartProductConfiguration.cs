using MoutsOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoutsOrder.ORM.Mapping
{
    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
        }
    }
}
