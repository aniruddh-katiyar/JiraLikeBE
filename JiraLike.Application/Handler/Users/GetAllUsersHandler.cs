namespace JiraLike.Application.Handler.Users
{
    using AutoMapper;
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Dto;
    using JiraLike.Application.Interfaces;
    using JiraLike.Domain.Entities;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllUsersHandler : IRequestHandler<GetAllUserQuery, List<UserResponseDto>>
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
        public async Task<List<UserResponseDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync(cancellationToken);
            var result = _mapper.Map<List<UserResponseDto>>(users) ?? throw new ArgumentNullException();
            _logger.LogInformation("This is handler");
            return result;

        }
    }
}
