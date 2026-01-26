namespace JiraLike.Application.Command
{
    using JiraLike.Application.Dto;
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
