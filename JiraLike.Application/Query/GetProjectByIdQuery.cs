/// <summary>
/// Query to fetch a project by id.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
    using JiraLike.Application.Dto;
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
