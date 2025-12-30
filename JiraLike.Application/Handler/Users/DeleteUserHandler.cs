namespace JiraLike.Application.Handler.Users
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Exceptions;
    using JiraLike.Application.Abstraction.Services;
    using JiraLike.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IRepository<UserEntity> _repository;
        public DeleteUserHandler(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _repository.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken)
                ?? throw new EntityNotFoundException<UserEntity>(request.UserId);

            await _repository.SoftDeleteAsync(userEntity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
