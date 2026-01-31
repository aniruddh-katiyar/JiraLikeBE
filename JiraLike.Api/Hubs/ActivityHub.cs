namespace JiraLike.Api.Hubs
{
    using Microsoft.AspNetCore.SignalR;

    /// <summary>
    /// 
    /// </summary>
    public class ActivityHub : Hub
    {
        /// <summary>
        /// 
        /// </summary>
        public ActivityHub()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task JoinProject(string projectId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, projectId);

        }

    }
}
