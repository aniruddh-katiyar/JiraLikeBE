/// <summary>
/// Command to remove a user from a project.
/// </summary>
namespace JiraLike.Application.Abstraction.Command
{
    using MediatR;

    public sealed class RemoveUserFromProjectCommand : IRequest
    {
        public Guid ProjectId { get; }
        public Guid UserId { get; }

        public RemoveUserFromProjectCommand(Guid projectId, Guid userId)
        {
            ProjectId = projectId;
            UserId = userId;
        }
    }
}
