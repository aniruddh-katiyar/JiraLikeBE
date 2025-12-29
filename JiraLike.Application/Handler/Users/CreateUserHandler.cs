/// <summary>
/// Handles the creation of a new user.
/// Applies business rules and persists user data.
/// </summary>

namespace JiraLike.Application.Handler.Users
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Services;
    using JiraLike.Domain.Dtos;
    using JiraLike.Domain.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponseDto>
    {
        private readonly IRepository<UserEntity> _repository;

        private readonly IPasswordHasher<UserEntity> _passwordHasher;

        public CreateUserHandler(IRepository<UserEntity> repository, IPasswordHasher<UserEntity> passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Handles the CreateUserCommand.
        /// </summary>
        /// <param name="command">User creation command</param>
        /// <param name="cancellationToken">Request cancellation token</param>
        /// <returns>Returns created user identifier</returns>
        public async Task<UserResponseDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var userRequestDto = command.UserRequestDto
                ?? throw new ArgumentNullException(nameof(command.UserRequestDto));

            var existingUser = await _repository.FirstOrDefaultAsync(
               u => u.Email == userRequestDto.Email, cancellationToken);

            if (existingUser != null)
                throw new InvalidOperationException("User already exists");

            var user = new UserEntity
            {
                Name = userRequestDto.Name,
                Email = userRequestDto.Email,
                Role = userRequestDto.Role,
                CreatedAt = DateTime.UtcNow
            };

            // Hash password securely
            user.PasswordHash = _passwordHasher.HashPassword(user, userRequestDto.Password);

            await _repository.AddAsync(user, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return new UserResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                Message = "User Successfully Added",
                Role = user.Role,
                Success = true,
                Username = user.Name
            };
        }
    }
}