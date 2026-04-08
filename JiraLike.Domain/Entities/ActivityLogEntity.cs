using JiraLike.Domain.Base;
using JiraLike.Domain.Enums;

namespace JiraLike.Domain.Entities
{
    public class ActivityLogEntity : BaseEntity
    {
        public Guid ProjectId { get; set; }

        public ProjectEntity? Project { get; set; }
        public EntityType EntityType { get; set; }    // Issue, Project, Comment
        public Guid EntityId { get; set; }

        public string Action { get; set; } = null!;       // Created, Updated, Deleted

        public string? OldValue { get; set; }             // nullable
        public string? NewValue { get; set; }             // nullable

        public Guid PerformedBy { get; set; }

        public string PerformedByName { get; set; } = null!;
    }
}
