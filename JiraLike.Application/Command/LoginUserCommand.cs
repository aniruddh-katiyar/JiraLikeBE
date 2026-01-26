/// <summary>
/// Command to authenticate a user.
/// </summary>
namespace JiraLike.Application.Command
{
    using JiraLike.Application.Dto;
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
