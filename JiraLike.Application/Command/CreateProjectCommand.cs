/// <summary>
/// Command to create a new project.
/// </summary>
namespace JiraLike.Application.Command
{
    using JiraLike.Application.Dto;
    using MediatR;

    public sealed class CreateProjectCommand : IRequest<ProjectResponseDto>
    {
        public CreateProjectRequestDto Request { get; set; }

        public CreateProjectCommand(CreateProjectRequestDto request)
        {
            Request = request ?? throw new ArgumentNullException(nameof(request));
        }
    }
}
