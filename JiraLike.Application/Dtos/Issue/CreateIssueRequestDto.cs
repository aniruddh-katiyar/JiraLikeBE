namespace JiraLike.Application.Dto.Issue
{
    using JiraLike.Domain.Enums;
    using System;

    public class CreateIssueRequestDto
    {
        //This is title of issue.
        public string Title { get; set; } = null!;

        //This is issue Description
        public string? Description { get; set; }

        //Is issue is child then ParentIssueId will come in picture.
        public Guid? ParentIssueId { get; set; }

        //This is Issue Priority. Low | Medium | High
        public IssuePriority Priority { get; set; }
        public IssueType Type { get; set; }   // Epic, Story, Task,Subtask, Bug

        //ToDo | InProgress | CodingDone | ReadyForTest | TestDone | Closed
        public IssueStatus IssueStatus { get; set; }

        public Guid? AssigneeId { get; set; }

        public int StoryPoints { get; set; }

        public DateTime DueDate { get; set; }
        
    }

}
