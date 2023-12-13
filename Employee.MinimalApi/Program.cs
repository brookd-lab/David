using Microsoft.EntityFrameworkCore;
using MVCEmployee.Data;
using MVCEmployee.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
      options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/employees/get_all",  async (ApplicationDbContext dbContext) =>
{
    var results = await dbContext.Employee.ToListAsync();
    return Results.Ok(results);
});

app.MapGet("/employees/get_by_id/{id}", async (int id, ApplicationDbContext dbContext) =>
{
    var employee =  await dbContext.Employee.FindAsync(id);

    if (employee == null)
    {
        return Results.NotFound();
    }
    else
    {
        return Results.Ok(employee);
    }
});

app.MapPut("/employees/update_employee", async (Employee employee, ApplicationDbContext dbContext) =>
{
    dbContext.Update(employee);
    await dbContext.SaveChangesAsync();
    return Results.NoContent();
});

app.MapPost("/employees/add_employee", async (Employee employee, ApplicationDbContext dbContext) =>
{
    await dbContext.AddAsync(employee);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/employees/created/{employee.Id}", employee);
});

app.MapDelete("/employee/delete_by_id/{id}", async (int id, ApplicationDbContext dbContext) =>
{
    var employee = await dbContext.Employee.FindAsync(id);

    if (employee == null)
        return Results.NotFound();
    else
    {
        dbContext.Remove(employee);
        await dbContext.SaveChangesAsync();
        return Results.NoContent();
    }
});

app.Run();
