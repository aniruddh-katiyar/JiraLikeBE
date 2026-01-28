namespace JiraLike.Application.Interfaces
{
    using JiraLike.Application.Dto.ActivityLog;
    using System.Threading.Tasks;

    public interface IActivityNotifier
    {
        Task IssueCreatedAsync(ActivityLogResponseDto activity);
    }
}
