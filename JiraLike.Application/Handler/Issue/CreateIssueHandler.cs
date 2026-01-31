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
        /// 
        /// </summary>
        /// <param name="activityNotifier"></param>
        public CreateIssueHandler(ISignalRActivityNotifier activityNotifier, IRepository<IssueEntity> issueRepository,
            IRepository<ActivityLogEntity> activityLogEntity, IUserInformationResolver userInformationResolver)
        {
            _activityNotifier = activityNotifier;
            _issueRepository = issueRepository;
            _activityLogEntity = activityLogEntity;
            _userInformationResolver = userInformationResolver;
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
                Status = Domain.Enums.IssueStatus.ToDo,
                Description = request.Request.Description,
                Key = "",

                Priority = request.Request.Priority,
                ProjectId = request.ProjectId,
                

            };

            await _issueRepository.AddAsync(issueEntity, cancellationToken);

            await _issueRepository.SaveChangesAsync(cancellationToken);

            var activity = new ActivityLogEntity
            {
                EntityType = request.Request.Type.ToString(),
                EntityId = issueEntity.Id,
                Action = $"Issue {issueEntity.Title} created",
                CreatedAt = DateTime.UtcNow,
                PerformedBy = user.UserId
            };
            await _activityLogEntity.AddAsync(activity, cancellationToken);
            await _activityLogEntity.SaveChangesAsync(cancellationToken);

            var activitydto = new ActivityLogResponseDto
            {
                EntityType = request.Request.Type.ToString(),
                EntityId = issueEntity.Id,
                Action = $"Issue {issueEntity.Title} created",
                CreatedAt = DateTime.UtcNow,
                PerformedBy = user.UserName
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
