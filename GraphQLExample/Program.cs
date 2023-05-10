using GraphQL.Types;
using GraphQL;
using GraphQLExample.Data;
using GraphQLExample.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("SqLiteConnection");
builder.Services.AddDbContext<DB>(options => options.UseSqlite(connectionString),contextLifetime:ServiceLifetime.Singleton,optionsLifetime:ServiceLifetime.Singleton);

//builder.Services.AddSingleton<DB>();
builder.Services.AddSingleton<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
builder.Services.AddSingleton<ProductType>();
builder.Services.AddSingleton<BrandType>();
builder.Services.AddSingleton<ISchema, ProductSchema>();
builder.Services.AddSingleton<ProductQuery>();

builder.Services.AddControllers();
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
