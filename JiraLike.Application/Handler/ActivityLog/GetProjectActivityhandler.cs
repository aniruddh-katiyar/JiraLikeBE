namespace JiraLike.Application.Handler.ActivityLog
{
    using JiraLike.Application.Command.Activitylog;
    using JiraLike.Application.Dto.ActivityLog;
    using JiraLike.Application.Interfaces;
    using JiraLike.Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetProjectActivityHandler
        : IRequestHandler<GetProjectActivityQuery, List<ActivityLogResponseDto>>
    {
        private readonly IRepository<ActivityLogEntity> _activityLogRepo;

        public GetProjectActivityHandler(
            IRepository<ActivityLogEntity> activityLogRepo)
        {
            _activityLogRepo = activityLogRepo;
        }

        public async Task<List<ActivityLogResponseDto>> Handle(
            GetProjectActivityQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _activityLogRepo.GetAllAsync(cancellationToken);

            var result = new List<ActivityLogResponseDto>();

            foreach (var x in entities)
            {
                result.Add(new ActivityLogResponseDto
                {
                    EntityType = x.EntityType,
                    EntityId = x.EntityId,
                    Action = x.Action,
                    
                    CreatedAt = x.CreatedAt
                });
            }

            return result
                .OrderByDescending(x => x.CreatedAt)
                .Take(50)
                .ToList();
        }
    }
    }

