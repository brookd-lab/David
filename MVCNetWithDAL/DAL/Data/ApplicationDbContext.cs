using DAL.Model;
using System.Data.Entity;

namespace DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection") { }

        public DbSet<Employee> Employee { get; set; }
    }
}
