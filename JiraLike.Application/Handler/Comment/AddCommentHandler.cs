namespace JiraLike.Application.Handler.Comment
{
    using FluentValidation;
    using JiraLike.Application.Abstraction.Exceptions;
    using JiraLike.Application.Interfaces;
    using JiraLike.Application.Requests.Comment;
    using JiraLike.Application.Resolvers;
    using JiraLike.Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddCommentHandler : IRequestHandler<AddCommentCommand, Guid>
    {
        private readonly IRepository<CommentEntity> _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInformationResolver _userInformationResolver;
        private readonly IReadDbContext _readDbContext;
        private readonly IValidator<AddCommentCommand> _validator;
        public AddCommentHandler(IRepository<CommentEntity> commentRepository, IUnitOfWork unitOfWork, IUserInformationResolver userInformationResolver,
            IReadDbContext readDbContext, IValidator<AddCommentCommand> validator)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
            _userInformationResolver = userInformationResolver;
            _readDbContext = readDbContext;
            _validator = validator;
        }

        public async Task<Guid> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var result = _validator.Validate(request);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var req = request.CommentDto;

            var user = await _userInformationResolver.GetUserInformation(cancellationToken);

            if (user.UserId == Guid.Empty)
                throw new ArgumentException("User not found");

            var isIssueExists = await _readDbContext.Issues
                .AnyAsync(x => x.Id == request.IssueId, cancellationToken);

            if (!isIssueExists)
            {
                throw new EntityNotFoundException<IssueEntity>("Issue not found");
            }

            var commentEntity = new CommentEntity
            {
                UserId = user.UserId,
                IssueId = request.IssueId,
                ProjectId = request.ProjectId,
                Content = req.Content,
                CreatedAt = DateTime.UtcNow
            };

            await _commentRepository.AddAsync(commentEntity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return commentEntity.Id;
        }
    }
}
