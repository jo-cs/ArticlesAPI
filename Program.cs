
using System.Security.Claims;
using System.Text;
using ArticlesAPI.Features.Articles.Repositories;
using AutoMapper;
using ArticlesAPI.Features.Auth.Services;
using ArticlesAPI.Features.Chat.Repositories;
using ArticlesAPI.Features.Chat.Services;
using ArticlesAPI.Features.Users.Models;
using ArticlesAPI.Features.Users.Repositories;
using ArticlesAPI.Features.Users.Services;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging.Abstractions;
using ArticlesAPI.Features.Articles.Services;
using ArticlesAPI.Features.Categories.Repositories;
using ArticlesAPI.Features.Categories.Services;
using ArticlesAPI.Features.AccessControl.Repositories;
using ArticlesAPI.Features.AccessControl.Services;
using ArticlesAPI.Features.Authors.Repositories;
using ArticlesAPI.Features.Authors.Services;

using ArticlesAPI.Features.Media.Repositories;
using ArticlesAPI.Features.Media.Services;

using ArticlesAPI.Features.Comments.Repositories;
using ArticlesAPI.Features.Comments.Services;

using ArticlesAPI.Features.Favourites.Repositories;
using ArticlesAPI.Features.Favourites.Services;

using ArticlesAPI.Features.Tags.Repositories;
using ArticlesAPI.Features.Tags.Services;

using ArticlesAPI.Features.AuthorCategory.Repositories;
using ArticlesAPI.Features.AuthorCategory.Services;

using ArticlesAPI.Features.AccessControl.Repositories;
using ArticlesAPI.Features.AccessControl.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers and OpenAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Swagger with JWT Bearer authentication
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",
        new Microsoft.OpenApi.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = Microsoft.OpenApi.SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = Microsoft.OpenApi.ParameterLocation.Header,
            Description = "Enter your JWT token"
        });

    options.AddSecurityRequirement(document =>
        new Microsoft.OpenApi.OpenApiSecurityRequirement
        {
            [
                new Microsoft.OpenApi.OpenApiSecuritySchemeReference(
                    "Bearer", document)
            ] = []
        });
});

// Database
builder.Services.AddScoped<DapperContext>();

// Chat
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IChatService, ChatService>();

// Users
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Authentication services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<JwtTokenGenerator>();

// Password hasher
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// JWT configuration
var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("JWT Key is missing.");

var jwtIssuer = builder.Configuration["Jwt:Issuer"]
    ?? throw new InvalidOperationException("JWT Issuer is missing.");

var jwtAudience = builder.Configuration["Jwt:Audience"]
    ?? throw new InvalidOperationException("JWT Audience is missing.");

// Authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,

            ValidateAudience = true,
            ValidAudience = jwtAudience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30),

            RoleClaimType = ClaimTypes.Role,
            NameClaimType = ClaimTypes.Name
        };
    });

// ADDED: تعريف Policies للتحقق من صلاحيات المستخدم
builder.Services.AddAuthorization(options =>
{
    // ADDED: السماح بإنشاء المقال لمن يمتلك Articles.Create
    options.AddPolicy("Articles.Create",
        policy => policy.RequireClaim(
            "permission", "Articles.Create"));

    // ADDED: السماح بقراءة المقالات لمن يمتلك Articles.Read
    options.AddPolicy("Articles.Read",
        policy => policy.RequireClaim(
            "permission", "Articles.Read"));

    // ADDED: السماح بتعديل المقال لمن يمتلك Articles.Update
    options.AddPolicy("Articles.Update",
        policy => policy.RequireClaim(
            "permission", "Articles.Update"));

    // ADDED: السماح بحذف المقال لمن يمتلك Articles.Delete
    options.AddPolicy("Articles.Delete",
        policy => policy.RequireClaim(
            "permission", "Articles.Delete"));

    // ADDED: السماح بإنشاء التصنيف لمن يمتلك Categories.Create
    options.AddPolicy("Categories.Create",
        policy => policy.RequireClaim(
            "permission", "Categories.Create"));

    // ADDED: السماح بتعديل التصنيف لمن يمتلك Categories.Update
    options.AddPolicy("Categories.Update",
        policy => policy.RequireClaim(
            "permission", "Categories.Update"));

    // ADDED: السماح بحذف التصنيف لمن يمتلك Categories.Delete
    options.AddPolicy("Categories.Delete",
        policy => policy.RequireClaim(
            "permission", "Categories.Delete"));
});

// AutoMapper
builder.Services.AddSingleton<IMapper>(
    new MapperConfiguration(
        cfg =>
        {
            cfg.AddMaps(typeof(UserService).Assembly);
        },
        NullLoggerFactory.Instance
    ).CreateMapper()
);

builder.Services.AddScoped<IArticleRepository,ArticleRepository>();
builder.Services.AddScoped<IArticleService, ArticleService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Authors
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

// Media
builder.Services.AddScoped<IMediaRepository, MediaRepository>();
builder.Services.AddScoped<IMediaService, MediaService>();

// Comments
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();

// Favourites
builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();
builder.Services.AddScoped<IFavouriteService, FavouriteService>();

// Tags
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITagService, TagService>();

// AuthorCategory
builder.Services.AddScoped<IAuthorCategoryRepository, AuthorCategoryRepository>();
builder.Services.AddScoped<IAuthorCategoryService, AuthorCategoryService>();

// AccessControl
builder.Services.AddScoped<IAccessControlRepository, AccessControlRepository>();
builder.Services.AddScoped<IAccessControlService, AccessControlService>();

// Build application
var app = builder.Build();

// HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
