/// <summary>
/// Command to deactivate (soft delete) a user.
/// </summary>
namespace JiraLike.Application.Abstraction.Command
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
