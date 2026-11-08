using ArticlesAPI.Features.Comments.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Comments.Validation;

public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
{
    public CreateCommentValidator()
    {
        RuleFor(comment => comment.UserId).GreaterThan(0);
        RuleFor(comment => comment.ArticleId).GreaterThan(0);
        RuleFor(comment => comment.Content).NotEmpty();
    }
}

public class UpdateCommentValidator : AbstractValidator<UpdateCommentDto>
{
    public UpdateCommentValidator()
    {
        RuleFor(comment => comment.Content).NotEmpty();
    }
}
