
using Microsoft.EntityFrameworkCore;
using System.Data;
using Repo.Models;

namespace Repo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
      
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
