using Pool.Core.models;
using Pool.Core.Repositories;
using Pool.Core.Services;
using Pool.Data;
using Pool.Data.Repositories;
using Pool.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IActivityService ,ActivityService>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();

builder.Services.AddScoped<IGuideService , GuideService>();
builder.Services.AddScoped<IGuideRepository, GuideRepository>();

builder.Services.AddScoped<ISwimmerService , SwimmerService>();
builder.Services.AddScoped<ISwimmerRepository, SwimmerRepository>();



builder.Services.AddSingleton<DataContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
