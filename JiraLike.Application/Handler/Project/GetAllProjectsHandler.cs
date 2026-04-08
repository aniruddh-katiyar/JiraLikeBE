namespace JiraLike.Application.Handler.Project
{
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Dto.Project;
    using JiraLike.Application.Interfaces;
    using JiraLike.Application.Resolvers;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllProjectsHandler : IRequestHandler<GetProjectsQuery, List<ProjectResponseDto>>
    {
        private readonly IReadDbContext _readDbContext;

        private readonly IUserInformationResolver _userInformationResolver;

        public GetAllProjectsHandler(IReadDbContext readDbContext, IUserInformationResolver userInformationResolver)
        {
            _readDbContext = readDbContext;
            _userInformationResolver = userInformationResolver;
        }

        public async Task<List<ProjectResponseDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userInformationResolver.GetUserInformation(cancellationToken);
            var projects = await _readDbContext.Projects.Include(x => x.ProjectUsers).Select(
                x => new ProjectResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Key = x.Key,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                    CreatedBy = x.CreatedBy,
                    CreatedbyUserName = x.ProjectUsers.Where(y => y.UserId == x.CreatedBy).Select(y => y.User.Name).FirstOrDefault() ?? string.Empty
                }).ToListAsync(cancellationToken);

            return projects;
        }

    }
}

