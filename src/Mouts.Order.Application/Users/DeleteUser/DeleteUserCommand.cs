using MediatR;

namespace MoutsOrder.Application.Users.DeleteUser;

/// <summary>
/// Command for deleting a user
/// </summary>
public record DeleteUserCommand : IRequest<DeleteUserResponse>
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteUserCommand
    /// </summary>
    /// <param name="id">The ID of the user to delete</param>
    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}
