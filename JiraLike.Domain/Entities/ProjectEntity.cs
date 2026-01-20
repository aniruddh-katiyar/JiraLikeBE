namespace JiraLike.Domain.Entities
{
    using JiraLike.Domain.Base;

    public class ProjectEntity : BaseEntity
    {
        public string Key { get; set; } = null!;   // e.g. PROJ
        public string Name { get; set; } = null!;
        public string Status { get; set; } = "Active";

        public Guid CreatedBy { get; set; }

        public ICollection<ProjectUserEntity> ProjectUsers { get; set; } = new List<ProjectUserEntity>();
        public ICollection<IssueEntity> Issues { get; set; } = new List<IssueEntity>();
    }
}
