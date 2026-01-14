namespace JiraLike.Infrastructure.TokenGenerator
{
    using JiraLike.Application.Interfaces;
    using JiraLike.Domain.Token;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;

    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Access Token will be generated.
        public string GenerateAccessToken(string email, string role, Guid userId)
        {
            var claims = new List<Claim>
            {
              new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
              new Claim(JwtRegisteredClaimNames.Email, email),
              new Claim(ClaimTypes.Role, role),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var secretKey = _configuration.GetValue<string>("Jwt:SecretKey")
                 ?? throw new InvalidOperationException("SecretKey is missing in configuration.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Jwt:Issuer") ?? "JiraLikeApp",
                audience: _configuration.GetValue<string>("Jwt:Audience") ?? "JiraLikeUsers",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_configuration.GetValue("Jwt:ExpiryHours", 1)),
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenDescriptor);
        }


        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
        public string GenerateEncryptedRefreshToken(string refreshToken)
        {
            return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken)));
        }


        public bool VerifyRefreshToken(string incomingToken, RefreshTokenEntity refreshTokenEnity)
        {
            var incominghasedrefreshToken = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(incomingToken)));
            if (refreshTokenEnity.TokenHash == incominghasedrefreshToken && refreshTokenEnity.IsRevoked == false && refreshTokenEnity.ExpiresAt > DateTime.UtcNow)
            {
                return true;
            }
            return false;
        }
    }
}