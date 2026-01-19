/// <summary>
/// Command to register a new user in the system.
/// </summary>
namespace JiraLike.Application.Abstraction.Command
{
    using JiraLike.Application.Dto;
    using MediatR;

    public sealed class RegisterUserCommand : IRequest<AuthResponseDto>
    {
        public RegisterUserRequestDto Request { get; }

        public RegisterUserCommand(RegisterUserRequestDto request)
        {
            Request = request ?? throw new ArgumentNullException(nameof(request));
        }
    }
}
