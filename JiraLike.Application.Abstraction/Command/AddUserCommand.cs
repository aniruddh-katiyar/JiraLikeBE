using JiraLike.Domain.Dtos;
using MediatR;


namespace JiraLike.Application.Abstraction.Command
{
    public class AddUserCommand :IRequest<UserResponseDto>
    {
        public UserRequestDto UserRequestDto { get; set; }
        public AddUserCommand(UserRequestDto userRequestDto)
        {
            UserRequestDto = userRequestDto;
        }
    }
}
