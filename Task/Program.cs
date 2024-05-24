using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using Task.BL.Interface;
using Task.BL.Repository;
using Task.BL.Service;
using Task.DAL.DataBase;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

 // add DB Context

builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Auto Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
