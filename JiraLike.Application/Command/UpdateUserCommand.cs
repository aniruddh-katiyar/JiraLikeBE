/// <summary>
/// Represents a command to update a existing user.
/// </summary>
/// 
namespace JiraLike.Application.Abstraction.Command
{
    using JiraLike.Application.Dtos;
    using MediatR;
    public sealed class UpdateUserCommand : IRequest<GetUserResponseDto>
    {
        public UpdateUserRequestDto UserRequest { get; }
        public Guid UserId { get; }
        public UpdateUserCommand(UpdateUserRequestDto userRequestDto, Guid userId)
        {
            UserRequest = userRequestDto;
            UserId = userId;
        }
    }
}
