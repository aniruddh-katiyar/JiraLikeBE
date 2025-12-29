using JiraLike.Domain.Dtos;
using MediatR;

namespace JiraLike.Application.Abstraction.Command
{
    public class UpdateUserCommand : IRequest<UserResponseDto>
    {
        public UserRequestDto UserRequest { get; set; }
        public Guid UserId { get; set; }
        public UpdateUserCommand(UserRequestDto userRequestDto, Guid userId)
        {
            UserRequest = userRequestDto;
            UserId = userId;
        }
    }
}
