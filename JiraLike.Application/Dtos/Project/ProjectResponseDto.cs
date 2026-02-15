namespace JiraLike.Application.Dto.Project
{
    using JiraLike.Domain.Enums;

    public class ProjectResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Key { get; set; } = null!;
        public ProjectStatus Status { get; set; } 

        public Guid CreatedBy { get; set; }

        public string CreatedbyUserName { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }

}
