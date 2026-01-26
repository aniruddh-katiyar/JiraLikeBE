/// <summary>
/// Query to fetch a user by id.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
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
