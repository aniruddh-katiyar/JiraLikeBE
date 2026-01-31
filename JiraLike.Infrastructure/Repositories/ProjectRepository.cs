namespace JiraLike.Infrastructure.Repositories
{
    using JiraLike.Application.Dto.Project;
    using JiraLike.Application.Interfaces.Repository;
    using JiraLike.Infrastructure.DbContexts;
    using Microsoft.EntityFrameworkCore;

    public class ProjectRepository : IProjectRepository
    {
        private readonly JiraLikeDbContext _jiraLikeDbContext;
        public ProjectRepository(JiraLikeDbContext jiraLikeDbContext)
        {
            _jiraLikeDbContext = jiraLikeDbContext;
        }

        public async Task<List<ProjectResponseDto>> GetAllProjectsByUserIdAsync(Guid userId, string userName, CancellationToken cancellationToken)
        {
            var project = await _jiraLikeDbContext.Projects.AsNoTracking().Where(project => project.CreatedBy == userId).OrderByDescending(project => project.CreatedBy).
                Select(project => new ProjectResponseDto
                {
                    Id = project.Id,
                    Key = project.Key,
                    Name = project.Name,
                    Status = project.Status,
                    CreatedAt = project.CreatedAt,
                    CreatedBy = project.CreatedBy,
                    CreatedbyUserName = userName

                }).ToListAsync();

            return project;
        }
    }
}
