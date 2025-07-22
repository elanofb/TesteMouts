using MoutsOrder.Application.Users.CreateUser;
using MoutsOrder.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace MoutsOrder.WebApi.Mappings;

public class CreateUserRequestProfile : Profile
{
    public CreateUserRequestProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();
    }
}