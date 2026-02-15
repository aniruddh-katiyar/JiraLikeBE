namespace JiraLike.Application.Handler.Issue
{
    using JiraLike.Application.Interfaces.Repository;
    using JiraLike.Application.Requests.Issue;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class SaveIssueDiscriptionHandler : IRequestHandler<SaveIssueDiscriptionCommand, string>
    {
        private readonly IIssueRepository _issueRepository;
        public SaveIssueDiscriptionHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        public async Task<string> Handle(SaveIssueDiscriptionCommand request, CancellationToken cancellationToken)
        {
           await _issueRepository.SaveIssueDiscriptionAsync(request.IssueId, request.SaveIssueDiscriptionDto.IssueDiscription, cancellationToken);
           return request.SaveIssueDiscriptionDto.IssueDiscription;
        }
    }
}
