/// <summary>
/// Command to update project details.
/// </summary>
namespace JiraLike.Application.Command.Project
{
    using JiraLike.Application.Dto.Project;
    using MediatR;

    public sealed class UpdateProjectCommand : IRequest<ProjectResponseDto>
    {
        public Guid ProjectId { get; }
        public UpdateProjectRequestDto Request { get; }

        public UpdateProjectCommand(Guid projectId, UpdateProjectRequestDto request)
        {
            ProjectId = projectId;
            Request = request ?? throw new ArgumentNullException(nameof(request));
        }
    }
}
