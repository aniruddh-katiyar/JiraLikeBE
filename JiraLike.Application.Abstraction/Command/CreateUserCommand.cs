/// <summary>
/// Represents a command to create a new user.
/// </summary>

namespace JiraLike.Application.Abstraction.Command
{
    using JiraLike.Domain.Dtos;
    using MediatR;

    public sealed class CreateUserCommand : IRequest<UserResponseDto>
    {
        public UserRequestDto UserRequestDto { get; }
        public CreateUserCommand(UserRequestDto userRequestDto)
        {
            UserRequestDto = userRequestDto ?? throw new ArgumentNullException(nameof(userRequestDto));
        }
    }
}
