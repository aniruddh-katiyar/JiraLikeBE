namespace JiraLike.Application.Handler.Project
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Dto;
    using JiraLike.Application.Interfaces;
    using JiraLike.Domain.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Http.HttpResults;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ProjectResponseDto>
    {
        private readonly IRepository<ProjectEntity> _projectRepository;
        public CreateProjectHandler(IRepository<ProjectEntity> projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<ProjectResponseDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ProjectResponseDto();

            var projectEntity = new ProjectEntity
            {
                Name = request.Request.Name,
                Key = request.Request.Key,
                CreatedAt = DateTime.UtcNow,
                Status = "Active"
            }; 

               await _projectRepository.AddAsync(projectEntity, cancellationToken);
               await _projectRepository.SaveChangesAsync(cancellationToken);
            var projectResponseDto = new ProjectResponseDto
            {
                Id = projectEntity.Id,
                Key = request.Request.Key,
                Name = request.Request.Name,
                Status = "ACtive"
            };

            return projectResponseDto;
        }
    }
}
