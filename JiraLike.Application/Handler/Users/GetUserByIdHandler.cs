namespace JiraLike.Application.Handler.Users
{
    using JiraLike.Application.Abstraction.Exceptions;
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Abstraction.Services;
    using JiraLike.Domain.Dtos;
    using JiraLike.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponseDto>
    {
        private readonly IRepository<UserEntity> _repository;
        public GetUserByIdHandler(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }
        public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userEntity = await _repository.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken)
                ?? throw new EntityNotFoundException<UserEntity>(request.UserId);
            var userResponse = new UserResponseDto
            {
                UserId = userEntity.Id,
                Email = userEntity.Email,
                Username = userEntity.Name,
                CreatedAt = userEntity.CreatedAt,
                Role = userEntity.Role,
            };
            return userResponse;
        }
    }
}
