using JiraLike.Application.Abstraction.Command;
using JiraLike.Domain.Dtos;
using MediatR;

namespace JiraLike.Application.Handler.Users
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, UserResponseDto>
    {
        public Task<UserResponseDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
