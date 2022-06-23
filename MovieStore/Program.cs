using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieStore.Business.AutoMapper;
using MovieStore.Core.CrossCuttingConcerns.Logging;
using MovieStore.Core.Extensions;
using MovieStore.DataAccess.Abstract;
using MovieStore.DataAccess.Context;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


var confiquration = builder.Configuration;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{

    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = confiquration["Token:Issuer"],
        ValidAudience = confiquration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(confiquration["Token:SecurityKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

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

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomeExeption();

app.MapControllers();

app.Run();
