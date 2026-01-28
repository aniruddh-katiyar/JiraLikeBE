namespace JiraLike.Application.Dto
{
    using JiraLike.Domain.Enums;
    using System;
    public class IssueResponseDto
    {
        public Guid Id { get; set; }
        public string Key { get; set; } = null!;
        public IssueType Type { get; set; }
        public string Title { get; set; } = null!;
        public IssueStatus Status { get; set; } 
        public string? AssigneeName { get; set; }
    }

}
