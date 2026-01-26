/// <summary>
/// Query to fetch all users in a project.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
    using JiraLike.Application.Dto;
    using MediatR;
    using System.Collections.Generic;

    public sealed class GetProjectUsersQuery : IRequest<List<ProjectUserResponseDto>>
    {
        public Guid ProjectId { get; }

        public GetProjectUsersQuery(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
