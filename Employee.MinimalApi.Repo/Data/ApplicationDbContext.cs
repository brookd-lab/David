using Microsoft.EntityFrameworkCore;
using MinimalApi.Repo.Models;

namespace MinimalApi.Repo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
    }
}