namespace JiraLike.Application.Handler.Ai
{
    using JiraLike.Application.Query;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using JiraLike.Application.Interfaces;

    public class ImproveProjectDiscriptionHandler : IRequestHandler<ImproveProjectDiscriptionRequestQuery, string>
    {

        private readonly ImproveDescriptionService _improveDescriptionService;
        public ImproveProjectDiscriptionHandler(ImproveDescriptionService improveDescriptionService)
        {
            _improveDescriptionService = improveDescriptionService;
        }
        public async Task<string> Handle(ImproveProjectDiscriptionRequestQuery request, CancellationToken cancellationToken)
        {
            return await _improveDescriptionService.ImproveDiscriptionAsync(request.RawDescription, cancellationToken);
        }
    }
}
