namespace JiraLike.Api.Hubs
{
    using Microsoft.AspNetCore.SignalR;

    public class ActivityHub : Hub
    {
        public ActivityHub()
        {

        }
        public async Task JoinProject(string projectId)
        {
            await Groups.AddToGroupAsync(
                Context.ConnectionId,
                projectId
            );

        }

    }
}
