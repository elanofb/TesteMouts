using MoutsOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace MoutsOrder.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        //builder.Property(u => u.Description).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Name).HasColumnName("name").IsRequired();
        //builder.Property(u => u.IsAvailable);
        builder.Property(u => u.UnitPrice).HasColumnName("unitprice");

    }
}
