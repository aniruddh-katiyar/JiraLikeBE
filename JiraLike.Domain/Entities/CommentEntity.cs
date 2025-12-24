using JiraLike.Domain.Base;

namespace JiraLike.Domain.Entities
{
    public class CommentEntity : BaseEntity
    {
        public string Message { get; set; } = null!;

        public Guid TaskItemId { get; set; }
        public TaskItemEntity TaskItem { get; set; } = null!;

        public Guid UserId { get; set; }
        public UserEntity User { get; set; } = null!;
    }

}
