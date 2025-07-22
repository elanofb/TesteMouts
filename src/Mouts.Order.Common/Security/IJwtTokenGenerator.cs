namespace MoutsOrder.Common.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(IUser user);
    }
}
