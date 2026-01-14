namespace JiraLike.Application.Handler.Users
{
    using AutoMapper;
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Dtos;
    using JiraLike.Application.Interfaces;
    using JiraLike.Domain.Entities;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllUsersHandler : IRequestHandler<GetAllUserQuery, List<GetUserResponseDto>>
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;
          private readonly ILogger<GetAllUsersHandler> _logger;
        public GetAllUsersHandler(IRepository<UserEntity> repository, IMapper mapper, ILogger<GetAllUsersHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<GetUserResponseDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync(cancellationToken);
            var result = _mapper.Map<List<GetUserResponseDto>>(users);
            _logger.LogInformation("This is handler");
            return result;

        }
    }
}
