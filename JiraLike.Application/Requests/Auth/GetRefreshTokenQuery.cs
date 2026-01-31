/// <summary>
/// Query to generate a new access token using a refresh token.
/// </summary>
namespace JiraLike.Application.Command.Auth
{
    using JiraLike.Application.Dtos.Auth;
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
