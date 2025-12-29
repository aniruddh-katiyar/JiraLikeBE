using JiraLike.Domain.Dtos;
using MediatR;

namespace JiraLike.Application.Abstraction.Query
{
    public class GetUserByIdQuery : IRequest<UserResponseDto>
    {
        public Guid UserId { get; set; }

        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
