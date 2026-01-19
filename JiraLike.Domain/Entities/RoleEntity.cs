namespace JiraLike.Domain.Entities
{
    using JiraLike.Domain.Base;

    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<ProjectUserEntity> ProjectUsers { get; set; } = new List<ProjectUserEntity>();
    }
}
