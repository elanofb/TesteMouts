namespace MoutsOrder.Domain.Specifications;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T entity);
}
