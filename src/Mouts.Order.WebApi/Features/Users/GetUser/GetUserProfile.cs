using AutoMapper;

using MoutsOrder.Application.Users.GetUser;

namespace MoutsOrder.WebApi.Features.Users.GetUser;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class GetUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public GetUserProfile()
    {
        CreateMap<Guid, GetUserCommand>()
            .ConstructUsing(id => new GetUserCommand(id));

        CreateMap<GetUserResult, GetUserResponse>();
    }
}
