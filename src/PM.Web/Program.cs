using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
using Microsoft.AspNetCore.Mvc.Authorization;
using PM.Web.Middleware;
using Microsoft.Extensions.DependencyInjection;
using PM.Application.Services.WorkerService.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EntityContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(typeof(LoginHandler).Assembly);
builder.Services.AddMediatR(typeof(WorkerQueryHandlers).Assembly);

builder.Services.AddMvc(option =>
{
    option.EnableEndpointRouting = false;
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    option.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddControllers();

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<EntityContext>()
    .AddSignInManager<SignInManager<User>>();

//builder.Services.AddIdentity<User, Role>()
//    .AddRoles<Role>()
//    .AddEntityFrameworkStores<EntityContext>()
//    .AddSignInManager<SignInManager<User>>()
//    .AddRoleManager<RoleManager<Role>>()
//    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}
);

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtTokenKey"]));
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

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

using (var scope = app.Services.CreateScope())
{
    var scopeProvider = scope.ServiceProvider;
    var unitOfWork = scopeProvider.GetRequiredService<IUnitOfWork>();
    var userManager = scopeProvider.GetRequiredService<UserManager<User>>();

    Seed.SeedDataAsync(unitOfWork, userManager).Wait();
}

app.Run();
