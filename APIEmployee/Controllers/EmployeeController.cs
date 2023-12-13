using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCEmployee.Data;
using MVCEmployee.Models;

namespace APIEmployee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly ApplicationDbContext _context;
        private List<Employee> _employees;

        public EmployeeController(ApplicationDbContext context,
            ILogger<EmployeeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("/employees")]
        public async Task<List<Employee>> GetAll()
        {
            _employees = await _context.Employee.ToListAsync();
            return _employees;
        }

        [HttpGet("/employees/{id}")]
        public async Task<IResult> GetById(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return Results.NotFound(employee); //404
            }

            return Results.Ok(employee); //200
        }

        [HttpPost("/employees/create/")]
        public async Task<IResult> Create(Employee employee)
        {
            await _context.AddAsync<Employee>(employee);
            await _context.SaveChangesAsync();

            return Results.Created($"/employee/{employee.Id}", employee);
        }

        [HttpPut("/employees/update/")]
        public async Task<IResult> Update(Employee employee)
        {
            _context.Update<Employee>(employee);
            await _context.SaveChangesAsync();

            return Results.NoContent(); //204
        }

        [HttpDelete("/employees/delete/")]
        public async Task<IResult> DeleteByID(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
                return Results.NotFound(employee);
            
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return Results.NoContent();
        }
    }
}