using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Domain.Repositories;

/// <summary>
/// Repository interface for OrderItem entity operations
/// </summary>
public interface IOrderItemRepository
{
    Task<OrderItem> CreateAsync(OrderItem orderitem, CancellationToken cancellationToken = default);
    Task<OrderItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<OrderItem?>> GetByOrderIdAsync(Guid orderid, CancellationToken cancellationToken = default);
    Task<List<OrderItem>> GetByOrderIdWithProductAsync(Guid orderId);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> GetLastIdAsync(CancellationToken cancellationToken);
}
