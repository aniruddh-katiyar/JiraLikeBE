namespace JiraLike.Application.Dtos.Ai
{
    public class AgentResponseDto
    {
        public Guid IssueId { get; set; }

        public string Priority { get; set; } = String.Empty;

        public string IssueType { get; set; } = string.Empty;
    }
}
