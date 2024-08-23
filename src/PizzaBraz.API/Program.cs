using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PizzaBraz.Infra.Context;
using System.Text;
using PizzaBraz.Infra.Interfaces;
using PizzaBraz.Infra.Repositories;
using PizzaBraz.Services.Interfaces;
using PizzaBraz.Services.Services;
using AutoMapper;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Services.DTO;
using PizzaBraz.API.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper Configuration
var autoMapperConfig = new MapperConfiguration(conf =>
{
    conf.CreateMap<User, UserDTO>().ReverseMap();
    conf.CreateMap<UserViewModel, UserDTO>().ReverseMap();
});
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

// Dependency Injection
var stringConexao = builder.Configuration["ConnectionStrings:USER_MANAGER"];
builder.Services.AddDbContext<PizzaBrazContext>(options => options.UseNpgsql(stringConexao), ServiceLifetime.Transient);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();

// Swagger Configuration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PizzaBraz API",
        Version = "v1",
        Description = "API da Pizzaria Braz",
        Contact = new OpenApiContact
        {
            Name = "Nathan Braz",
            Email = "nathanbrz09@gmail.com",
            Url = new System.Uri("https://nathanbraz.dev")
        }
    });

    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    In = ParameterLocation.Header,
    //    Description = "Por favor, utilize o Bearer <TOKEN>",
    //    Name = "token",
    //    Type = SecuritySchemeType.ApiKey
    //});

    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            }
    //        },
    //        new string[] { }
    //    }
    //});
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaBraz.API v1"));
}

//app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

