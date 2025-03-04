﻿using HardwareBayAPI.Data;
using HardwareBayAPI.Mappings;
using HardwareBayAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Thêm DbContext với Connection String
builder.Services.AddDbContext<HardwareDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HardWareBayConnectionString")));

builder.Services.AddScoped<IBrandRepository, SQLBrandRepository>();
builder.Services.AddScoped<ICategoryRepository, SQLCategoryRepository>();
builder.Services.AddScoped<IProductRepository, SQLProductRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));


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
