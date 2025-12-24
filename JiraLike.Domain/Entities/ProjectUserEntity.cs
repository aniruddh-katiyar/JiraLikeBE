using JiraLike.Domain.Base;

namespace JiraLike.Domain.Entities
{
    public class ProjectUserEntity : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public ProjectEntity Project { get; set; } = null!;

        public Guid UserId { get; set; }
        public UserEntity User { get; set; } = null!;
    }
}
