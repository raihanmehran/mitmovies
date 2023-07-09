using API.Extensions;
using API.Middlewares;
using API.Resolvers.Queries;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;
using Infrastructure.v1.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<UserDetailQueires>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("https://localhost:4200", "http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL("/graphql");
app.MapControllers();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    await context.Database.MigrateAsync();
    Seed.ReadData(userManager: userManager, roleManager: roleManager, context: context);
}
catch (Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migrations");
}

app.Run();
