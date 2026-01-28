/// <summary>
/// Command to logout a user by revoking refresh token.
/// </summary>
namespace JiraLike.Application.Command.Auth
{
    using MediatR;

    public sealed class LogoutUserCommand : IRequest
    {
        public string RefreshToken { get; }

        public LogoutUserCommand(string refreshToken)
        {
            RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
        }
    }
}
