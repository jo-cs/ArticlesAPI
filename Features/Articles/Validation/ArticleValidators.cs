using ArticlesAPI.Features.Articles.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Articles.Validation;

public class CreateArticleValidator : AbstractValidator<CreateArticleDto>
{
    public CreateArticleValidator()
    {
        RuleFor(article => article.Name).NotEmpty();
        RuleFor(article => article.Title).NotEmpty();
        RuleFor(article => article.Details).NotEmpty();
        RuleFor(article => article.CategoryId).GreaterThan(0);
        RuleFor(article => article.AuthorId).GreaterThan(0);
    }
}

public class UpdateArticleValidator : AbstractValidator<UpdateArticleDto>
{
    public UpdateArticleValidator()
    {
        RuleFor(article => article.Name).NotEmpty();
        RuleFor(article => article.Title).NotEmpty();
        RuleFor(article => article.Details).NotEmpty();
        RuleFor(article => article.CategoryId).GreaterThan(0);
        RuleFor(article => article.AuthorId).GreaterThan(0);
    }
    
    
}
