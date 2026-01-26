/// <summary>
/// Query to generate a new access token using a refresh token.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
    using MediatR;

    public sealed class GetRefreshTokenQuery : IRequest<AuthResponseDto>
    {
        public string RefreshToken { get; }

        public GetRefreshTokenQuery(string refreshToken)
        {
            RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
        }
    }
}
