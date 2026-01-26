/// <summary>
/// Query to fetch all users.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
    using MediatR;
    using System.Collections.Generic;

    public sealed class GetAllUserQuery : IRequest<List<UserResponseDto>>
    {
    }
}
