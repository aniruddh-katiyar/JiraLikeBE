namespace JiraLike.Application.Dto
{
    using System;

    public class CreateIssueRequestDto
    {
        public string Type { get; set; } = null!;   // Epic, Story, Task, Bug
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public Guid? ParentIssueId { get; set; }
    }

}
