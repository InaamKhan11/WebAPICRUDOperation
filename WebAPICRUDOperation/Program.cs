using Microsoft.EntityFrameworkCore;
using WebAPICRUDOperation.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Inaam i added this line 
builder.Services.AddDbContext<UserApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserApidata")));

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
