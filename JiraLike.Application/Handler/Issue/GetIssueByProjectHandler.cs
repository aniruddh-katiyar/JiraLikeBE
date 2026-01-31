namespace JiraLike.Application.Handler.Issue
{
    using AutoMapper;
    using JiraLike.Application.Command.Issue;
    using JiraLike.Application.Dto.Issue;
    using JiraLike.Application.Interfaces;
    using JiraLike.Application.Interfaces.Repository;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetIssueByProjectHandler : IRequestHandler<GetIssuesByProjectQuery, IReadOnlyList<IssueResponseDto>>
    {
        private readonly IReadDbContext _readDbContext;
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;
        public GetIssueByProjectHandler(IReadDbContext readDbContext, IMapper mapper, IIssueRepository issueRepository)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
            _issueRepository = issueRepository;
        }
        public async Task<IReadOnlyList<IssueResponseDto>> Handle(GetIssuesByProjectQuery request, CancellationToken cancellationToken)
        {
            int pageSize = 10;
            int page = 1;
            if (request == null)
            {
                return new List<IssueResponseDto>();
            }
            return await _issueRepository.GetIssueByProjectAsync(request.ProjectId, page, pageSize, cancellationToken);
        }
    }
}
