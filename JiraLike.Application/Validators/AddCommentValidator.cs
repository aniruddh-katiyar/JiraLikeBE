namespace JiraLike.Application.Validators
{
    using FluentValidation;
    using JiraLike.Application.Requests.Comment;

    public class AddCommentValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentValidator()
        {
            RuleFor(x => x.CommentDto)
           .NotNull().WithMessage("Comment is required");

            RuleFor(x => x.IssueId)
                .NotEmpty().WithMessage("IssueId is required");

            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("ProjectId is required");

            RuleFor(x => x.CommentDto.Content)
                .NotEmpty().WithMessage("Content is required")
                .MaximumLength(1000).WithMessage("Content too long");
        }
    }
}
