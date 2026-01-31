/// <summary>
/// Query to fetch a project by id.
/// </summary>
namespace JiraLike.Application.Command.Project
{
    using JiraLike.Application.Dto.Project;
    using MediatR;

    public sealed class GetProjectByIdQuery : IRequest<ProjectResponseDto>
    {
        public Guid ProjectId { get; }

        public GetProjectByIdQuery(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
