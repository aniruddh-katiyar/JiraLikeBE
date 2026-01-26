using JiraLike.Domain.Base;

namespace JiraLike.Domain.Entities
{
    public class ChatHistoryEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        public Guid ProjectId { get; set; }
        public ProjectEntity Project { get; set; } = null!;

        public string Question { get; set; } = null!;
        public string? DetectedIntent { get; set; }
        public string Response { get; set; } = null!;
    }
}
