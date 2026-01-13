
namespace JiraLike.Application.Abstraction.Command
{
    using MediatR;
    public class DeleteUserCommand : IRequest<Unit>
    {
        public Guid UserId { get; }
        public DeleteUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
