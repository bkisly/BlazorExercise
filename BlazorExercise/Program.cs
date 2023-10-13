using BlazorExercise.Data;
using BlazorExercise.Repositories;
using BlazorExercise.Services.Data;
using BlazorExercise.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceDataService, DeviceDataService>();

var app = builder.Build();

app.MapDefaultControllerRoute();

DataFactory.PopulateDeviceCategories(app);

app.Run();
