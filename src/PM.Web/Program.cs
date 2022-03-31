using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PM.DAL;
using PM.DAL.Domain;
using PM.DAL.Domain.Models.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EntityContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();


app.UseAuthentication();
//app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

using (var scope = app.Services.CreateScope())
{
    var scopeProvider = scope.ServiceProvider;
    var unitOfWork = scopeProvider.GetRequiredService<IUnitOfWork>();
    var userManager = scopeProvider.GetRequiredService<UserManager<User>>();

    Seed.SeedDataAsync(unitOfWork, userManager).Wait();
}



app.Run();
