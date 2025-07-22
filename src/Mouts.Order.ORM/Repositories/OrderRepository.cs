using MoutsOrder.Domain.Entities;
using MoutsOrder.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MoutsOrder.ORM.Repositories;

/// <summary>
/// Implementation of IOrderRepository using Entity Framework Core
/// </summary>
public class OrderRepository : IOrderRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of OrderRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public OrderRepository(DefaultContext context)
    {
        _context = context;
    }
    
    public async Task<Order> CreateAsync(Order order, CancellationToken cancellationToken = default)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return order;
    }
    
    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Orders.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<List<Order?>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Orders.Include(s => s.Items).ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await GetByIdAsync(id, cancellationToken);
        if (order == null)
            return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<int> CountAsync()
    {
        return await _context.Orders.CountAsync();
    }

    public async Task<List<Order>> GetPagedAsync(int page, int pageSize)
    {
        return await _context.Orders
            .OrderBy(s => s.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Guid> GetLastIdAsync(CancellationToken cancellationToken)
    {
        var lastId = await _context.Orders
            .OrderByDescending(s => s.Id)
            .Select(s => s.Id)
            .FirstOrDefaultAsync(cancellationToken);

        return lastId;
    }
}
