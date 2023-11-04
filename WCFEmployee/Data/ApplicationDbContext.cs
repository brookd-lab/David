using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WCFEmployee
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=EmployeeEntity")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.salary)
                .HasPrecision(20, 2);
        }
    }
}
