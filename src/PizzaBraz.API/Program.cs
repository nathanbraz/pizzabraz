using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PizzaBraz.Infra.Context;
using System.Text;
using PizzaBraz.Infra.Interfaces;
using PizzaBraz.Infra.Repositories;
using PizzaBraz.Services.Interfaces;
using PizzaBraz.Services.Services;
using PizzaBraz.API.AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var stringConexao = builder.Configuration.GetConnectionString("PizzaBraz");

builder.Services.AddDbContext<PizzaBrazContext>(options => options.UseNpgsql(stringConexao, b => b.MigrationsAssembly("PizzaBraz.Infra")));

// ---------------------------------------------------------------- Configuração do secret key para o JWT
var secretKey = builder.Configuration["Jwt:SecretKey"];
builder.Services.AddScoped<ITokenService>(provider => new TokenService(secretKey));

// Configuração do JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true, // Verifica a expiração do token
    };
});
// ----------------------------------------------------------------

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(MapperProfile));
//builder.Services.AddAutoMapper(cfg =>
//{
//    cfg.AddProfile<MappingProfile>(); // Registra o perfil de mapeamento
//}, AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
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

