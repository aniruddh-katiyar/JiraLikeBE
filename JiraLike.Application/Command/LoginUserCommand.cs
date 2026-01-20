/// <summary>
/// Command to authenticate a user.
/// </summary>
namespace JiraLike.Application.Abstraction.Command
{
    using JiraLike.Application.Dto;
    using MediatR;

    public sealed class LoginUserCommand : IRequest<AuthResponseDto>
    {
        public LoginRequestDto Request { get; }

        public LoginUserCommand(LoginRequestDto request)
        {
            Request = request ?? throw new ArgumentNullException(nameof(request));
        }
    }
}
