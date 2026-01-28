/// <summary>
/// Command to deactivate (soft delete) a user.
/// </summary>
namespace JiraLike.Application.Command.Users
{
    using MediatR;

    public sealed class DeactivateUserCommand : IRequest
    {
        public Guid UserId { get; }

        public DeactivateUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
