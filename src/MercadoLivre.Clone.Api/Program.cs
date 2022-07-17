using FluentValidation;
using MediatR;
using MercadoLivre.Clone.Api.Extensions;
using MercadoLivre.Clone.Api.Extensions.Options;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Options;
using MercadoLivre.Clone.Business.PipelineBehaviors;
using MercadoLivre.Clone.Business.Repository;
using MercadoLivre.Clone.Business.Users;
using MercadoLivre.Clone.Business.Validations;
using MercadoLivre.Clone.Data.Repository;
using System.Reflection;

// CI: 7


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// 1
builder.Services.AddMediatR(typeof(CommandBase).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssembly(typeof(CategoryCommandValidator).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddNHibernate(builder.Configuration);

builder.Services.AddTransient<IUser, AspNetUser>();
builder.Services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.Configure<Images>(builder.Configuration.GetSection("Images"));

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

app.UseFluentValidationExceptionHandler();

app.MapControllers();

app.Run();
