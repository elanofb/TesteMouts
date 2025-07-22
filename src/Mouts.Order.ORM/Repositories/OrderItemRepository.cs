using MoutsOrder.Domain.Entities;
using MoutsOrder.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace MoutsOrder.ORM.Repositories;

/// <summary>
/// Implementation of IOrderItemRepository using Entity Framework Core
/// </summary>
public class OrderItemRepository : IOrderItemRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of OrderItemRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public OrderItemRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<OrderItem> CreateAsync(OrderItem orderitem, CancellationToken cancellationToken = default)
    {
        await _context.OrderItems.AddAsync(orderitem, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return orderitem;
    }
    
    public async Task<OrderItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.OrderItems.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<List<OrderItem?>> GetByOrderIdAsync(Guid orderid, CancellationToken cancellationToken = default)
    {
        return await _context.OrderItems.Where(o => o.OrderId == orderid).ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var orderitem = await GetByIdAsync(id, cancellationToken);
        if (orderitem == null)
            return false;

        _context.OrderItems.Remove(orderitem);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<OrderItem>> GetByOrderIdWithProductAsync(Guid orderId)
    {
        return await _context.OrderItems
            .Include(si => si.Product)
            .Where(si => si.OrderId == orderId)
            .ToListAsync();
    }

    public async Task<Guid> GetLastIdAsync(CancellationToken cancellationToken)
    {
        var lastId = await _context.OrderItems
            .OrderByDescending(s => s.Id)
            .Select(s => s.Id)
            .FirstOrDefaultAsync(cancellationToken);

        return lastId;
    }
}
