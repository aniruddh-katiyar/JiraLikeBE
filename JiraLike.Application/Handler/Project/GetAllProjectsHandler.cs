namespace JiraLike.Application.Handler.Project
{
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Dto;
    using JiraLike.Application.Interfaces;
    using JiraLike.Domain.Entities;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllProjectsHandler : IRequestHandler<GetProjectsQuery, List<ProjectResponseDto>>
    {
        private IRepository<ProjectEntity> _projectRepo;
        public GetAllProjectsHandler(IRepository<ProjectEntity> projectRepo)
        {
            _projectRepo = projectRepo;
        }
        public async Task<List<ProjectResponseDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepo.GetAllAsync(cancellationToken);
            var projectResponses = new List<ProjectResponseDto>();
            foreach (var project in projects)
            {
                projectResponses.Add(new ProjectResponseDto
                {
                    Id = project.Id,
                    Key = project.Key,
                    Name = project.Name,
                    Status = project.Status
                });
            }

            return projectResponses;
            }
    }
}
