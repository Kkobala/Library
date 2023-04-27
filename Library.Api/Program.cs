using Library.App.Services.Implementation;
using Library.App.Services.Interface;
using Library.App.Validations.Implementation;
using Library.App.Validations.Interface;
using Library.Domain.Db;
using Library.Domain.UnitOfWork;
using Library.Infrastructure.Repositories.Implementation;
using Library.Infrastructure.Repositories.Interface;
using Library.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
