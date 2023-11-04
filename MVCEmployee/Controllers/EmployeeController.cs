using Microsoft.AspNetCore.Mvc;
using MVCEmployee.Data;
using MVCEmployee.Models;
using System.Diagnostics;

namespace MVCEmployee.Controllers
{
    public class EmployeeController : Controller
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

        public IActionResult Index()
        {
            _employees = _context.Employee.ToList();
            return View(_employees);
        }

        public Employee GetEmployeeById(int Id)
        {
            var employee = _context.Employee
               .FirstOrDefault(m => m.Id == Id);

            return employee;
        }

        public IActionResult Details(int Id)
        {
            var employee = GetEmployeeById(Id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Update(int Id)
        {
            var employee = GetEmployeeById(Id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            var data = GetEmployeeById(employee.Id);
            if (data != null)
            {
                data.Name = employee.Name;
                data.Salary = employee.Salary;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var employee = GetEmployeeById(Id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _context.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}