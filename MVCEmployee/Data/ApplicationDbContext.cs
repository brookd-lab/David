using Microsoft.EntityFrameworkCore;
using MVCEmployee.Models;

namespace MVCEmployee.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set;}
    }
}
