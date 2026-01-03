namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Domain.Dtos;
    using MediatR;

    public class GetUserByIdQuery : IRequest<UserResponseDto>
    {
        public Guid UserId { get; set; }

        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
