using JiraLike.Domain.Base;

namespace JiraLike.Domain.Entities
{
    public class ActivityLogEntity : BaseEntity
    {
        public string EntityType { get; set; } = null!;   // Issue, Project, Comment
        public Guid EntityId { get; set; }

        public string Action { get; set; } = null!;       // Created, Updated, Deleted

        public string? OldValue { get; set; }             // nullable
        public string? NewValue { get; set; }             // nullable

        public Guid PerformedBy { get; set; }
    }
}
