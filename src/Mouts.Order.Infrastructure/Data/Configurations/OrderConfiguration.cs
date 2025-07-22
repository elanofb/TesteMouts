public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
               .UseIdentityColumn(); // Configura auto-incremento

        builder.HasMany(s => s.Items)
               .WithOne()
               .HasForeignKey(si => si.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}