using MinimalApi.Repo.Data;
using MinimalApi.Repo.Repository;
using MinimalApi.Repo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
      options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
builder.Services.AddScoped<EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/employees/get_all", async (EmployeeRepository repo) =>
{
    return await repo.GetAll();
});

app.MapGet("/employees/get_by_id/{id}", async (int id, EmployeeRepository repo) =>
{
    return await repo.GetById(id);
});

app.MapPut("/employees/update_employee", async (Employee employee, EmployeeRepository repo) =>
{
    return await repo.Update(employee);
});

app.MapPost("/employees/add_employee", async (Employee employee, EmployeeRepository repo) =>
{
    return await repo.Create(employee);
});

app.MapDelete("/employee/delete_by_id/{id}", async (int id, EmployeeRepository repo) =>
{
    return await repo.DeleteByID(id);
});

app.Run();
