namespace JiraLike.Infrastructure.Repositories
{
    using JiraLike.Application.Dto.Issue;
    using JiraLike.Application.Interfaces.Repository;
    using JiraLike.Infrastructure.DbContexts;
    using Microsoft.EntityFrameworkCore;

    public class IssueRepository : IIssueRepository
    {
        private readonly JiraLikeDbContext _jiraLikeDbContext;
        public IssueRepository(JiraLikeDbContext jiraLikeDbContext)
        {
            _jiraLikeDbContext = jiraLikeDbContext;
        }

        public async Task<IReadOnlyList<IssueResponseDto>> GetIssueByProjectAsync(Guid projectId, int page, int pageSize, CancellationToken ct)
        {
            return await _jiraLikeDbContext.Issues
                .AsNoTracking()
                .Where(issue => issue.ProjectId == projectId)
                .OrderByDescending(issue => issue.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(issue => new IssueResponseDto
                {
                    Id = issue.Id,
                    Key = issue.Key,
                    Status = issue.Status,
                    Title = issue.Title,
                    Type = issue.Type
                })
                .ToListAsync(ct);
        }

        public async Task<bool> RemoveIssueAsync(Guid issueId, CancellationToken token)
        {
            var issue = await _jiraLikeDbContext.Issues.FirstOrDefaultAsync(x => x.Id == issueId, token);
            if (issue == null)
            {
                return false;
            }

            _jiraLikeDbContext.Issues.Remove(issue);
            await _jiraLikeDbContext.SaveChangesAsync(token);
            return true;
        }

        public async Task SaveIssueDiscriptionAsync(Guid issueId, string description, CancellationToken token)
        {
            var issue = await _jiraLikeDbContext.Issues.FirstOrDefaultAsync(x => x.Id == issueId, token);
            if (issue != null)
            {
                issue.Description = description;
                await _jiraLikeDbContext.SaveChangesAsync(token);
            }
        }
    }
}
