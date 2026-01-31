/// <summary>
/// Command to register a new user in the system.
/// </summary>
namespace JiraLike.Application.Command.Auth
{
    using JiraLike.Application.Dto.Auth;
    using JiraLike.Application.Dto.User;
    using MediatR;

    public sealed class RegisterUserCommand : IRequest<UserResponseDto>
    {
        public RegisterUserRequestDto RegisterUser { get; }

        public RegisterUserCommand(RegisterUserRequestDto registerUser)
        {
           
            RegisterUser = registerUser ?? throw new ArgumentNullException(nameof(RegisterUser));
            RegisterUser.Email = registerUser.Email.ToLower();
        }
    }
}
