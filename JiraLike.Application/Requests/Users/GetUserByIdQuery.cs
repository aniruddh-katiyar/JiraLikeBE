/// <summary>
/// Query to fetch a user by id.
/// </summary>
namespace JiraLike.Application.Command.Users
{
    using JiraLike.Application.Dto.User;
    using MediatR;

    public sealed class GetUserByIdQuery : IRequest<UserResponseDto>
    {
        public Guid UserId { get; }

        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
