/// <summary>
/// Query to fetch a high-level project summary.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using MediatR;

    public sealed class GetProjectSummaryQuery : IRequest<object>
    {
        public Guid ProjectId { get; }

        public GetProjectSummaryQuery(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
