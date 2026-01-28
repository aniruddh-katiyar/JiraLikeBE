/// <summary>
/// Query to fetch all users.
/// </summary>
namespace JiraLike.Application.Command.Users
{
    using JiraLike.Application.Dto.User;
    using MediatR;
    using System.Collections.Generic;

    public sealed class GetAllUserQuery : IRequest<List<UserResponseDto>>
    {
    }
}
