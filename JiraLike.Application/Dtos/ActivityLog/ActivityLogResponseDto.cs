namespace JiraLike.Application.Dto.ActivityLog
{
    using JiraLike.Domain.Enums;
    using System;

    public class ActivityLogResponseDto
    {
        public EntityType EntityType { get; set; } 
        public Guid EntityId { get; set; }
        public string Action { get; set; } = null!;
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public Guid PerformedBy { get; set; } 
        public DateTime CreatedAt { get; set; }

        public string PerformByName { get; set; } = null!;
    }

}
