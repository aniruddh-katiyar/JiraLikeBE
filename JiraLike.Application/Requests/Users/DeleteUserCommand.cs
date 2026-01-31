namespace JiraLike.Application.Command.Users
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
