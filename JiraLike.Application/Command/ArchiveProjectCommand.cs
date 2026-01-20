/// <summary>
/// Command to archive a project.
/// </summary>
namespace JiraLike.Application.Abstraction.Command
{
    using MediatR;

    public sealed class ArchiveProjectCommand : IRequest
    {
        public Guid ProjectId { get; }

        public ArchiveProjectCommand(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
