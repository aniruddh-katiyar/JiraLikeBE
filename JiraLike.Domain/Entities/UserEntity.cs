using JiraLike.Domain.Base;
using JiraLike.Domain.Token;

namespace JiraLike.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public bool IsActive { get; set; }

        public ICollection<ProjectUserEntity> ProjectUsers { get; set; } = new List<ProjectUserEntity>();
        public ICollection<RefreshTokenEntity> RefreshTokens { get; set; } = new List<RefreshTokenEntity>();
    }
}
