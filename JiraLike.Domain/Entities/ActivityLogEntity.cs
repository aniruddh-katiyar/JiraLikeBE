using JiraLike.Domain.Base;

namespace JiraLike.Domain.Entities
{
    public class ActivityLogEntity : BaseEntity
    {
        public string EntityType { get; set; } = null!;
        public Guid EntityId { get; set; }
        public string Action { get; set; } = null!;

        public string OldValue { get; set; } = null!;
        public string NewValue { get; set; } = null!;

        public Guid PerformedBy { get; set; }
    }

}
