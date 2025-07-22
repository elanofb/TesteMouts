using MoutsOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace MoutsOrder.ORM.Mapping;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(u => u.ExternalId).HasColumnName("externalid").IsRequired();
        builder.Property(u => u.Customer).HasColumnName("customer");
        builder.Property(u => u.Status).HasColumnName("status");
        builder.Property(u => u.TotalValue).HasColumnName("totalvalue");
        builder.Property(u => u.CreatedAt).HasColumnName("createdat");

        builder.Ignore(o => o.TotalValue);
    }
}
