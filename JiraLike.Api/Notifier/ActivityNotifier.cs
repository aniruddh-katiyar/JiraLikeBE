namespace JiraLike.Api.Notifier
{
    using JiraLike.Api.Hubs;
    using JiraLike.Application.Dto.ActivityLog;
    using JiraLike.Application.Interfaces;
    using Microsoft.AspNetCore.SignalR;

    /// <summary>
    /// 
    /// </summary>
    public class ActivityNotifier : IActivityNotifier
    {
        private readonly IHubContext<ActivityHub> _hub;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hub"></param>
        public ActivityNotifier(IHubContext<ActivityHub> hub)
        {
            _hub = hub;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public async Task IssueCreatedAsync(ActivityLogResponseDto activity)
        {
            await _hub.Clients.All.SendAsync("IssueCreated", activity);
        }
    }

}
