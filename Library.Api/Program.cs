using Library.App.Services.Implementation;
using Library.App.Services.Interface;
using Library.App.Validations.Implementation;
using Library.App.Validations.Interface;
using Library.Domain.Db;
using Library.Domain.UnitOfWork;
using Library.Infrastructure.Command;
using Library.Infrastructure.Handlers;
using Library.Infrastructure.Queries;
using Library.Infrastructure.Repositories.Implementation;
using Library.Infrastructure.Repositories.Interface;
using Library.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddDbContextPool<AppDbContext>(c =>
    c.UseSqlServer(builder.Configuration["DefaultConnection"]));

builder.Services.AddScoped<IBookCommandRepository, BookCommandRepository>();
builder.Services.AddScoped<IAuthorCommandRepository, AuthorCommandRepository>();
builder.Services.AddScoped<IAuthorQueryRepository, AuthorQueryRepository>();
builder.Services.AddScoped<IBookQueryRepository, BookQueryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ILibraryValidation, LibraryValidation>();

builder.Services.AddMediatR(typeof(AddBookCommand).Assembly);
builder.Services.AddMediatR(typeof(AddAuthorCommand).Assembly);
builder.Services.AddMediatR(typeof(RemoveAuthorCommand).Assembly);
builder.Services.AddMediatR(typeof(RemoveBookCommand).Assembly);
builder.Services.AddMediatR(typeof(UpdateBookCommand).Assembly);
builder.Services.AddMediatR(typeof(GetBookQuery).Assembly);
builder.Services.AddMediatR(typeof(GetBooksByAuthorQuery).Assembly);

builder.Services.AddMediatR(typeof(AddBookCommandHandler).Assembly, typeof(GetBooksByAuthorQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(AddAuthorCommandHandler).Assembly, typeof(GetBookQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(RemoveAuthorCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(RemoveBookCommand).Assembly);
builder.Services.AddMediatR(typeof(UpdateBookCommandHandler).Assembly);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
