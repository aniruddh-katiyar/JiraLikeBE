namespace JiraLike.Application.Dto.ActivityLog
{
    using System;

    public class ActivityLogResponseDto
    {
        public string EntityType { get; set; } = null!;
        public Guid EntityId { get; set; }
        public string Action { get; set; } = null!;
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string PerformedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }

}
