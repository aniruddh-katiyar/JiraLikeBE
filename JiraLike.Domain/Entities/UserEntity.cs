using JiraLike.Domain.Base;
using JiraLike.Domain.Token;
using System.Collections.Generic;

namespace JiraLike.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string PasswordHash { get; set; } = null!;
        public required string Role { get; set; }

        public ICollection<ProjectUserEntity> ProjectUsers { get; set; } = null!;
        public ICollection<TaskItemEntity> AssignedTasks { get; set; } = null!;
        public ICollection<CommentEntity> Comments { get; set; } = null!;

        public ICollection<RefreshTokenEntity>? RefreshTokens { get; set; } 
    }
}
