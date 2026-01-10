namespace JiraLike.Domain.Token
{
    using JiraLike.Domain.Entities;
    using System;

    public class RefreshTokenEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();   
        public Guid UserId { get; set; }                 
        public string TokenHash { get; set; } = null!;          
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set;}
        public UserEntity User { get; set; } = null!;
    }
}
