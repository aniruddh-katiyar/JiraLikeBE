namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Domain.Dtos;
    using MediatR;

    public class GetRefreshTokenQuery : IRequest<AuthResponseDto>
    {
        public string RefreshToken { get; init; }

        public GetRefreshTokenQuery(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
