using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Domain.Repositories;

/// <summary>
/// Repository interface for Order entity operations
/// </summary>
public interface IOrderRepository
{
    Task<Order> CreateAsync(Order order, CancellationToken cancellationToken = default);

    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<Order?>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<int> CountAsync();
    Task<List<Order>> GetPagedAsync(int page, int pageSize);
    Task<Guid> GetLastIdAsync(CancellationToken cancellationToken);
}