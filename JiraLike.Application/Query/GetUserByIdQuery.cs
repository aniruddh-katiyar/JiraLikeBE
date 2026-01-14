namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dtos;
    using MediatR;

    public class GetUserByIdQuery : IRequest<GetUserResponseDto>
    {
        public Guid UserId { get; set; }

        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
