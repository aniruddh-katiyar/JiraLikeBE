/// <summary>
/// Command to authenticate a user.
/// </summary>
namespace JiraLike.Application.Command.Auth
{
    using JiraLike.Application.Dto.Auth;
    using JiraLike.Application.Dtos.Auth;
    using MediatR;

    public sealed class LoginUserCommand : IRequest<AuthResponseDto>
    {
        public LoginRequestDto LoginRequest { get; }

        public LoginUserCommand(LoginRequestDto loginRequest)
        {
            LoginRequest = loginRequest ?? throw new ArgumentNullException(nameof(loginRequest));
            LoginRequest.Email = loginRequest.Email.ToLower();
        }
    }
}
