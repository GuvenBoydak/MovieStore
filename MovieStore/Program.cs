using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Business.AutoMapper;
using MovieStore.Core.CrossCuttingConcerns.Logging;
using MovieStore.Core.Extensions;
using MovieStore.DataAccess.Abstract;
using MovieStore.DataAccess.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovieStoreDb>(opt => opt.UseInMemoryDatabase(databaseName: "MovieStoreDb"));
builder.Services.AddScoped<IMovieStoreDb>(provider => provider.GetService<MovieStoreDb>());

builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomeExeption();

app.MapControllers();

app.Run();
