namespace JiraLike.Domain.Entities
{
    using JiraLike.Domain.Base;
    using JiraLike.Domain.Enums;

    public class ProjectEntity : BaseEntity
    {
        public string Key { get; set; } = null!;   // e.g. PROJ
        public string Name { get; set; } = null!;
        public ProjectStatus Status { get; set; }

        public string Description { get; set; } = null!;
        public Guid CreatedBy { get; set; }

        public ICollection<ProjectUserEntity> ProjectUsers { get; set; } = new List<ProjectUserEntity>();
        public ICollection<IssueEntity> Issues { get; set; } = new List<IssueEntity>();
        public ICollection<ActivityLogEntity> ActivityLogs { get; set; } = new List<ActivityLogEntity>();
        public ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
    }
}
