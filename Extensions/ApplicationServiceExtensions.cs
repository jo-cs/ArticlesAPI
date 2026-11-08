using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging.Abstractions;

using AutoMapper;
using FluentValidation;

using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Infrastructure.Security;
using ArticlesAPI.Infrastructure.Validation;

// Articles
using ArticlesAPI.Features.Articles.Repositories;
using ArticlesAPI.Features.Articles.Services;

// Categories
using ArticlesAPI.Features.Categories.Repositories;
using ArticlesAPI.Features.Categories.Services;

// Users
using ArticlesAPI.Features.Users.Models;
using ArticlesAPI.Features.Users.Repositories;
using ArticlesAPI.Features.Users.Services;
using ArticlesAPI.Features.Users.Validation;

// Auth
using ArticlesAPI.Features.Auth.Services;

// Chat
using ArticlesAPI.Features.Chat.Repositories;
using ArticlesAPI.Features.Chat.Services;

// Authors
using ArticlesAPI.Features.Authors.Repositories;
using ArticlesAPI.Features.Authors.Services;

// Media
using ArticlesAPI.Features.Media.Repositories;
using ArticlesAPI.Features.Media.Services;

// Comments
using ArticlesAPI.Features.Comments.Repositories;
using ArticlesAPI.Features.Comments.Services;

// Favourites
using ArticlesAPI.Features.Favourites.Repositories;
using ArticlesAPI.Features.Favourites.Services;

// Tags
using ArticlesAPI.Features.Tags.Repositories;
using ArticlesAPI.Features.Tags.Services;

// AuthorCategory
using ArticlesAPI.Features.AuthorCategory.Repositories;
using ArticlesAPI.Features.AuthorCategory.Services;

// AccessControl
using ArticlesAPI.Features.AccessControl.Repositories;
using ArticlesAPI.Features.AccessControl.Services;

namespace ArticlesAPI.Shared.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        // Infrastructure
        services.AddScoped<DapperContext>();

        // Articles
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IArticleService, ArticleService>();

        // Categories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();

        // Users
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        // Auth
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<JwtTokenGenerator>();

        // Password Hasher
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        // Chat
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IChatService, ChatService>();

        // Authors
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IAuthorService, AuthorService>();

        // Media
        services.AddScoped<IMediaRepository, MediaRepository>();
        services.AddScoped<IMediaService, MediaService>();

        // Comments
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ICommentService, CommentService>();

        // Favourites
        services.AddScoped<IFavouriteRepository, FavouriteRepository>();
        services.AddScoped<IFavouriteService, FavouriteService>();

        // Tags
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ITagService, TagService>();

        // AuthorCategory
        services.AddScoped<IAuthorCategoryRepository, AuthorCategoryRepository>();
        services.AddScoped<IAuthorCategoryService, AuthorCategoryService>();

        // AccessControl
        services.AddScoped<IAccessControlRepository, AccessControlRepository>();
        services.AddScoped<IAccessControlService, AccessControlService>();

        // FluentValidation
        services.AddScoped<FluentValidationActionFilter>();

        services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

        services.Configure<MvcOptions>(options =>
            options.Filters.AddService<FluentValidationActionFilter>());

        // AutoMapper
        services.AddSingleton<IMapper>(
            new MapperConfiguration(
                cfg =>
                {
                    cfg.AddMaps(typeof(UserService).Assembly);
                },
                NullLoggerFactory.Instance
            ).CreateMapper()
        );

        return services;
    }
}