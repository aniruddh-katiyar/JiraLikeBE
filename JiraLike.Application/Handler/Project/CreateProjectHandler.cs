namespace JiraLike.Application.Handler.Project
{
    using JiraLike.Application.Command.Project;
    using JiraLike.Application.Dto.Project;
    using JiraLike.Application.Interfaces;
    using JiraLike.Application.Models.Enums;
    using JiraLike.Application.Resolvers;
    using JiraLike.Domain.Entities;
    using MediatR;
    using Microsoft.VisualBasic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ProjectResponseDto>
    {
        private readonly IRepository<ProjectEntity> _projectRepository;
        private readonly IRepository<ProjectUserEntity> _projectUserEntity;
        private readonly IRepository<RoleEntity> _roleEntity;
        private readonly IUserInformationResolver _userInformationResolver;

        public CreateProjectHandler(IRepository<ProjectEntity> projectRepository, IRepository<ProjectUserEntity> projectUserEntity,
             IRepository<RoleEntity> roleEntity,
             IUserInformationResolver userInformationResolver)
        {
            _projectRepository = projectRepository;
            _projectUserEntity = projectUserEntity;
            _roleEntity = roleEntity;
            _userInformationResolver = userInformationResolver;
        }
        public async Task<ProjectResponseDto> Handle(
        CreateProjectCommand request,
        CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var user = await _userInformationResolver.GetUserInformation(cancellationToken);
            
            var role = await _roleEntity.FirstOrDefaultAsync(x => x.Name == "Owner", cancellationToken);

            //It is fallback it removed lated :  TC
            if (role == null)
            {
               role = new RoleEntity { Id = new Guid("CFE5D9FE-B636-4726-B203-286B1836C312"), Name = "Owner" };
            }
           

            var projectEntity = new ProjectEntity
            {
                Name = request.Request.Name,
                Key = request.Request.Key,
                Status = "Active",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = user.UserId,
                Description = request.Request.ProjectDescription
                
            };

            await _projectRepository.AddAsync(projectEntity, cancellationToken);
            await _projectRepository.SaveChangesAsync(cancellationToken);
          
           
            // 2. Assign creator as OWNER
            var projectUserEntity = new ProjectUserEntity
            {
                ProjectId = projectEntity.Id,
                UserId = user.UserId,
                RoleId = role.Id, 
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _projectUserEntity.AddAsync(projectUserEntity, cancellationToken);
            await _projectUserEntity.SaveChangesAsync(cancellationToken);

            // 3. Response
            return new ProjectResponseDto
            {
                Id = projectEntity.Id,
                Name = projectEntity.Name,
                Key = projectEntity.Key,
                Status = projectEntity.Status,
                CreatedAt = projectEntity.CreatedAt,
                CreatedBy = user.UserId, 
                CreatedbyUserName = user.UserName
            };
        }

    }
}
