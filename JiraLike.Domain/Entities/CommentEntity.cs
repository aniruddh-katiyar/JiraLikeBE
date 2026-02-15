using JiraLike.Domain.Base;

namespace JiraLike.Domain.Entities
{
    public class CommentEntity : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public ProjectEntity Project { get; set; } = null!;
        public Guid IssueId { get; set; }
        public IssueEntity Issue { get; set; } = null!;

        public Guid UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
