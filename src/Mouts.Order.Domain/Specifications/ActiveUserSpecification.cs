using MoutsOrder.Domain.Entities;
using MoutsOrder.Domain.Enums;

namespace MoutsOrder.Domain.Specifications;

public class ActiveUserSpecification : ISpecification<User>
{
    public bool IsSatisfiedBy(User user)
    {
        return user.Status == UserStatus.Active;
    }
}
