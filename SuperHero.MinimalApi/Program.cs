using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repo.Data;
using Repo.Models;
using Repo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<SuperHeroService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/SuperHero/GetAll", async(SuperHeroService _repo) =>
{
    return await _repo.GetAllHeroes();
});

app.MapGet("/SuperHero/GetById/{id}", async (int id, SuperHeroService _repo) =>
{
    return await _repo.GetHeroById(id);
});

app.MapPost("SuperHero/Add", async (SuperHero hero, SuperHeroService _repo) =>
{
    return await _repo.AddHero(hero);
});

app.MapPut("SuperHero/Update", async (SuperHero hero, SuperHeroService _repo) =>
{
    return await _repo.UpdateHero(hero);
});

app.MapDelete("SuperHero/Delete/{id}", async (int id, SuperHeroService _repo) =>
{
    return await _repo.DeleteHero(id);
});

app.Run();

