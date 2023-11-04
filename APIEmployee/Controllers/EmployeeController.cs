using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public List<Employee> GetAll()
        {
            _employees = _context.Employee.ToList();
            return _employees;
        }

        [HttpGet("{id}")]
        public Employee GetById(int id)
        {
            var employee = _context.Employee.Find(id);

            return employee;
        }

        [HttpPost]
        public Employee Create(Employee employee)
        {
            _context.Add<Employee>(employee);
            _context.SaveChanges();

            return employee;
        }

        [HttpPut]
        public Employee Update(Employee employee)
        {
            _context.Update<Employee>(employee);
            _context.SaveChanges();

            return employee;
        }

        [HttpDelete]
        public Employee DeleteByID(int id)
        {
            var employee = _context.Employee.Find(id);
            
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            
            return employee;
        }
    }
}