using JiraLike.Application.Abstraction.Services;
using JiraLike.Application.Handler.Users;
using JiraLike.Application.Mapper;
using JiraLike.Domain.Entities;
using JiraLike.Infrastructure.DbContexts;
using JiraLike.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "JiraLike API",
        Version = "v1"
    });
});

builder.Services.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Register AutoMapper and scan for profiles
builder.Services.AddAutoMapper(cfg =>
{
    cfg.ShouldMapMethod = _ => false;
    cfg.ShouldMapProperty = p => p.GetMethod?.IsPublic == true;
}, typeof(UserMapper));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly));
builder.Services.AddDbContext<JiraLikeDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
