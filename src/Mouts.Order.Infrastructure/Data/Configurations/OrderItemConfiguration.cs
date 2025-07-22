public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(si => si.Id);
        builder.Property(si => si.Id)
               .UseIdentityColumn(); // Configura auto-incremento
    }
}