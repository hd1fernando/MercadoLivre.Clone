using FluentValidation;
using MediatR;
using MercadoLivre.Clone.Api.Extensions;
using MercadoLivre.Clone.Api.Indentity.Db;
using MercadoLivre.Clone.Api.Indentity.Entities;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.PipelineBehaviors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
// CI: 7


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 1
builder.Services.AddMediatR(typeof(CommandBase).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// 1
builder.Services.AddNHibernate(connectionString);

// 1
builder.Services.AddDbContext<IdentityUserMercadoLivreContext>(
    options => options.UseSqlServer(connectionString));

// 2
builder.Services.AddDefaultIdentity<IdentityUserEntity>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityUserMercadoLivreContext>()
    .AddDefaultTokenProviders();

// 1
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// 1
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
