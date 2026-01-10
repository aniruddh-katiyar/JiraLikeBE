namespace JiraLike.Application.Handler.Users
{
    using AutoMapper;
    using JiraLike.Application.Abstraction.Exceptions;
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Abstraction.Services;
    using JiraLike.Domain.Dtos;
    using JiraLike.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserResponseDto>
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetUserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken)
                ?? throw new EntityNotFoundException<UserEntity>(request.UserId);
            var result = _mapper.Map<GetUserResponseDto>(user);
            return result;
        }
    }
}
