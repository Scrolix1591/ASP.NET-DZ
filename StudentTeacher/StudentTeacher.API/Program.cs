using StudentTeacher.Storage;
using Microsoft.EntityFrameworkCore;
using StudentTeacher.Core.Services;
using StudentTeacher.Core.Interfaces;
using StudentTeacher.API.Filters;
using StudentTeacher.Storage.Data;
using StudentTeacher.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Local")));

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<LogFilter>();
builder.Services.AddScoped<RequestFilter>();

//builder.Services.AddTransient<MyMiddleware>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseMiddleware<MyMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();