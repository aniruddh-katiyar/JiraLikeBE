namespace JiraLike.Application.Handler.Users
{
    using AutoMapper;
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Abstraction.Services;
    using JiraLike.Domain.Dtos;
    using JiraLike.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllUsersHandler : IRequestHandler<GetAllUserQuery, List<UserResponseDto>>
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;
        public GetAllUsersHandler(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<UserResponseDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync(cancellationToken);
            var result = _mapper.Map<List<UserResponseDto>>(users);
            //List<UserResponseDto> usersResponse = new();

            //foreach (var userEntity in users)
            //{
            //    var user = new UserResponseDto
            //    {
            //        UserId = userEntity.Id,
            //        Email = userEntity.Email,
            //        Username = userEntity.Name,
            //        CreatedAt = userEntity.CreatedAt,
            //        Role = userEntity.Role,
            //    };
            //    usersResponse.Add(user);
            //}
            return result;

        }
    }
}
