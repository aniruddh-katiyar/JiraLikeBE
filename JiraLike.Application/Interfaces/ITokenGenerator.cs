namespace JiraLike.Application.Interfaces
{
    using JiraLike.Domain.Token;
    using System;

    public interface ITokenGenerator
    {
        string GenerateAccessToken(string email, bool IsActive, Guid userId);
        string GenerateRefreshToken();
        string GenerateEncryptedRefreshToken(string refreshToken);
        bool VerifyRefreshToken(string incomingToken, RefreshTokenEntity refreshTokenEnity);
    }
}
