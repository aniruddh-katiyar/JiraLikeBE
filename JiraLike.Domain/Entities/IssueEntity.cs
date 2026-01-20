namespace JiraLike.Domain.Entities
{
    using JiraLike.Domain.Base;

    public class IssueEntity : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public ProjectEntity Project { get; set; } = null!;

        public Guid? ParentIssueId { get; set; }
        public IssueEntity? ParentIssue { get; set; }

        public string Type { get; set; } = null!;     // Epic, Story, Task, Bug
        public string Key { get; set; } = null!;      // PROJ-123
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public string Status { get; set; } = "ToDo";
        public string Priority { get; set; } = "Medium";

        public Guid? AssigneeId { get; set; }
        public UserEntity? Assignee { get; set; }

        public Guid ReporterId { get; set; }
        public UserEntity Reporter { get; set; } = null!;

        public string? BlockedReason { get; set; }

        public ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
    }
}
