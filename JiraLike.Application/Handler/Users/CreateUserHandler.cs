/// <summary>
/// Handles the creation of a new user.
/// Applies business rules and persists user data.
/// </summary>

namespace JiraLike.Application.Handler.Users
{
    using AutoMapper;
    using JiraLike.Application.Command;
    using JiraLike.Application.Dto;
    using JiraLike.Application.Interfaces;
    using JiraLike.Domain.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateUserHandler : IRequestHandler<RegisterUserCommand, AuthResponseDto>
    {
        private readonly IRepository<UserEntity> _repository;

        private readonly IPasswordHasher<UserEntity> _passwordHasher;

        private readonly IMapper _mapper;

        public CreateUserHandler(IRepository<UserEntity> repository, IPasswordHasher<UserEntity> passwordHasher, IMapper mapper)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the RegisterUserCommand.
        /// </summary>
        /// <param name="command">User creation command</param>
        /// <param name="cancellationToken">Request cancellation token</param>
        /// <returns>Returns created user identifier</returns>
        public async Task<AuthResponseDto> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var userRequestDto = command.RegisterUser
                ?? throw new ArgumentNullException(nameof(command.RegisterUser));

            var existingUser = await _repository.FirstOrDefaultAsync(
               u => u.Email == userRequestDto.Email, cancellationToken);

            if (existingUser != null)
                throw new InvalidOperationException("User already exists");

            var user = new UserEntity();
            user.Name = userRequestDto.Name;
            user.Email = userRequestDto.Email;
            var passwordHash = _passwordHasher.HashPassword(user, userRequestDto.Password);
            user.PasswordHash = passwordHash;
            await _repository.AddAsync(user, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            var response = _mapper.Map<GetUserResponseDto>(user);
            return new AuthResponseDto();
        }
    }
}