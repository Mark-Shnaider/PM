using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PM.DAL;
using PM.DAL.Domain.Models.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<EntityContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
