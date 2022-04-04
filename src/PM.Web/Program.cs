using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PM.Application.Services.UserService.Login;
using PM.DAL;
using PM.DAL.Domain;
using PM.DAL.Domain.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PM.Application.Services;
using PM.Application.Interfaces;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<User, Role>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<EntityContext>()
    .AddSignInManager<SignInManager<User>>()
    .AddRoleManager<RoleManager<Role>>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}
);



var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super secret key"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(
        opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateAudience = false,
                ValidateIssuer = false,
            };
        });

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();



var app = builder.Build();


app.Run();
