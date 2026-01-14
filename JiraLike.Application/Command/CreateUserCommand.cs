/// <summary>
/// Represents a command to create a new user.
/// </summary>

namespace JiraLike.Application.Abstraction.Command
{
    using JiraLike.Application.Dtos;
    using MediatR;

    public sealed class CreateUserCommand : IRequest<GetUserResponseDto>
    {
        public AddUserRequestDto UserRequestDto { get; }
        public CreateUserCommand(AddUserRequestDto userRequestDto)
        {
            UserRequestDto = userRequestDto ?? throw new ArgumentNullException(nameof(userRequestDto));
        }
    }
}
