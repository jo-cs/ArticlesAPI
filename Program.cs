using ArticlesAPI.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Application Services
builder.Services.AddApplicationServices();

// Authentication
builder.Services.AddJwtAuthentication(
    builder.Configuration);

// Authorization
builder.Services.AddApplicationAuthorization();

// Swagger
builder.Services.AddSwaggerDocumentation();

// Build Application
var app = builder.Build();

// Application Pipeline
app.UseApplicationPipeline();

// Map Controllers
app.MapControllers();

app.Run();