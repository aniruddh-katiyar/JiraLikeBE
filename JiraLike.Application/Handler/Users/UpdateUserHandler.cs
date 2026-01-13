/// <summary>
/// Handles the partial update of a existing user.
/// Applies business rules and persists user data.
/// </summary>
/// 
namespace JiraLike.Application.Handler.Users
{
    using AutoMapper;
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Exceptions;
    using JiraLike.Application.Abstraction.Services;
    using JiraLike.Domain.Dtos;
    using JiraLike.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, GetUserResponseDto>
    {
        private readonly IRepository<UserEntity> _repository;

        private readonly IMapper _mapper;
        public UpdateUserHandler(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetUserResponseDto> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
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
            var result = _mapper.Map<GetUserResponseDto>(user);
            return result;
        }
    }
}
