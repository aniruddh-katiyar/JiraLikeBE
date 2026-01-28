namespace JiraLike.Application.Command.Role
{
    using JiraLike.Application.Dto.Role;
    using MediatR;

    public class AddRoleCommand : IRequest<Unit>
    {
        public RoleRequestDto RoleRequestDto { get; set; } = null!;
        public AddRoleCommand(RoleRequestDto roleRequestDto)
        {
            RoleRequestDto = roleRequestDto;
        }
    }
}
