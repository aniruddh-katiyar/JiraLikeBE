namespace JiraLike.Application.Interfaces.Repository
{
    using JiraLike.Application.Dto.Project;

    public interface IProjectRepository
    {
        Task<List<ProjectResponseDto>> GetAllProjectsByUserIdAsync(Guid userId, string userName, CancellationToken cancellationToken);

    }
}
