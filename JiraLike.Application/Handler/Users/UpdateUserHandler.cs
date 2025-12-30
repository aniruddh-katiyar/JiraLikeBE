/// <summary>
/// Handles the partial update of a existing user.
/// Applies business rules and persists user data.
/// </summary>
/// 
namespace JiraLike.Application.Handler.Users
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Exceptions;
    using JiraLike.Application.Abstraction.Services;
    using JiraLike.Domain.Dtos;
    using JiraLike.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserResponseDto>
    {
        private readonly IRepository<UserEntity> _repository;
        public UpdateUserHandler(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }
        public async Task<UserResponseDto> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            //Fetch entity
            var user = await _repository.FirstOrDefaultAsync(u => u.Id == command.UserId,
            cancellationToken);

            if (user is null)
                throw new EntityNotFoundException<UserEntity>(command.UserId);

            //Partial Update
            if (command.UserRequest.Name is not null)
                user.Name = command.UserRequest.Name;

            if (command.UserRequest.Email is not null)
                user.Name = command.UserRequest.Email;

            if (command.UserRequest.Role is not null)
                user.Name = command.UserRequest.Role;


            // Persist changes
            await _repository.SaveChangesAsync(cancellationToken);

            // Return response
            return new UserResponseDto
            {
                UserId = user.Id,
                Username = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
