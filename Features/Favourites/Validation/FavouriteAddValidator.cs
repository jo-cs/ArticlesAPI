using ArticlesAPI.Features.Favourites.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Favourites.Validation;

public class FavouriteAddValidator : AbstractValidator<FavouriteAddDto>
{
    public FavouriteAddValidator()
    {
        RuleFor(favourite => favourite.UserId).GreaterThan(0);
        RuleFor(favourite => favourite.ArticleId).GreaterThan(0);
    }
}
