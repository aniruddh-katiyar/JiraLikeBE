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

    public class GetIssueByIdHandler : IRequestHandler<GetIssueByIdQuery, IssueResponseDto>
    {
        private readonly IReadDbContext _readDbContext;
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;
        public GetIssueByIdHandler(IReadDbContext readDbContext, IMapper mapper, IIssueRepository issueRepository)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
            _issueRepository = issueRepository;
        }
        public async Task<IssueResponseDto> Handle(GetIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var issueEntity = await _readDbContext.Issues.FirstOrDefaultAsync(x => x.ProjectId == request.ProjectId && x.Id == request.IssueId, cancellationToken: cancellationToken);
            var response = _mapper.Map<IssueResponseDto>(issueEntity);
            return response;
        }
    }
}
