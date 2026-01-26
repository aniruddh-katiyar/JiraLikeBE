namespace JiraLike.Application.Handler.Role
{
    using JiraLike.Application.Command;
    using JiraLike.Application.Interfaces;
    using JiraLike.Domain.Entities;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddRoleHandler : IRequestHandler<AddRoleCommand, Unit>
    {
        private IRepository<RoleEntity> _roleRepository;
        public AddRoleHandler(IRepository<RoleEntity> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Unit> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var roleName = request.RoleRequestDto.RoleName;
            var roleDescription = request.RoleRequestDto.RoleDescription;

            var roleEntity = new RoleEntity
            {
                Name = roleName,
                Description = roleDescription,
                CreatedAt = DateTime.UtcNow
            };

            await _roleRepository.AddAsync(roleEntity, cancellationToken);
            await _roleRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
