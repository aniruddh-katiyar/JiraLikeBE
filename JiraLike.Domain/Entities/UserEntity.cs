using JiraLike.Domain.Base;
using JiraLike.Domain.Token;

namespace JiraLike.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;

        public string PasswordHash { get; private set; } = null!;
        public string Role { get; private set; } = null!;

        public ICollection<ProjectUserEntity> ProjectUsers { get; private set; } = null!;
        public ICollection<TaskItemEntity> AssignedTasks { get; private set; } = null!;
        public ICollection<CommentEntity> Comments { get; private set; } = null!;

        public ICollection<RefreshTokenEntity> RefreshTokens { get; private set; } = null!;

        public UserEntity(string name, string email, string role)
        {
            Name = name;
            Email = email;
            Role = role;

            ProjectUsers = new List<ProjectUserEntity>();
            AssignedTasks = new List<TaskItemEntity>();
            Comments = new List<CommentEntity>();
            RefreshTokens = new List<RefreshTokenEntity>();
        }

        public void SetPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
        }
        public void SetUserName(string name)
        {
            Name = name;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }
        public void SetRole(string role)
        {
            Role = role;
        }
        private UserEntity() { }

    }
}
