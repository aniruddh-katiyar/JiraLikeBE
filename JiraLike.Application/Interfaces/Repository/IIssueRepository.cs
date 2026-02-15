namespace JiraLike.Application.Interfaces.Repository
{
    using JiraLike.Application.Dto.Issue;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IIssueRepository
    {
        Task<IReadOnlyList<IssueResponseDto>> GetIssueByProjectAsync(Guid projectId, int page, int pageSize, CancellationToken ct);

        Task<bool> RemoveIssueAsync(Guid issueId, CancellationToken token);

        Task SaveIssueDiscriptionAsync(Guid issueId, string description, CancellationToken token);

    }
}
