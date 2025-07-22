using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product Product, CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Product?>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
