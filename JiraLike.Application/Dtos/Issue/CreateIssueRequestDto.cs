namespace JiraLike.Application.Dto.Issue
{
    using JiraLike.Domain.Enums;
    using System;

    public class CreateIssueRequestDto
    {
        public IssueType Type { get; set; }   // Epic, Story, Task, Bug
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public Guid? ParentIssueId { get; set; }
        public IssuePriority Priority { get; set; }

        public Guid? AssigneeId { get; set; }
        
    }

}
