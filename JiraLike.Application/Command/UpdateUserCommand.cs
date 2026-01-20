/// <summary>
/// Command to update user profile details.
/// </summary>
namespace JiraLike.Application.Abstraction.Command
{
    using JiraLike.Application.Dto;
    using MediatR;

    public sealed class UpdateUserCommand : IRequest<UserResponseDto>
    {
        public Guid UserId { get; }
        public UpdateUserRequestDto Request { get; }

        public UpdateUserCommand(UpdateUserRequestDto request, Guid userId)
        {
            UserId = userId;
            Request = request ?? throw new ArgumentNullException(nameof(request));
        }
    }
}
