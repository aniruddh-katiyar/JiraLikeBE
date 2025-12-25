using JiraLike.Domain.Base;

namespace JiraLike.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; }

        public ICollection<ProjectUserEntity> ProjectUsers { get; set; } = null!;
        public ICollection<TaskItemEntity> AssignedTasks { get; set; } = null!;
        public ICollection<CommentEntity> Comments { get; set; } = null!;
    }
}
