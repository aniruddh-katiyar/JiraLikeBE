namespace JiraLike.Application.Handler.Issue
{
    using JiraLike.Application.Interfaces.Repository;
    using JiraLike.Application.Requests.Issue;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveIssueByIssueIdHandler : IRequestHandler<RemoveIssueCommand, bool>
    {
        private readonly IIssueRepository _issueRepository;
        public RemoveIssueByIssueIdHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        public async Task<bool> Handle(RemoveIssueCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return false;
            }
            return await _issueRepository.RemoveIssueAsync(request.IssueId, cancellationToken);
        }
    }
}
