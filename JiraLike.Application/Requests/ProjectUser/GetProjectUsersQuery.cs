/// <summary>
/// Query to fetch all users in a project.
/// </summary>
namespace JiraLike.Application.Command.ProjectUser
{
    using JiraLike.Application.Dto.ProjectUser;
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
