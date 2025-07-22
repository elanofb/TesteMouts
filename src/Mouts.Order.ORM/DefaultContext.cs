using MoutsOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;
         
namespace MoutsOrder.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Audit> Audits { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartProduct> CartProducts { get; set; }
    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasKey(s => s.Id);        
        modelBuilder.Entity<OrderItem>().HasKey(s => s.Id);
        modelBuilder.Entity<Product>().HasKey(s => s.Id);
        modelBuilder.Entity<Audit>().HasKey(s => s.Id);        
        modelBuilder.Entity<Log>().HasKey(s => s.Id);
        modelBuilder.Entity<Cart>().HasKey(s => s.Id);
        modelBuilder.Entity<CartProduct>().HasKey(s => s.Id);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=172.21.32.1;Port=5432;Database=developer_evaluation;Username=developer;Password=ev@luAt10n",
                b => b.MigrationsAssembly("Order.ORM"));
        }
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
               connectionString,
               b => b.MigrationsAssembly("Order.ORM")
        );

        return new DefaultContext(builder.Options);
    }
}