using JiraLike.Domain.Base;

namespace JiraLike.Domain.Entities
{
    public class ProjectEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid CreatedBy { get; set; }

        public ICollection<ProjectUserEntity> ProjectUsers { get; set; } = null!;
        public ICollection<TaskItemEntity> Tasks { get; set; } = null!;
    }
}
