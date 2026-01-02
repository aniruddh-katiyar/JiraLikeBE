using JiraLike.Application.Abstraction.Query;
using JiraLike.Application.Abstraction.Services;
using JiraLike.Application.Services;
using JiraLike.Domain.Dtos;
using JiraLike.Domain.Token;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetRefreshTokenHandler : IRequestHandler<GetRefreshTokenQuery, AuthResponseDto>
{
    private readonly IRepository<RefreshTokenEntity> _refreshTokenRepository;
    private readonly ITokenGeneratorService _tokenGeneratorService;

    public GetRefreshTokenHandler(
        IRepository<RefreshTokenEntity> refreshTokenRepository,
        ITokenGeneratorService tokenGeneratorService)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _tokenGeneratorService = tokenGeneratorService;
    }

    public async Task<AuthResponseDto> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        // Find refresh token entity by userId
        var encrptedSecurityToken = _tokenGeneratorService.GenerateEncryptedRefreshToken(request.RefreshToken);
        var refreshTokenEntity = await _refreshTokenRepository.Query().Include(rt => rt.User)
             .FirstOrDefaultAsync(rt => rt.TokenHash == encrptedSecurityToken, cancellationToken)
             ?? throw new UnauthorizedAccessException("Invalid refresh token");

        // Verify provided token
        var isValid = _tokenGeneratorService.VerifyRefreshToken(request.RefreshToken, refreshTokenEntity);
        if (!isValid)
            throw new UnauthorizedAccessException("Invalid refresh token");

        // Generate new JWT + refresh token
        var jwtToken = _tokenGeneratorService.GenerateAccessToken(refreshTokenEntity.User.Email, refreshTokenEntity.User.Role, refreshTokenEntity.User.Id);
        var newRefreshToken = _tokenGeneratorService.GenerateRefreshToken();
        var newEncyptedRefreshToke = _tokenGeneratorService.GenerateEncryptedRefreshToken(newRefreshToken);

        // Update DB with new refresh token hash
        var newRefreshTokenEntity = new RefreshTokenEntity
        {
            UserId = refreshTokenEntity.UserId,
            TokenHash = newEncyptedRefreshToke,
            ExpiresAt = DateTime.UtcNow.AddDays(7), // configurable lifetime
            IsRevoked = false
        };
        refreshTokenEntity.IsRevoked = true;
        await _refreshTokenRepository.AddAsync(newRefreshTokenEntity, cancellationToken);
        await _refreshTokenRepository.SaveChangesAsync(cancellationToken);

        // Return response DTO
        return new AuthResponseDto
        {
            AccessToken = jwtToken,
            RefreshToken = newRefreshToken
        };
    }
}

