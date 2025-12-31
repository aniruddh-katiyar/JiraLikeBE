namespace JiraLike.Application.Handler.Login
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Exceptions;
    using JiraLike.Application.Abstraction.Services;
    using JiraLike.Application.Services;
    using JiraLike.Domain.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Threading;
    using System.Threading.Tasks;

    public class UserLoginHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly TokenGeneratorService _tokenGeneratorService;
        public UserLoginHandler(IRepository<UserEntity> repository, IPasswordHasher<UserEntity> passwordHasher,
            TokenGeneratorService tokenGeneratorService)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _tokenGeneratorService = tokenGeneratorService;
        }
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.FirstOrDefaultAsync(user => user.Email == request.LoginRequestDto.Email, cancellationToken)
                 ?? throw new EntityNotFoundException<UserEntity>(request);
            var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.LoginRequestDto.Password);
            if(verifyPassword == PasswordVerificationResult.Success)
            {
              var token =   _tokenGeneratorService.GenerateJwtToken(request.LoginRequestDto.Email, 
                  user.Role);
                return await Task.FromResult(token);
            }
            return "Invalid user";
        }
    }
}
