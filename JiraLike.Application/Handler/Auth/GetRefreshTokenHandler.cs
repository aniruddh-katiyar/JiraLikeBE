using JiraLike.Application.Command.Auth;
using JiraLike.Application.Dtos.Auth;
using JiraLike.Application.Interfaces;
using JiraLike.Domain.Token;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

public class GetRefreshTokenHandler : IRequestHandler<GetRefreshTokenQuery, AuthResponseDto>
{

    private readonly IRepository<RefreshTokenEntity> _refreshTokenRepository;
    private readonly ITokenGenerator _tokenGeneratorService;
    private readonly IConfiguration _configuration;
    private readonly IReadDbContext _readOnlyRepository;
    public GetRefreshTokenHandler(
        IRepository<RefreshTokenEntity> refreshTokenRepository,
        ITokenGenerator tokenGeneratorService, IConfiguration configuration,
        IReadDbContext readOnlyRepository)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _tokenGeneratorService = tokenGeneratorService;
        _configuration = configuration;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task<AuthResponseDto> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        // Find refresh token entity by userId
        var encrptedSecurityToken = _tokenGeneratorService.GenerateEncryptedRefreshToken(request.RefreshToken);

        var refreshTokenEntity =
         await _readOnlyRepository.RefreshTokens.Include(rt => rt.User)
           .FirstOrDefaultAsync(rt => rt.TokenHash == encrptedSecurityToken, cancellationToken)
          ?? throw new UnauthorizedAccessException("Invalid refresh token");


        // Verify provided token
        var isValid = _tokenGeneratorService.VerifyRefreshToken(request.RefreshToken, refreshTokenEntity);
        if (!isValid)
            throw new UnauthorizedAccessException("Invalid refresh token");

        // Generate new JWT + refresh token
        var jwtToken = _tokenGeneratorService.GenerateAccessToken(refreshTokenEntity.User.Email, refreshTokenEntity.User.IsActive, refreshTokenEntity.User.Id);
        var newRefreshToken = _tokenGeneratorService.GenerateRefreshToken();
        var newEncyptedRefreshToken = _tokenGeneratorService.GenerateEncryptedRefreshToken(newRefreshToken);

        // Update DB with new refresh token hash
        var newRefreshTokenEntity = new RefreshTokenEntity
        {
            UserId = refreshTokenEntity.UserId,
            TokenHash = newEncyptedRefreshToken,
            ExpiresAt = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("RefreshTokens: ExpireDays")),
            IsRevoked = false
        };
        refreshTokenEntity.IsRevoked = true;
        await _refreshTokenRepository.AddAsync(newRefreshTokenEntity, cancellationToken);
        await _refreshTokenRepository.SaveChangesAsync(cancellationToken);


        return new AuthResponseDto
        {
            AccessToken = jwtToken,
            RefreshToken = newEncyptedRefreshToken,
            UserId = newRefreshTokenEntity.UserId
        };
    }
}

