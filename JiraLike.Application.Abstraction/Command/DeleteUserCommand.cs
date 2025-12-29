using MediatR;

namespace JiraLike.Application.Abstraction.Command
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public DeleteUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
