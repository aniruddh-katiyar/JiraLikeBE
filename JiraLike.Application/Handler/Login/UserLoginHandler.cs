namespace JiraLike.Application.Handler.Login
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Exceptions;
    using JiraLike.Application.Dtos;
    using JiraLike.Application.Interfaces;
    using JiraLike.Domain.Entities;
    using JiraLike.Domain.Token;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using System.Threading;
    using System.Threading.Tasks;

    public class UserLoginHandler : IRequestHandler<LoginUserCommand, AuthResponseDto>
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IRepository<RefreshTokenEntity> _refereshTokenRepository;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly ITokenGenerator _tokenGeneratorService;
        private readonly IConfiguration _configuration;
        public UserLoginHandler(IRepository<UserEntity> repository, IPasswordHasher<UserEntity> passwordHasher,
            ITokenGenerator tokenGeneratorService,
            IRepository<RefreshTokenEntity> refereshTokenRepository,
            IConfiguration configuration)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _tokenGeneratorService = tokenGeneratorService;
            _refereshTokenRepository = refereshTokenRepository;
            _configuration = configuration;
        }
        public async Task<AuthResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.FirstOrDefaultAsync(user => user.Email == request.LoginRequestDto.Email, cancellationToken)
                 ?? throw new EntityNotFoundException<UserEntity>(request);

            var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.LoginRequestDto.Password);
            if (verifyPassword == PasswordVerificationResult.Success)
            {
                var accessToken = _tokenGeneratorService.GenerateAccessToken(request.LoginRequestDto.Email,
                    user.Role, user.Id);
                var refreshToken = _tokenGeneratorService.GenerateRefreshToken();
                var encrptedRefreshToken = _tokenGeneratorService.GenerateEncryptedRefreshToken(refreshToken);

                // 4. Hash and store refresh token in DB
                var refreshTokenEntity = new RefreshTokenEntity
                {
                    UserId = user.Id,
                    TokenHash = encrptedRefreshToken,
                    ExpiresAt = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("RefreshTokens:ExpireDays")),
                    IsRevoked = false
                };

                await _refereshTokenRepository.AddAsync(refreshTokenEntity, cancellationToken);
                await _refereshTokenRepository.SaveChangesAsync(cancellationToken);

                return new AuthResponseDto
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };
            }
            throw new Exception();
        }

    }
}
