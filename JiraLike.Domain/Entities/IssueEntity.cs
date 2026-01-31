namespace JiraLike.Domain.Entities
{
    using JiraLike.Domain.Base;
    using JiraLike.Domain.Enums;

    public class IssueEntity : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public ProjectEntity Project { get; set; } = null!;

        public Guid? ParentIssueId { get; set; }
        public IssueEntity? ParentIssue { get; set; }

        public IssueType Type { get; set; }     // Epic, Story, Task,Subtask, Bug
        public string Key { get; set; } = null!;      // PROJ-123
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public IssueStatus Status { get; set; } 
        public IssuePriority Priority { get; set; } 

        public Guid? AssigneeId { get; set; }
        public UserEntity? Assignee { get; set; }

        public Guid ReporterId { get; set; }
        public UserEntity Reporter { get; set; } = null!;

        public string? BlockedReason { get; set; }

        public ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
    }
}
