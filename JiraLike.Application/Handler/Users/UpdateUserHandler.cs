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
    using JiraLike.Application.Dto;
    using JiraLike.Application.Interfaces;
    using JiraLike.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserResponseDto>
    {
        private readonly IRepository<UserEntity> _repository;

        private readonly IMapper _mapper;
        public UpdateUserHandler(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserResponseDto> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            //Fetch entity
            var user = await _repository.FirstOrDefaultAsync(u => u.Id == command.UserId,
            cancellationToken);

            if (user is null)
                throw new EntityNotFoundException<UserEntity>(command.UserId);

            ////Partial Update
            //if (command.UserRequest.Name is not null)
            //    user.ChangeUserName(command.UserRequest.Name);

            //if (command.UserRequest.Email is not null)
            //    user.ChangeEmail(command.UserRequest.Email);

            //if (command.UserRequest.Role is not null)
            //    user.ChangeRole(command.UserRequest.Role);


            // Persist changes
            await _repository.SaveChangesAsync(cancellationToken);

            // Return response
            var result = _mapper.Map<GetUserResponseDto>(user);
            return new UserResponseDto();
        }
    }
}
