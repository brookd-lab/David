using BlazorCrudAppII.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudAppII.Shared.Repo
{
    public class DeveloperRepository:IDeveloperRepository
    {
        private readonly ApplicationDbContext _context;
        public DeveloperRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Developer>> GetAll()
        {
            var developers = await _context.Developers.ToListAsync();
            return developers;
        }
        public async Task<Developer?> GetById(int id)
        {
            Developer? developer = await _context.Developers.FindAsync(id);
            return developer;
        }
        public async Task<Developer?> Insert(Developer developer)
        {
            await _context.AddAsync(developer);
            await _context.SaveChangesAsync();
            return developer;
        }
        public async Task<Developer> Update(Developer developer)
        {
            _context.Update(developer);
            await _context.SaveChangesAsync();
            return developer;
        }
        public async Task<Developer> Remove(int id)
        {
            Developer? developer = await _context.Developers.FindAsync(id);
            _context.Developers.Remove(developer);
            await _context.SaveChangesAsync();
            return developer;
        }



    }
}
