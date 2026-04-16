namespace JiraLike.Application.Dtos.Comment
{
    public class CommentDto
    {
        public Guid ProjectId { get; set; }
        public Guid IssueId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
