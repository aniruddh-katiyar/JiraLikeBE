/// <summary>
/// Command to add a user to a project with a role.
/// </summary>
namespace JiraLike.Application.Abstraction.Command
{
    using JiraLike.Application.Dto;
    using MediatR;

    public sealed class AddUserToProjectCommand : IRequest<ProjectUserResponseDto>
    {
        public Guid ProjectId { get; }
        public AddProjectUserRequestDto Request { get; }

        public AddUserToProjectCommand(Guid projectId, AddProjectUserRequestDto request)
        {
            ProjectId = projectId;
            Request = request ?? throw new ArgumentNullException(nameof(request));
        }
    }
}
