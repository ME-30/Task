using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task.BL.Interface;
using Task.BL.Repository;
using Task.BL.Service;
using Task.DAL.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// add DB Context

builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// add scope
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Auto Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


// cors
builder.Services.AddCors();


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

 // allow Cors
app.UseCors(options => options
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
