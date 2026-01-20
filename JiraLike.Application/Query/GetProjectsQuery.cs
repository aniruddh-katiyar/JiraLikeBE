/// <summary>
/// Query to fetch all projects accessible to the user.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
    using MediatR;
    using System.Collections.Generic;

    public sealed class GetProjectsQuery : IRequest<List<ProjectResponseDto>>
    {
    }
}
