using JiraLike.Domain.Base;
using JiraLike.Domain.Enums;
using TaskStatus = JiraLike.Domain.Enums.TaskStatus;


namespace JiraLike.Domain.Entities
{
    public class TaskItemEntity : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }

        public Guid ProjectId { get; set; }
        public ProjectEntity Project { get; set; } = null!;

        public Guid AssignedUserId { get; set; }
        public UserEntity AssignedUser { get; set; } = null!;

        public ICollection<CommentEntity> Comments { get; set; } = null!;
    }
}
