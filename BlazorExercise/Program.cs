using System.Text;
using BlazorExercise.Data;
using BlazorExercise.Repositories;
using BlazorExercise.Services.Data;
using BlazorExercise.Services.User;
using BlazorExercise.Services.User.SessionToken;
using BlazorExercise.Services.User.SessionToken.Configuration;
using BlazorExercise.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceDataService, DeviceDataService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISessionTokenGenerator, SessionTokenGenerator>();
builder.Services.AddScoped<ITokenConfigurationProvider, TokenConfigurationProvider>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var tokenConfiguration = new TokenConfigurationProvider(builder.Configuration).GetConfiguration();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = tokenConfiguration.Audience,
            ValidIssuer = tokenConfiguration.Issuer,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.SecretKey))
        };
    });

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Use(async (context, next) =>
{
    context.Request.Headers.Authorization = context.Request.Cookies["JWT"];
    await next(context);
});

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello!");
app.MapGet("/secret", () => "This is a secret page").RequireAuthorization();

DataFactory.PopulateDeviceCategories(app);

app.Run();
