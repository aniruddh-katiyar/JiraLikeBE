namespace JiraLike.Domain.Token
{
    using System;

    public class RefreshToken
    {
        public string Token { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime Expires { get; set; }
        public bool IsRevoked { get; set; }
    }
}
