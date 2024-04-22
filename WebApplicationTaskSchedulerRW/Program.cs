using Quartz;
using Quartz.Impl;
using TaskSchedulerBusinessRW.Interface;
using TaskSchedulerBusinessRW.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISchedulerFactory, StdSchedulerFactory>();
builder.Services.AddScoped<ITaskSchedulerService, TaskSchedulerModelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => 
options.WithOrigins("https://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
