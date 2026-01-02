namespace JiraLike.Domain.Token
{
    using JiraLike.Domain.Entities;
    using System;

    public class RefreshTokenEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();   // internal identifier
        public Guid UserId { get; set; }                 // FK to Users table
        public string TokenHash { get; set; } = null!;          // hashed token
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set;}
        public UserEntity User { get; set; } = null!;
    }
}
