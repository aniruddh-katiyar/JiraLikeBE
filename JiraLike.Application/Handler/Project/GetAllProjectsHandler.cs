namespace JiraLike.Application.Handler.Project
{
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Dto.Project;
    using JiraLike.Application.Interfaces.Repository;
    using JiraLike.Application.Resolvers;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllProjectsHandler : IRequestHandler<GetProjectsQuery, List<ProjectResponseDto>>
    {
        private readonly IProjectRepository _projectRepository;
        
        private readonly IUserInformationResolver _userInformationResolver;

        public GetAllProjectsHandler(IProjectRepository projectRepository, IUserInformationResolver userInformationResolver)
        {
            _projectRepository = projectRepository;
            _userInformationResolver = userInformationResolver;
        }

        public async Task<List<ProjectResponseDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userInformationResolver.GetUserInformation(cancellationToken);
            var projects = await _projectRepository.GetAllProjectsByUserIdAsync(user.UserId, user.UserName, cancellationToken);
            return projects;
        }
    }
}
