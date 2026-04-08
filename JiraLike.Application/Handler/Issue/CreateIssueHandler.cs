//--
//Create issue Handler
//--
namespace JiraLike.Application.Handler.Issue
{
    using JiraLike.Application.Command.Issue;
    using JiraLike.Application.Dto.ActivityLog;
    using JiraLike.Application.Dto.Issue;
    using JiraLike.Application.Interfaces;
    using JiraLike.Application.Resolvers;
    using JiraLike.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateIssueHandler : IRequestHandler<CreateIssueCommand, IssueResponseDto>
    {
        public IRepository<IssueEntity> _issueRepository;
        private readonly ISignalRActivityNotifier _activityNotifier;
        public IRepository<ActivityLogEntity> _activityLogEntity;
        private IUserInformationResolver _userInformationResolver;
       // private IAgentService _agentService;
        /// 
        /// </summary>
        /// <param name="activityNotifier"></param>
        public CreateIssueHandler(ISignalRActivityNotifier activityNotifier, IRepository<IssueEntity> issueRepository,
            IRepository<ActivityLogEntity> activityLogEntity, IUserInformationResolver userInformationResolver
           )
        {
            _activityNotifier = activityNotifier;
            _issueRepository = issueRepository;
            _activityLogEntity = activityLogEntity;
            _userInformationResolver = userInformationResolver;
          //  _agentService = agentService;
        }
        public async Task<IssueResponseDto> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var user = await _userInformationResolver.GetUserInformation(cancellationToken);

            var issueEntity = new IssueEntity
            {
                Title = request.Request.Title,
                Type = request.Request.Type,
                CreatedAt = DateTime.UtcNow,
                ReporterId = user.UserId,
                Status = request.Request.IssueStatus,
                Priority = request.Request.Priority,
                Description = request.Request.Description,
                Key = "",
                ProjectId = request.ProjectId,
            };

            await _issueRepository.AddAsync(issueEntity, cancellationToken);
            await _issueRepository.SaveChangesAsync(cancellationToken);
            var activity = new ActivityLogEntity
            {
                ProjectId = request.ProjectId,
                EntityType = Domain.Enums.EntityType.Issue,
                EntityId = issueEntity.Id,
                Action = $"Issue {issueEntity.Title} created",
                CreatedAt = DateTime.UtcNow,
                PerformedBy = user.UserId,
                PerformedByName = user.UserName,
            };
            await _activityLogEntity.AddAsync(activity, cancellationToken);
            await _activityLogEntity.SaveChangesAsync(cancellationToken);

            //Add Ai Service here  
            //var updateResponseFromAgent = await _agentService.AgentProcessingAsync(issueEntity.Id, issueEntity.Title, issueEntity.Description ?? "");
            //if (Enum.TryParse<IssueType>(updateResponseFromAgent.IssueType, true, out var type))
            //{
            //    issueEntity.Type = type;
            //}

            //if (Enum.TryParse<IssuePriority>(updateResponseFromAgent.Priority, true, out var priority))
            //    {
            //    issueEntity.Priority = priority;
            //    }
            await _issueRepository.SaveChangesAsync(cancellationToken);
            var activitydto = new ActivityLogResponseDto
            {
                EntityType = activity.EntityType,
                EntityId = issueEntity.Id,
                Action = $"Issue '{issueEntity.Title}' created.",
                CreatedAt = DateTime.UtcNow,
                PerformByName = user.UserName,
                PerformedBy = user.UserId
            };
            await _activityNotifier.IssueCreatedAsync(activitydto);
            return new IssueResponseDto
            {
                Title = issueEntity.Title,
                Status = issueEntity.Status,
                Type = issueEntity.Type,
                AssigneeName = user.UserName,
                Id = issueEntity.Id
            };


        }
    }
}
