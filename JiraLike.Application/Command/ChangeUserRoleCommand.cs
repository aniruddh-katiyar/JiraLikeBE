/// <summary>
/// Command to change a user's role in a project.
/// </summary>
namespace JiraLike.Application.Abstraction.Command
{
    using MediatR;

    public sealed class ChangeUserRoleCommand : IRequest
    {
        public Guid ProjectId { get; }
        public Guid UserId { get; }
        public Guid RoleId { get; }

        public ChangeUserRoleCommand(Guid projectId, Guid userId, Guid roleId)
        {
            ProjectId = projectId;
            UserId = userId;
            RoleId = roleId;
        }
    }
}
