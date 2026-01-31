/// <summary>
/// Command to update user profile details.
/// </summary>
namespace JiraLike.Application.Command.Users
{
    using JiraLike.Application.Dto.User;
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
