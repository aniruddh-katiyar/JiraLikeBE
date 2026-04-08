namespace JiraLike.Application.Interfaces
{
    using JiraLike.Application.Dtos.Ai;

    public interface IAgentService
    {
         Task<AgentResponseDto> AgentProcessingAsync(Guid id, string title, string description);
    }
}
