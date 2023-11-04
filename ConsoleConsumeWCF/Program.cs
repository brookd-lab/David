using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleConsumeWCF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new EmployeeTrackerService.EmployeeTrackerClient();
            var employees = client.GetAll();
            foreach(var employee in employees)
            {
                Console.WriteLine($"{employee.name}/{employee.salary}");
            }
        }
    }
}
