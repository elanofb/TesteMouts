using MoutsOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace MoutsOrder.ORM.Mapping;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("orderitems");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(u => u.OrderId).HasColumnName("orderid").IsRequired();
        builder.Property(u => u.ProductId).HasColumnName("productid").IsRequired();
        builder.Property(u => u.Quantity).HasColumnName("quantity");
        builder.Property(u => u.Price).HasColumnName("price").IsRequired();
    }
}
