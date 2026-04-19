namespace JiraLike.Application.Handler.Comment
{
    using JiraLike.Application.Interfaces;
    using JiraLike.Application.Requests.Comment;
    using JiraLike.Application.Resolvers;
    using JiraLike.Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand , bool>
    {
        private readonly IRepository<CommentEntity> _commentRepository;

        private readonly IUnitOfWork _untiOfWork;
        private readonly IReadDbContext _readDbContext;
        private readonly IUserInformationResolver _userInformationResolver;

        public DeleteCommentHandler(IRepository<CommentEntity> repository, IUnitOfWork untiOfWork, IReadDbContext readDbContext,
            IUserInformationResolver userInformationResolver)
        {
            _commentRepository = repository;
            _untiOfWork = untiOfWork;
            _readDbContext = readDbContext;
            _userInformationResolver = userInformationResolver;
        }

        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var userId = (await _userInformationResolver.GetUserInformation(cancellationToken)).UserId;
            var comment =  await _readDbContext.Comments.FirstOrDefaultAsync(x => x.Id == request.CommentId && x.UserId == userId , cancellationToken);
            if(comment != null  && comment.Id != Guid.Empty) 
            {
                await _commentRepository.DeleteAsync(comment.Id, cancellationToken);
                await _untiOfWork.SaveChangesAsync(cancellationToken);
                return true;
            }
            throw new ArgumentException("Comment is not found !");
        }
    }
}
