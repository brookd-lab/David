using Repo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Repo.Models;

namespace Repo.Repository
{
    public class EmployeeRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IResult> GetAll()
        {
            var employees = await _dbContext.Employee.ToListAsync();
            return Results.Ok(employees);
        }

        public async Task<IResult> GetById(int id)
        {
            var employee = await _dbContext.Employee.FindAsync(id);
            if (employee == null)
            {
                return Results.NotFound(employee); //404
            }

            return Results.Ok(employee); //200
        }

        public async Task<IResult> Create(Employee employee)
        {
            await _dbContext.AddAsync<Employee>(employee);
            await _dbContext.SaveChangesAsync();

            return Results.Created($"/employee/{employee.Id}", employee);
        }

        public async Task<IResult> Update(Employee employee)
        {
            _dbContext.Update<Employee>(employee);
            await _dbContext.SaveChangesAsync();

            return Results.NoContent(); //204
        }

        public async Task<IResult> DeleteByID(int id)
        {
            var employee = await _dbContext.Employee.FindAsync(id);
            if (employee == null)
                return Results.NotFound(employee);

            _dbContext.Employee.Remove(employee);
            await _dbContext.SaveChangesAsync();

            return Results.NoContent();
        }
    }
}
